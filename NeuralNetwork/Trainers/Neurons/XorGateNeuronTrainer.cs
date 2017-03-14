using NeuralNetwork.Objects;

namespace NeuralNetwork.Trainers.Neurons
{
    internal class XorGateNeuronTrainer : NeuronTrainer
    {
        public override double[][] Inputs { get; } = {
            new double[] {0, 0},
            new double[] {0, 1},
            new double[] {1, 0},
            new double[] {1, 1}
        };

        public override double[][] Results { get; } =
        {
            new double[] {0},
            new double[] {1},
            new double[] {1},
            new double[] {0}
        };

        public override int NumberOfInputs { get; } = 2;
        public override ActivationFunctionType ActivationFunction { get; } = ActivationFunctionType.Step;

        public XorGateNeuronTrainer(ILearnableNeuron neuron) : base(neuron)
        {
        }
    }
}