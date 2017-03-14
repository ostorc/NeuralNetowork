using NeuralNetwork.Objects;

namespace NeuralNetwork.Trainers.Neurons
{
    internal class NotGateNeuronTrainer : NeuronTrainer
    {
        public override double[][] Inputs { get; } = {
            new double[] {1},
            new double[] {0}
        };

        public override double[][] Results { get; } =
        {
            new double[] {0},
            new double[] {1}
        };

        public override int NumberOfInputs { get; } = 1;
        public override ActivationFunctionType ActivationFunction { get; } = ActivationFunctionType.Step;

        public NotGateNeuronTrainer(ILearnableNeuron neuron) : base(neuron)
        {
        }
    }
}