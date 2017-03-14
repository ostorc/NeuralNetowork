using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace NeuralNetwork.MINST.Processing
{
    public class DigitImageLoader
    {
        public const string DefaultImagesPathTest = "train-images.idx3-ubyte";
        public const string DefaultLabelsPathTest = "train-labels.idx1-ubyte";
        public const string DefaultImagesPath = "t10k-images.idx3-ubyte";
        public const string DefaultLabelsPath = "t10k-labels.idx1-ubyte";
        public string Images { get; set; }
        public string Labels { get; set; }

        public DigitImageLoader(string images, string labels)
        {
            Images = images;
            Labels = labels;
        }

        public DigitImageLoader()
        {
            Images = DefaultImagesPath;
            Labels = DefaultLabelsPath;
        }

        public List<DigitImage> Load()
        {
            var result = new List<DigitImage>();
            FileStream ifsLabels = new FileStream(Labels, FileMode.Open); // test labels
            FileStream ifsImages = new FileStream(Images, FileMode.Open); // test images

            BinaryReader brLabels = new BinaryReader(ifsLabels);
            BinaryReader brImages = new BinaryReader(ifsImages);

            int magic1 = brImages.ReadInt32(); // discard
            int numImages = brImages.ReadInt32();
            int numRows = brImages.ReadInt32();
            int numCols = brImages.ReadInt32();

            int magic2 = brLabels.ReadInt32();
            int numLabels = brLabels.ReadInt32();

            var pixels = new byte[28][];
            for (int i = 0; i < pixels.Length; ++i)
                pixels[i] = new byte[28];

            // each test image
            for (int di = 0; di < 10000; ++di)
            {
                for (int i = 0; i < 28; ++i)
                for (int j = 0; j < 28; ++j)
                {
                    byte b = brImages.ReadByte();
                    pixels[i][j] = b;
                }

                byte lbl = brLabels.ReadByte();

                result.Add(new DigitImage(pixels, lbl));
            } // each image

            ifsImages.Close();
            brImages.Close();
            ifsLabels.Close();
            brLabels.Close();
            return result;
        }
    }
}