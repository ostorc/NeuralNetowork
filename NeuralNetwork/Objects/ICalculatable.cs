namespace NeuralNetwork.Objects
{
    /// <summary>
    /// Common interface for objects with ability to calculate output
    /// </summary>
    /// <typeparam name="TResult">Expected output</typeparam>
    public interface ICalculatable<out TResult> : ICalculatable
    {
        /// <summary>
        /// Calculate
        /// </summary>
        /// <param name="values">Input values</param>
        /// <returns>Result of calculation</returns>
        TResult Calculate(params double[] values);
    }

    /// <summary>
    /// Common interface for objects with ability to calculate
    /// </summary>
    public interface ICalculatable
    {
    }
}