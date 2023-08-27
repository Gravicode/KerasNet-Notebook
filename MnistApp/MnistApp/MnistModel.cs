using Microsoft.ML.OnnxRuntime.Tensors;
using Microsoft.ML.OnnxRuntime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace MnistApp
{
    public class MnistModel
    {
        InferenceSession session { set; get; }
        public MnistModel()
        {
            string modelPath = Directory.GetCurrentDirectory() + @"/mnist2.onnx";

            // Optional : Create session options and set the graph optimization level for the session
            //SessionOptions options = new SessionOptions();
            //options.GraphOptimizationLevel = GraphOptimizationLevel.ORT_ENABLE_EXTENDED;
            //using (var session = new InferenceSession(modelPath, options))

            session = new InferenceSession(modelPath);
            
        }
        public int Run(float[] inputData)
        {
            var inputMeta = session.InputMetadata;
            var container = new List<NamedOnnxValue>();

            foreach (var name in inputMeta.Keys)
            {
                var dim = inputMeta[name].Dimensions;
                for (var i = 0; i < dim.Length; i++)
                {
                    if (dim[i] < 0) dim[i] = 1;
                }
                var tensor = new DenseTensor<float>(inputData, dim);
                container.Add(NamedOnnxValue.CreateFromTensor<float>(name, tensor));
            }


            // Run the inference
            using (var results = session.Run(container))  // results is an IDisposableReadOnlyCollection<DisposableNamedOnnxValue> container
            {
                // Get the results
                foreach (var r in results)
                {
                    Console.WriteLine("Output Name: {0}", r.Name);
                    int prediction = MaxProbability(r.AsTensor<float>());
                    Console.WriteLine("Prediction: " + prediction.ToString());
                    return prediction;
                    //Console.WriteLine(r.AsTensor<float>().GetArrayString());
                }
            }
            return -1;
        }

        static int MaxProbability(Tensor<float> probabilities)
        {
            float max = -9999.9F;
            int maxIndex = -1;
            for (int i = 0; i < probabilities.Length; ++i)
            {
                float prob = probabilities.GetValue(i);
                if (prob > max)
                {
                    max = prob;
                    maxIndex = i;
                }
            }
            return maxIndex;

        }

        static void PrintInputMetadata(IReadOnlyDictionary<string, NodeMetadata> inputMeta)
        {
            foreach (var name in inputMeta.Keys)
            {
                Console.WriteLine(name);
                Console.WriteLine("Dimension Length: " + inputMeta[name].Dimensions.Length);
                for (int i = 0; i < inputMeta[name].Dimensions.Length; ++i)
                {
                    Console.WriteLine(inputMeta[name].Dimensions[i]);
                }
                Console.WriteLine(inputMeta[name].ElementType.ToString());
                Console.WriteLine(inputMeta[name].IsTensor.ToString());
                Console.WriteLine(inputMeta[name].OnnxValueType.ToString());
                Console.WriteLine(inputMeta[name].SymbolicDimensions.ToString());
            }

        }
    }
}
