namespace NeuralNetwork.Objects
{
    public interface ILearnableNeuron : ILearnable<double>, ICalculatableNeuron
    {
        //object Learn(object values, object expectedResult);
    }
}