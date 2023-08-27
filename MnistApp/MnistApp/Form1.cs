using Microsoft.ML.OnnxRuntime.Tensors;
using Microsoft.ML.OnnxRuntime;
using Microsoft.VisualBasic;
using System.Security.Cryptography.X509Certificates;

namespace MnistApp
{
    public partial class Form1 : Form
    {
        MnistModel model;
        Bitmap screen { set; get; }
        const int BoxWidth = 28;
        int[][] Box = new int [BoxWidth][];
        static int BoxPixelWidth = 0;
        public Form1()
        {
            InitializeComponent();
            BoxPixelWidth = (int)((double)DrawingBox.Width / BoxWidth);
            model = new();
            Reset();           
            this.DrawingBox.MouseDown += DrawingBox_MouseDown;
            this.DrawingBox.MouseMove += DrawingBox_MouseMove;
            BtnClear.Click += (a, b) => { Reset(); };
            BtnGuess.Click += (a, b) => {
                var input = GetInput();
                TxtGuess.Text = model.Run(input).ToString();
            };
        }

     

        void Reset()
        {
            for (var x = 0; x < BoxWidth; x++)
            {
                Box[x] = new int[BoxWidth];
                for (var y = 0; y < BoxWidth; y++)
                {
                    //white
                    Box[x][y] = 0;
                }
            }
         
            DrawBox();
            
        }

        void DrawBox()
        {
            var whiteBrush = new SolidBrush(Color.White);
            var blackBrush = new SolidBrush(Color.Black);
            screen = new Bitmap(DrawingBox.Width, DrawingBox.Height);

            using (Graphics gfx = Graphics.FromImage(screen))
            {
                gfx.FillRectangle(whiteBrush, new Rectangle(0, 0, DrawingBox.Width, DrawingBox.Height));
                for (var x = 0; x < BoxWidth; x++)
                {
                    for (var y = 0; y < BoxWidth; y++)
                    {
                        //black only
                        if (Box[x][y] == 1)
                        {
                            gfx.FillRectangle(blackBrush, new Rectangle(x * BoxPixelWidth, y * BoxPixelWidth, BoxPixelWidth, BoxPixelWidth));

                        }
                    }
                }
            }
            this.DrawingBox.Image = screen;
        }

        private void DrawingBox_MouseDown(object? sender, MouseEventArgs e)
        {
            PickBox(e.X, e.Y, e.Button);
        }
        private void DrawingBox_MouseMove(object? sender, MouseEventArgs e)
        {
            PickBox(e.X, e.Y, e.Button);
        }
        void PickBox(int eX, int eY,MouseButtons buttons )
        {
          
            var x = eX / BoxPixelWidth;
            var y = eY / BoxPixelWidth;
            if (x >= BoxWidth || y >= BoxWidth || x<0 || y<0)
            {
                return;
            }
            if (buttons == MouseButtons.Left)
            {
                Box[x][y] = 1;
            }
            else if (buttons == MouseButtons.Right)
            {
                Box[x][y] = 0;
            }
            else
                return;
            DrawBox();
        }

        float[] GetInput()
        {
            float[] input = new float[BoxWidth * BoxWidth];
            int counter = 0;
            for (var y = 0; y < BoxWidth; y++)
            {
                for (var x = 0; x < BoxWidth; x++)
                {
                    input[counter++] = Box[x][y]; 
                }
            }
            return input;
        }
    }
}