namespace NeuralNetwork.Objects
{
    public interface ICalculatable<out TResult> : ICalculatable
    {
        TResult Calculate(params double[] values);
    }

    public interface ICalculatable
    {
    }
}