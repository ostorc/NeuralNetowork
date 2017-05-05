namespace NeuralNetwork.Objects
{
    /// <summary>
    /// Neuron with ability to learn
    /// </summary>
    public interface ILearnableNeuron : ILearnable<double>, ICalculatableNeuron
    {
        //object Learn(object values, object expectedResult);
    }
}