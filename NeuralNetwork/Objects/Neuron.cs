using System;
using System.Linq;

namespace NeuralNetwork.Objects
{
    /// <summary>
    /// Learnable neuron
    /// </summary>
    public class Neuron : ILearnableNeuron
    {
        private double Bias { get; set; }

        private double[] InputBiases { get; set; }

        private Func<double, double> ActivationFunction { get; set; }

        /// <summary>
        /// Constructor for <see cref="Neuron"/>
        /// </summary>
        /// <param name="inputCount">Number of inputs</param>
        /// <param name="activationFunctionType">Activation function</param>
        public Neuron(int inputCount, ActivationFunctionType activationFunctionType)
        {
            InputBiases = Enumerable.Range(0, inputCount).Select(x => Helpers.Random.NextDouble()).ToArray();
            Bias = Helpers.Random.NextDouble();

            switch (activationFunctionType)
            {
                case ActivationFunctionType.Sigmoid:
                    ActivationFunction = Helpers.ActivationFunction.Sigmoid;
                    break;
                case ActivationFunctionType.Step:
                    ActivationFunction = Helpers.ActivationFunction.Step;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(activationFunctionType), activationFunctionType, null);
            }
        }
        /// <summary>
        /// Constructor for <see cref="Neuron"/>
        /// </summary>
        /// <param name="inputCount">Number of inputs</param>
        /// <param name="activationFunction">Custom activation function</param>
        public Neuron(int inputCount, Func<double, double> activationFunction)
        {
            InputBiases = Enumerable.Range(0, inputCount).Select(x => Helpers.Random.NextDouble()).ToArray();
            Bias = Helpers.Random.NextDouble();
            ActivationFunction = activationFunction;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="values"></param>
        /// <param name="expectedResult"></param>
        /// <returns></returns>
        double ILearnable<double>.Learn(double[] values, double expectedResult)
        {
            double res = Calculate(values);
            double error = expectedResult - res;
            for (int i = 0; i < InputBiases.Length; i++)
                InputBiases[i] += error * values[i];
            Bias += error;

            return error;
        }

        /// <summary>
        /// Calculate value
        /// </summary>
        /// <param name="values">Input values</param>
        /// <returns>Calculated value</returns>
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