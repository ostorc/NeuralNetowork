using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NeuralNetwork.Objects;

namespace NeuralNetwork.Trainers.Network
{
    public abstract class NetworkTrainer : ITrainer
    {
        protected ILearnableNetwork network { get; }
        public abstract int NumberOfHiddenNeurons { get; }
        public abstract int NumberOfOutputs { get; }
        public virtual double LearningRate { get; } = 0.3;

        protected NetworkTrainer(ILearnableNetwork network, bool useCache = true)
        {
            if (network == null) network = CreateNetwork(useCache);
            this.network = network;
        }

        protected NetworkTrainer(bool useCache = true)
        {
            network = CreateNetwork(useCache);
        }

        public void Train()
        {
            Train<ICalculatable>();
        }

        public T Train<T>() where T : class, ICalculatable
        {
            double errorRate;
            int epoch = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            do
            {
                errorRate = 0;
                for (int i = 0; i < Inputs.GetLength(0); i++)
                {
                    var error = network.Learn(Inputs[i].ToArray(), Results[i]);
                    errorRate += UpdateErrorRate(error, errorRate, i);
                }
                errorRate = EditErrorRateAfterEpoch(errorRate);
                //if (++epoch % 10 == 0)
                    Debug.WriteLine("Epoch {0:N} of training completed with error rate {1}", ++epoch, errorRate);
            } while (!IsSuccess(errorRate));
            sw.Stop();

            Debug.WriteLine("Learning ended at time {0}, with {1} lerning cycles and {2:N} error rate.", sw.Elapsed,
                epoch,
                errorRate);
            Helpers.WriteToBinaryFile(this.GetType().Name + "Network", network as T);
            return network as T;
        }

        public T Get<T>() where T : class, ICalculatable
        {
            return network as T;
        }

        protected virtual double UpdateErrorRate(double[] error, double errorRate, int inputIndex)
        {
            foreach (double e in error)
                errorRate += Math.Abs(e);
            return errorRate;
        }

        protected virtual double EditErrorRateAfterEpoch(double errorRate)
        {
            return errorRate;
        }

        protected virtual bool IsSuccess(double errorRate)
        {
            return errorRate < 0.05;
        }

        public abstract double[][] Inputs { get; }
        public abstract double[][] Results { get; }
        public abstract int NumberOfInputs { get; }

        protected ILearnableNetwork CreateNetwork(bool useCache)
        {
            var res = useCache ? Helpers.ReadFromBinaryFile<Objects.NeuralNetwork>(this.GetType().Name + "Network") : null;
            return res ??
                   new Objects.NeuralNetwork(NumberOfHiddenNeurons, NumberOfInputs, NumberOfOutputs, LearningRate);
        }

        public virtual List<KeyValuePair<double[], double[]>> GetTestData()
        {
            return
                Enumerable.Range(0, Inputs.Length)
                    .Select(i => new KeyValuePair<double[], double[]>(Inputs[i], Results[i])).ToList();
        }
    }
}