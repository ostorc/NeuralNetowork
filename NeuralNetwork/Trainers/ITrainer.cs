using System.Collections.Generic;
using NeuralNetwork.Objects;

namespace NeuralNetwork.Trainers
{
    public interface ITrainer
    {
        int NumberOfInputs { get; }
        double[][] Inputs { get; }
        double[][] Results { get; }
        T Train<T>() where T : class, ICalculatable;
        T Get<T>() where T : class, ICalculatable;
        void Train();

        List<KeyValuePair<double[],double[]>> GetTestData();
    }
}