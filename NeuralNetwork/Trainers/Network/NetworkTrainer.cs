using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NeuralNetwork.Objects;

namespace NeuralNetwork.Trainers.Network
{
    /// <summary>
    /// Base network trainer
    /// </summary>
    public abstract class NetworkTrainer : ITrainer
    {
        /// <summary>
        /// Trainable network
        /// </summary>
        protected ILearnableNetwork network { get; }
        /// <summary>
        /// Number of hidden neurons
        /// </summary>
        public abstract int NumberOfHiddenNeurons { get; }
        /// <summary>
        /// Number of outputs
        /// </summary>
        public abstract int NumberOfOutputs { get; }
        /// <summary>
        /// Number of inputs
        /// </summary>
        public abstract int NumberOfInputs { get; }
        /// <summary>
        /// Test inputs
        /// </summary>
        public abstract double[][] Inputs { get; }
        /// <summary>
        /// Test results
        /// </summary>
        public abstract double[][] Results { get; }
        /// <summary>
        /// Learning rate
        /// </summary>
        public virtual double LearningRate { get; } = 0.3;
        /// <summary>
        /// Constructor for network trainer
        /// </summary>
        /// <param name="network">Network which will be teached</param>
        /// <param name="useCache">Shall be used cahce?</param>
        protected NetworkTrainer(ILearnableNetwork network, bool useCache = true)
        {
            if (network == null) network = CreateNetwork(useCache);
            this.network = network;
        }
        /// <summary>
        /// Train network
        /// </summary>
        public void Train()
        {
            Train<ICalculatable>();
        }
        /// <summary>
        /// Train network and return instance of <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">Expected netowrk type</typeparam>
        /// <returns>Network of type <typeparamref name="T"/> after one epoch</returns>
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

        /// <summary>
        /// Retunr network
        /// </summary>
        /// <typeparam name="T">Netowrk type</typeparam>
        /// <returns>Netowrk of type <typeparamref name="T"/></returns>
        public T Get<T>() where T : class, ICalculatable
        {
            return network as T;
        }
        /// <summary>
        /// Update error rate
        /// </summary>
        /// <param name="error">Error values</param>
        /// <param name="errorRate">Current error rate</param>
        /// <param name="inputIndex">Current iteration</param>
        /// <returns>Updated error rate</returns>
        protected virtual double UpdateErrorRate(double[] error, double errorRate, int inputIndex)
        {
            foreach (double e in error)
                errorRate += Math.Abs(e);
            return errorRate;
        }
        /// <summary>
        /// Update error rate after epoch
        /// </summary>
        /// <param name="errorRate"></param>
        /// <returns>Updated value</returns>
        protected virtual double EditErrorRateAfterEpoch(double errorRate)
        {
            return errorRate;
        }
        /// <summary>
        /// Detrmine if learning was sucesfull
        /// </summary>
        /// <param name="successRate">Achived success</param>
        /// <returns>State of learning</returns>
        protected virtual bool IsSuccess(double successRate)
        {
            return successRate < 0.05;
        }
        /// <summary>
        /// Load or create network
        /// </summary>
        /// <param name="useCache">Shall be used cache?</param>
        /// <returns>Instance of network</returns>
        protected ILearnableNetwork CreateNetwork(bool useCache)
        {
            var res = useCache ? Helpers.ReadFromBinaryFile<Objects.NeuralNetwork>(this.GetType().Name + "Network") : null;
            return res ??
                   new Objects.NeuralNetwork(NumberOfHiddenNeurons, NumberOfInputs, NumberOfOutputs, LearningRate);
        }
        /// <summary>
        /// Create test data
        /// </summary>
        /// <returns></returns>
        public virtual List<KeyValuePair<double[], double[]>> GetTestData()
        {
            return
                Enumerable.Range(0, Inputs.Length)
                    .Select(i => new KeyValuePair<double[], double[]>(Inputs[i], Results[i])).ToList();
        }
    }
}