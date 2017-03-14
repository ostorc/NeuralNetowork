using NeuralNetwork.MINST.Processing;

namespace NeuralNetwork.Objects
{
    public interface ICalculatableImageNetwork : ICalculatable
    {
        byte GetNumber(double[] image);
        byte GetNumber(DigitImage image);
    }
}