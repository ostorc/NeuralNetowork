namespace NeuralNetwork.Objects
{
    /// <summary>
    /// Network with ability learn
    /// </summary>
    public interface ILearnableNetwork : ILearnable<double[]>, ICalculatableNetwork
    {
    }
}