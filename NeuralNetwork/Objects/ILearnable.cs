namespace NeuralNetwork.Objects
{
    public interface ILearnable : ICalculatable
    {
    }

    public interface ILearnable<TResult> : ILearnable, ICalculatable<TResult>
    {
        TResult Learn(double[] values, TResult expectedResult);
    }
}