using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NeuralNetwork.Objects;

namespace NeuralNetwork.Trainers.Network
{
    public class XorGateNetworkTrainer : NetworkTrainer
    {
        public override double[][] Inputs { get; } = {
            new double[] {0, 0},
            new double[] {0, 1},
            new double[] {1, 0},
            new double[] {1, 1}
        };

        public override double[][] Results { get; } = {
            new double[] {0},
            new double[] {1},
            new double[] {1},
            new double[] {0}
        };

        public override int NumberOfInputs { get; } = 2;
        public override int NumberOfHiddenNeurons { get; } = 10;
        public override int NumberOfOutputs { get; } = 1;

        public XorGateNetworkTrainer(ILearnableNetwork network) : base(network)
        {
        }
    }
}