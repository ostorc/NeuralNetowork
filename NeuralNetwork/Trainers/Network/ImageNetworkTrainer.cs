using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuralNetwork.MINST.Processing;
using NeuralNetwork.Objects;

namespace NeuralNetwork.Trainers.Network
{
    public sealed class ImageNetworkTrainer : NetworkTrainer
    {
        public override int NumberOfHiddenNeurons { get; } = 150;
        public override int NumberOfOutputs { get; } = 10;
        public override int NumberOfInputs { get; } = 784;
        public override double[][] Inputs { get; }
        public override double[][] Results { get; }
        public override double LearningRate { get; } = 0.3;


        public ImageNetworkTrainer(ILearnableNetwork network, bool useCache) : base(network, useCache)
        {
            DigitImageLoader loader = new DigitImageLoader(DigitImageLoader.DefaultImagesPathTest,
                DigitImageLoader.DefaultLabelsPathTest);
            var data = loader.Load();
            Inputs = new double[data.Count][];
            for (int i = 0; i < data.Count; i++)
            {
                Inputs[i] = data[i].ToDoubleArray();
            }
            Results = new double[data.Count][];
            for (int i = 0; i < data.Count; i++)
            {
                Results[i] = new double[NumberOfOutputs];
                Results[i][data[i].Label] = 1;
            }
        }

        public override List<KeyValuePair<double[], double[]>> GetTestData()
        {
            List<KeyValuePair<double[], double[]>> result = new List<KeyValuePair<double[], double[]>>();
            DigitImageLoader loader = new DigitImageLoader();
            var data = loader.Load();
            foreach (DigitImage image in data)
            {
                var output = new double[NumberOfOutputs];
                output[image.Label] = 1;
                result.Add(new KeyValuePair<double[], double[]>(image.ToDoubleArray(), output));
            }
            return result;
        }

        protected override bool IsSuccess(double errorRate)
        {
            return errorRate > 0.999;
        }

        protected override double UpdateErrorRate(double[] error, double errorRate, int inputIndex)
        {
            var nnResult = network.Calculate(Inputs[inputIndex]);
            return Results[inputIndex][nnResult.ToList().IndexOf(nnResult.Max())];
        }

        protected override double EditErrorRateAfterEpoch(double errorRate)
        {
            return errorRate / Inputs.Length;
        }
    }
}
