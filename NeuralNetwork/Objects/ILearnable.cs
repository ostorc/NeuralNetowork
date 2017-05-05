namespace NeuralNetwork.Objects
{
    /// <summary>
    /// Common interface for learnable objects
    /// </summary>
    public interface ILearnable : ICalculatable
    {
    }

    /// <summary>
    /// Common inteface for learnable objects with output value
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public interface ILearnable<TResult> : ILearnable, ICalculatable<TResult>
    {
        /// <summary>
        /// Proccess one learning cycle
        /// </summary>
        /// <param name="values">Input values</param>
        /// <param name="expectedResult">Expected value</param>
        /// <returns></returns>
        TResult Learn(double[] values, TResult expectedResult);
    }
}