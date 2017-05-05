using NeuralNetwork.MINST.Processing;

namespace NeuralNetwork.Objects
{
    /// <summary>
    /// Interface of object with ability to find out number baed on input parameters
    /// </summary>
    public interface ICalculatableImageNetwork : ICalculatable
    {
        /// <summary>
        /// Get number in range of 0 to 9
        /// </summary>
        /// <param name="image">Byte array of inputs</param>
        /// <returns>Calculated number</returns>
        byte GetNumber(double[] image);
        /// <summary>
        /// Get number in range of 0 to 9
        /// </summary>
        /// <param name="image">Digital version of image</param>
        /// <returns>Calculated number</returns>
        byte GetNumber(DigitImage image);
    }
}