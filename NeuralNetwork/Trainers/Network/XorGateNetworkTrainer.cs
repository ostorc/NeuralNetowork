using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NeuralNetwork.Objects;

namespace NeuralNetwork.Trainers.Network
{
    /// <summary>
    /// Xor Gate trainer 
    /// </summary>
    public class XorGateNetworkTrainer : NetworkTrainer
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
        /// Test results
        /// </summary>
        public override double[][] Results { get; } = {
            new double[] {0},
            new double[] {1},
            new double[] {1},
            new double[] {0}
        };

        /// <summary>
        /// Number of inputs
        /// </summary>
        public override int NumberOfInputs { get; } = 2;
        /// <summary>
        /// Number of hidden neurons
        /// </summary>
        public override int NumberOfHiddenNeurons { get; } = 10;
        /// <summary>
        /// Number of outputs
        /// </summary>
        public override int NumberOfOutputs { get; } = 1;

        /// <summary>
        /// Constructor for <see cref="XorGateNetworkTrainer"/>
        /// </summary>
        /// <param name="network">Network which will be teached</param>
        public XorGateNetworkTrainer(ILearnableNetwork network) : base(network)
        {
        }
    }
}