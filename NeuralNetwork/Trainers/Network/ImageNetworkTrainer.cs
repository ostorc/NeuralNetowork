using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuralNetwork.MINST.Processing;
using NeuralNetwork.Objects;

namespace NeuralNetwork.Trainers.Network
{
    /// <summary>
    /// Image netowrk trainer
    /// </summary>
    public sealed class ImageNetworkTrainer : NetworkTrainer
    {
        /// <summary>
        /// Number of hidden neurons
        /// </summary>
        public override int NumberOfHiddenNeurons { get; } = 150;
        /// <summary>
        /// Number of outputs
        /// </summary>
        public override int NumberOfOutputs { get; } = 10;
        /// <summary>
        /// Number of inputs (28px x 28px)
        /// </summary>
        public override int NumberOfInputs { get; } = 784;
        /// <summary>
        /// Test inputs
        /// </summary>
        public override double[][] Inputs { get; }
        /// <summary>
        /// Test outputs
        /// </summary>
        public override double[][] Results { get; }
        /// <summary>
        /// Learning rate of network
        /// </summary>
        public override double LearningRate { get; } = 0.3;

        /// <summary>
        /// Constructor for Image Network Trainer
        /// </summary>
        /// <param name="network">Network which should learn</param>
        /// <param name="useCache">Shall be used cache if exists?</param>
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
        /// <summary>
        /// Load test data
        /// </summary>
        /// <returns>Load test data</returns>
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

        /// <summary>
        /// Detrmine if learning was sucesfull
        /// </summary>
        /// <param name="successRate">Achived success</param>
        /// <returns>State of learning</returns>
        protected override bool IsSuccess(double successRate)
        {
            return successRate > 0.999;
        }

        /// <summary>
        /// Update error rate
        /// </summary>
        /// <param name="error">Error values</param>
        /// <param name="errorRate">Current error rate</param>
        /// <param name="inputIndex">Current iteration</param>
        /// <returns>Updated error rate</returns>
        protected override double UpdateErrorRate(double[] error, double errorRate, int inputIndex)
        {
            var nnResult = network.Calculate(Inputs[inputIndex]);
            return Results[inputIndex][nnResult.ToList().IndexOf(nnResult.Max())];
        }
        /// <summary>
        /// Update error rate after epoch
        /// </summary>
        /// <param name="errorRate"></param>
        /// <returns>Updated value</returns>
        protected override double EditErrorRateAfterEpoch(double errorRate)
        {
            return errorRate / Inputs.Length;
        }
    }
}
