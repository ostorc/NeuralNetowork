using System;
using System.Linq;

namespace NeuralNetwork.Objects
{
    public class Neuron : ILearnableNeuron
    {
        public double Bias { get; set; }

        public double[] InputBiases { get; set; }

        public Func<double, double> ActivationFunction { get; set; }

        public Neuron(int inputCount, ActivationFunctionType activationFunctionType)
        {
            InputBiases = Enumerable.Range(0, inputCount).Select(x => Helpers.Random.NextDouble()).ToArray();
            Bias = Helpers.Random.NextDouble();

            switch (activationFunctionType)
            {
                case ActivationFunctionType.Sigmoid:
                    ActivationFunction = x => 1 / (1 + Math.Pow(Math.E, -x));
                    break;
                case ActivationFunctionType.Step:
                    ActivationFunction = x => x < 0 ? 0 : 1;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(activationFunctionType), activationFunctionType, null);
            }
        }

        public Neuron(int inputCount, Func<double, double> activationFunction)
        {
            InputBiases = Enumerable.Range(0, inputCount).Select(x => Helpers.Random.NextDouble()).ToArray();
            Bias = Helpers.Random.NextDouble();
            ActivationFunction = activationFunction;
        }

        public double Learn(double[] values, double expectedResult)
        {
            double res = Calculate(values);
            double error = expectedResult - res;
            for (int i = 0; i < InputBiases.Length; i++)
                InputBiases[i] += error * values[i];
            Bias += error;

            return error;
        }

        public double Calculate(params double[] values)
        {
            if (values.Length != InputBiases.Length)
                throw new ArgumentOutOfRangeException(nameof(values),
                    $"Values doesnt match {nameof(InputBiases)} count. Length of {nameof(values)} should be {values.Length}");
            return
                ActivationFunction(Bias +
                                   Enumerable.Range(0, InputBiases.Length).Select(i => values[i] * InputBiases[i]).Sum());
        }
    }
}