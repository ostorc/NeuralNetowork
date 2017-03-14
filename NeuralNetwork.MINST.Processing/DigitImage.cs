using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace NeuralNetwork.MINST.Processing
{
    public class DigitImage
    {
        private Image image;
        public byte[][] Pixels { get; set; }
        public byte Label { get; set; }

        public Image NumberImage
        {
            get
            {
                if (image != null) return image;
                var img = new Bitmap(28, 28);
                for (int i = 0; i < 28; ++i)
                    for (int j = 0; j < 28; ++j)
                        img.SetPixel(j,i, Pixels[i][j].ToGrayscale());
                return image = img;

            }
        }

        public DigitImage(byte[][] pixels, byte label)
        {
            this.Pixels = new byte[28][];
            for (int i = 0; i < this.Pixels.Length; ++i)
                this.Pixels[i] = new byte[28];

            for (int i = 0; i < 28; ++i)
                for (int j = 0; j < 28; ++j)
                    this.Pixels[i][j] = pixels[i][j];

            this.Label = label;
        }

        public DigitImage(double[] pixels, byte label)
        {
            this.Pixels = new byte[28][];
            for (int i = 0; i < this.Pixels.Length; ++i)
                this.Pixels[i] = new byte[28];
            var d = pixels.Make2DArray(28,28);

            for (int i = 0; i < 28; i++)
            {
                for (int j = 0; j < 28; j++)
                {
                    Pixels[i][j] = (byte)(d[i, j] * 255);
                }
            }
            this.Label = label;
        }

        public double[] ToDoubleArray()
        {
            var res = new List<double>();

            for (int i = 0; i < Pixels.GetLength(0); i++)
            {
                for (int j = 0; j < Pixels[i].Length; j++)
                {
                    res.Add(Pixels[i][j] / 255.0);
                }
            }
            return res.ToArray();
        }

        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < 28; ++i)
            {
                for (int j = 0; j < 28; ++j)
                {
                    if (this.Pixels[i][j] == 0)
                        s += " "; // white
                    else if (this.Pixels[i][j] == 255)
                        s += "O"; // black
                    else
                        s += "."; // gray
                }
                s += "\n";
            }
            s += this.Label.ToString();
            return s;
        } // ToString

    }

    public static class Extension
    {
        public static T[,] Make2DArray<T>(this T[] input, int height, int width)
        {
            T[,] output = new T[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    output[i, j] = input[i * width + j];
                }
            }
            return output;
        }

        internal static Color ToGrayscale(this byte brightness)
        {
            brightness = (byte) (255 - brightness);
            return Color.FromArgb(brightness, brightness, brightness);
        }

        internal static byte FromGrayscale(this Color color)
        {
            return (byte)Math.Round(color.GetBrightness() * 255.0);
        }
    }

}
