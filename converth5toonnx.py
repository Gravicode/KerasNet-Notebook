from tensorflow.python.keras import backend as K
from tensorflow.python.keras.models import load_model
import onnx
import keras2onnx

onnx_model_name = 'mnist2.onnx'

model = load_model('mnist2.h5')
onnx_model = keras2onnx.convert_keras(model, model.name)
onnx.save_model(onnx_model, onnx_model_name)