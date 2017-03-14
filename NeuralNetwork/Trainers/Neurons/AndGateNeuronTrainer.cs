using NeuralNetwork.Objects;

namespace NeuralNetwork.Trainers.Neurons
{
    public class AndGateNeuronTrainer : NeuronTrainer
    {
        public override double[][] Inputs => new[]
        {
            new double[] {0, 0},
            new double[] {0, 1},
            new double[] {1, 0},
            new double[] {1, 1}
        };

        public override double[][] Results { get; } =
        {
            new double[] {0},
            new double[] {0},
            new double[] {0},
            new double[] {1}
        };

        public override int NumberOfInputs { get; } = 2;
        public override ActivationFunctionType ActivationFunction { get; } = ActivationFunctionType.Step;

        public AndGateNeuronTrainer(ILearnableNeuron neuron) : base(neuron)
        {
        }
    }
}