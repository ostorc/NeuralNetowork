using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NeuralNetwork.Objects;

namespace NeuralNetwork.Trainers.Neurons
{
    public abstract class NeuronTrainer : ITrainer
    {
        private ILearnableNeuron neuron { get; }
        public abstract ActivationFunctionType ActivationFunction { get; }

        protected NeuronTrainer(ILearnableNeuron neuron)
        {
            if (neuron == null) neuron = CreateNeuron();
            this.neuron = neuron;
        }

        protected NeuronTrainer()
        {
            neuron = CreateNeuron();
        }

        public abstract double[][] Inputs { get; }
        public abstract double[][] Results { get; }
        public abstract int NumberOfInputs { get; }

        public T Train<T>() where T : class, ICalculatable
        {
            double errorRate;
            int epoch = 0;
            do
            {
                errorRate = 0;
                for (int i = 0; i < Inputs.GetLength(0); i++)
                    errorRate += Math.Abs(neuron.Learn(Inputs[i].ToArray(), Results[i][0]));
                if (++epoch % 10 == 0)
                    Debug.WriteLine("Epoch {0:N} of training completed", epoch);
            } while (errorRate > 0.3);

            return neuron as T;
        }

        public T Get<T>() where T : class, ICalculatable
        {
            return neuron as T;
        }

        public void Train()
        {
            Train<ICalculatable>();
        }

        protected ILearnableNeuron CreateNeuron()
        {
            return new Neuron(NumberOfInputs, ActivationFunction);
        }

        public virtual List<KeyValuePair<double[], double[]>> GetTestData()
        {
            return
                Enumerable.Range(0, Inputs.Length)
                    .Select(i => new KeyValuePair<double[], double[]>(Inputs[i], Results[i])).ToList();
        }
    }
}