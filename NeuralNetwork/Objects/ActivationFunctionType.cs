namespace NeuralNetwork.Objects
{
    /// <summary>
    /// Activation function of neuron
    /// </summary>
    public enum ActivationFunctionType
    {
        /// <summary>
        /// Sigmoid function <see cref="Helpers.ActivationFunction.Step(double)"/>
        /// </summary>
        Sigmoid,
        /// <summary>
        /// Step function <see cref="Helpers.ActivationFunction.Step(double)"/>
        /// </summary>
        Step
    }
}