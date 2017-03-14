using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork.MINST.Processing
{
    public class CustomDigitImageProcessor
    {
        public string Path { get; }
        public int Label { get; }
        public CustomDigitImageProcessor(string path, int label)
        {
            Path = path;
            Label = label;
        }

        public DigitImage Load()
        {
            byte[][] pixels = new byte[28][];
            for (int i = 0; i < pixels.Length; ++i)
                pixels[i] = new byte[28];

            Bitmap img = Image.FromFile(Path) as Bitmap;
            for (int i = 0; i < 28; ++i)
            for (int j = 0; j < 28; j++)
                pixels[j][i] = (byte)(255-img.GetPixel(i, j).FromGrayscale());

            img?.Dispose();
            return new DigitImage(pixels, (byte) this.Label);
        }
    }
}
