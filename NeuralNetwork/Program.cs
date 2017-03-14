using System;
using System.Linq;
using NeuralNetwork.MINST.Processing;
using NeuralNetwork.Objects;
using NeuralNetwork.Trainers;
using NeuralNetwork.Trainers.Network;

namespace NeuralNetwork
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            TrainerManager tm = new TrainerManager();

            //ICalculatableNetwork nn2 =
            //    tm.GetTrainer(LearningSubject.AndGate, LearningObject.Network).Train<ICalculatableNetwork>();


            //ICalculatableNeuron n1 =
            //    tm.GetTrainer(LearningSubject.AndGate, LearningObject.Neuron).Train<ICalculatableNeuron>();
            //ICalculatableNeuron n2 =
            //    tm.GetTrainer(LearningSubject.OrGate, LearningObject.Neuron).Train<ICalculatableNeuron>();
            //ICalculatableNetwork nn1 =
            //    tm.GetTrainer(LearningSubject.XorGate, LearningObject.Network).Train<ICalculatableNetwork>();


            ITrainer imageTrainer =
                tm.GetTrainer(LearningSubject.Image, LearningObject.Network);
            var imageNetwork = imageTrainer.Train<ICalculatableNetwork>();

            var d = imageTrainer.GetTestData();

            double succesRate = 0;
            foreach (var pair in d)
            {
                var di = (new DigitImage(pair.Key, (byte)pair.Value.ToList().IndexOf(1)));
                var data = (imageNetwork.Calculate(pair.Key).ToList());
                if (di.Label == data.IndexOf(data.Max())) succesRate += 1.0 / d.Count;
            }
            Console.WriteLine(succesRate);
            //var m = tm.GetTrainer(LearningSubject.XorGate, (ILearnable) nn);
            //var m2 = tm.GetTrainer(LearningSubject.XorGate, LearningObject.Network).Train<ICalculatableNetwork>();
            //var m3 = m2.Calculate(1,1).First();

            //ITrainer andTrainer = new AndGateNeuronTrainer((ILearnableNeuron) n1);
            //ITrainer orTrainer = new OrGateNeuronTrainer((ILearnableNeuron) n2);
            //ITrainer xorNetworkTrainer = new XorGateNetworkTrainer((ILearnableNetwork) nn);


            //andTrainer.Train();
            //orTrainer.Train();
            //// Not posible -> Use multilayer
            //// xorNeuronTrainer.Train();
            //xorNetworkTrainer.Train();

            //Console.WriteLine("----------AND Gate----------");
            //Console.WriteLine($"(1,1) => {n1.Calculate(1, 1)}");
            //Console.WriteLine($"(1,0) => {n1.Calculate(1, 0)}");
            //Console.WriteLine($"(0,1) => {n1.Calculate(0, 1)}");
            //Console.WriteLine($"(0,0) => {n1.Calculate(0, 0)}");
            //Console.WriteLine("----------OR  Gate----------");
            //Console.WriteLine($"(1,1) => {n2.Calculate(1, 1)}");
            //Console.WriteLine($"(1,0) => {n2.Calculate(1, 0)}");
            //Console.WriteLine($"(0,1) => {n2.Calculate(0, 1)}");
            //Console.WriteLine($"(0,0) => {n2.Calculate(0, 0)}");
            //Console.WriteLine("----------XOR  Gate----------");
            //Console.WriteLine($"(1,1) => {nn1.Calculate(1, 1).First()}");
            //Console.WriteLine($"(1,0) => {nn1.Calculate(1, 0).First()}");
            //Console.WriteLine($"(0,1) => {nn1.Calculate(0, 1).First()}");
            //Console.WriteLine($"(0,0) => {nn1.Calculate(0, 0).First()}");
            //Console.WriteLine("----------AND  Gate----------");
            //Console.WriteLine($"(1,1) => {nn2.Calculate(1, 1).First()}");
            //Console.WriteLine($"(1,0) => {nn2.Calculate(1, 0).First()}");
            //Console.WriteLine($"(0,1) => {nn2.Calculate(0, 1).First()}");
            //Console.WriteLine($"(0,0) => {nn2.Calculate(0, 0).First()}");
            //DigitImageLoader loader = new DigitImageLoader("train-images.idx3-ubyte", "train-labels.idx1-ubyte");
            //var data = loader.Load().OrderBy(x=>x.Label);
            //foreach (DigitImage image in data)
            //{
            //    Console.WriteLine(image);
            //    Console.ReadLine();
            //}

            Console.ReadLine();
        }
    }
}