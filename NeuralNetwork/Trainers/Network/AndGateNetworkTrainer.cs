using NeuralNetwork.Objects;

namespace NeuralNetwork.Trainers.Network
{
    /// <summary>
    /// Trainer of And Gate functionality
    /// </summary>
    public class AndGateNetworkTrainer : NetworkTrainer
    {
        /// <summary>
        /// Test inputs
        /// </summary>
        public override double[][] Inputs { get; } = {
            new double[] {0, 0},
            new double[] {0, 1},
            new double[] {1, 0},
            new double[] {1, 1}
        };

        /// <summary>
        /// Test outputs
        /// </summary>
        public override double[][] Results { get; } = {
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
        /// Number of hidden neurons
        /// </summary>
        public override int NumberOfHiddenNeurons { get; } = 3;
        /// <summary>
        /// Number of outputs
        /// </summary>
        public override int NumberOfOutputs { get; } = 1;

        /// <summary>
        /// Constructor of And Gate Netowrk Trainer
        /// </summary>
        /// <param name="network">Netowork which will be teached</param>
        public AndGateNetworkTrainer(ref ILearnableNetwork network) : base(network)
        {
        }
    }
}