using System;
using System.Collections.Generic;
using System.Linq;
using NeuralNetwork.Objects;
using NeuralNetwork.Trainers.Network;
using NeuralNetwork.Trainers.Neurons;

namespace NeuralNetwork.Trainers
{
    public class TrainerManager
    {
        private Dictionary<Tuple<LearningSubject, Type>, Type> trainers { get; }

        public TrainerManager()
        {
            trainers = new Dictionary<Tuple<LearningSubject, Type>, Type>
            {
                {
                    new Tuple<LearningSubject, Type>(LearningSubject.AndGate, typeof(ILearnableNetwork)),
                    typeof(AndGateNetworkTrainer)
                },

                {
                    new Tuple<LearningSubject, Type>(LearningSubject.XorGate, typeof(ILearnableNetwork)),
                    typeof(XorGateNetworkTrainer)
                },

                {
                    new Tuple<LearningSubject, Type>(LearningSubject.AndGate, typeof(ILearnableNeuron)),
                    typeof(AndGateNeuronTrainer)
                },

                {
                    new Tuple<LearningSubject, Type>(LearningSubject.OrGate, typeof(ILearnableNeuron)),
                    typeof(OrGateNeuronTrainer)
                },

                {
                    new Tuple<LearningSubject, Type>(LearningSubject.NotGate, typeof(ILearnableNeuron)),
                    typeof(NotGateNeuronTrainer)
                },
                {
                    new Tuple<LearningSubject, Type>(LearningSubject.Image, typeof(ILearnableNetwork)),
                    typeof(ImageNetworkTrainer)
                }
            };
        }

        public ITrainer GetTrainer(LearningSubject subject, ILearnable learnable)
        {
            var all = learnable.GetType().GetInterfaces();
            var learnableInterfaces =
                all.Except(all.SelectMany(x => x.GetInterfaces()))
                    .Where(x => x.GetInterfaces().Contains(typeof(ILearnable)));
            var res = new List<ITrainer>();
            foreach (Type type in learnableInterfaces)
                res.Add(getTrainer(subject, learnable, type, false));

            return res.First();
        }

        private ITrainer getTrainer(LearningSubject subject, ILearnable learnable, Type type, bool useCache)
        {
            if (trainers.ContainsKey(new Tuple<LearningSubject, Type>(subject, type)))
                return
                    (ITrainer)
                    Activator.CreateInstance(trainers[new Tuple<LearningSubject, Type>(subject, type)], learnable, useCache);

            return null;
        }

        public ITrainer GetTrainer(LearningSubject subject, LearningObject obj)
        {
            return GetTrainer(subject, obj, true);
        }

        public ITrainer GetTrainer(LearningSubject subject, LearningObject obj, bool useCahce)
        {
            Type learnerType = null;
            switch (obj)
            {
                case LearningObject.Network:
                    learnerType = typeof(ILearnableNetwork);
                    break;
                case LearningObject.Neuron:
                    learnerType = typeof(ILearnableNeuron);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(obj), obj, null);
            }


            return getTrainer(subject, null, learnerType, useCahce);
        }
    }
}