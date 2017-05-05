using NeuralNetwork.Objects;

namespace NeuralNetwork.Trainers.Neurons
{
    /// <summary>
    /// And gate neuron trainer
    /// </summary>
    public class AndGateNeuronTrainer : NeuronTrainer
    {
        /// <summary>
        /// Possible inputs
        /// </summary>
        public override double[][] Inputs => new[]
        {
            new double[] {0, 0},
            new double[] {0, 1},
            new double[] {1, 0},
            new double[] {1, 1}
        };
        /// <summary>
        /// Possible results
        /// </summary>
        public override double[][] Results { get; } =
        {
            new double[] {0},
            new double[] {0},
            new double[] {0},
            new double[] {1}
        };
        /// <summary>
        /// Number of inputs
        /// </summary>
        public override int NumberOfInputs { get; } = 2;
        /// <summary>
        /// Activation function
        /// </summary>
        public override ActivationFunctionType ActivationFunction { get; } = ActivationFunctionType.Step;
        /// <summary>
        /// Construcotr for base n
        /// </summary>
        /// <param name="neuron"></param>
        public AndGateNeuronTrainer(ILearnableNeuron neuron) : base(neuron)
        {
        }
    }
}