using System;
using System.Linq;
using System.Threading.Tasks;
using NeuralNetwork.MINST.Processing;

namespace NeuralNetwork.Objects
{
    [Serializable]
    public sealed class NeuralNetwork : ILearnableNetwork, ICalculatableImageNetwork
    {
        public int NumberOfInputs { get; }
        public int NumberOfHidden { get; }
        public int NumberOfOutputs { get; }
        internal double[][] InputToHiddenNeuronBiases { get; }
        internal double[][] HiddenOutputsToOutputBiases { get; }
        public double LearningRate { get; }


        public NeuralNetwork(int numberOfHidden, int numberOfInputs, int numberOfOutputs, double learningRate)
        {
            NumberOfInputs = numberOfInputs;
            NumberOfOutputs = numberOfOutputs;
            NumberOfHidden = numberOfHidden;
            LearningRate = learningRate;

            InputToHiddenNeuronBiases = new double[NumberOfHidden][];
            for (int i = 0; i < numberOfHidden; i++)
                InputToHiddenNeuronBiases[i] =
                    Enumerable.Range(0, NumberOfInputs + 1).Select(x => Helpers.Random.NextDouble() * 2 - 1).ToArray();
            HiddenOutputsToOutputBiases = new double[NumberOfOutputs][];
            for (int i = 0; i < numberOfOutputs; i++)
                HiddenOutputsToOutputBiases[i] =
                    Enumerable.Range(0, NumberOfHidden + 1).Select(x => Helpers.Random.NextDouble() * 2 - 1).ToArray();
        }

        public double[] Calculate(params double[] input)
        {
            double[] data;
            return Calculate(out data, input);
        }

        public double[] Learn(double[] values, double[] target)
        {
            double[] hidden;
            var result = Calculate(out hidden, values);

            var delatError = Enumerable.Range(0, target.Length).Select(x => target[x] - result[x]).ToArray();

            var deltaHidden = new double[NumberOfHidden + 1];
            var deltaOutputs = new double[NumberOfOutputs];

            for (int i = 0; i < NumberOfOutputs; i++)
                deltaOutputs[i] = result[i] * (1 - result[i]) * (target[i] - result[i]);

            for (int i = 0; i < NumberOfHidden; i++)
            {
                double error = 0;
                for (int j = 0; j < NumberOfOutputs; j++)
                    error += HiddenOutputsToOutputBiases[j][i] * deltaOutputs[j];
                deltaHidden[i] = hidden[i] * (1.0 - hidden[i]) * error;
            }

            Task t1 = Task.Run(() =>
            {
                for (int i = 0; i < NumberOfOutputs; i++)
                for (int j = 0; j < NumberOfHidden; j++)
                    HiddenOutputsToOutputBiases[i][j] += LearningRate * deltaOutputs[i] * hidden[j];
            });
            Task t2 = Task.Run(() =>
            {
                for (int i = 0; i < NumberOfHidden; i++)
                for (int j = 0; j < NumberOfInputs; j++)
                    InputToHiddenNeuronBiases[i][j] += LearningRate * deltaHidden[i] * values[j];
            });

            Task.WaitAll(t1, t2);

            return delatError;
        }

        private double[] Calculate(out double[] hidden, params double[] values)
        {
            if (values.Length != NumberOfInputs)
                throw new ArgumentOutOfRangeException(nameof(values),
                    $"Values doesnt match {nameof(NumberOfInputs)} ({NumberOfInputs}) count.");
            var input = new double[values.Length + 1];
            for (int i = 0; i < values.Length; i++)
                input[i] = values[i];
            input[values.Length] = 1;

            var hiddenOutput = new double[NumberOfHidden + 1];
            for (int i = 0; i < InputToHiddenNeuronBiases.Length; i++)
            {
                double sum = 0;
                for (int j = 0; j < NumberOfInputs + 1; j++)
                    sum += input[j] * InputToHiddenNeuronBiases[i][j];
                hiddenOutput[i] = Helpers.ActivationFunction.Sigmoid(sum);
            }
            hiddenOutput[NumberOfHidden] = 1;

            hidden = hiddenOutput.Clone() as double[];

            var output = new double[NumberOfOutputs];
            for (int i = 0; i < NumberOfOutputs; i++)
            {
                double sum = 0;
                for (int j = 0; j < NumberOfHidden + 1; j++)
                    sum += hiddenOutput[j] * HiddenOutputsToOutputBiases[i][j];
                output[i] = Helpers.ActivationFunction.Sigmoid(sum);
            }

            return output;
        }

        public byte GetNumber(double[] image)
        {
            var data = Calculate(image).ToList();
            return (byte)data.IndexOf(data.Max());
        }

        public byte GetNumber(DigitImage image)
        {
            var data = Calculate(image.ToDoubleArray()).ToList();
            return (byte)data.IndexOf(data.Max());
        }
    }
}