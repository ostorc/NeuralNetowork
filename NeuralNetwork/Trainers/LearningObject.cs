namespace NeuralNetwork.Trainers
{
    /// <summary>
    /// Learning objects
    /// </summary>
    public enum LearningObject
    {
        /// <summary>
        /// Network, more complex than <see cref="Neuron"/>
        /// </summary>
        Network,
        /// <summary>
        /// Neuron, faster than <see cref="Network"/>
        /// </summary>
        Neuron
    }
}