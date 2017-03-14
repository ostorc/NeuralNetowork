using System;
using System.IO;

namespace NeuralNetwork
{
    internal static class Helpers
    {
        private static readonly System.Random Rand = new System.Random();

        public static class Random
        {
            public static int Next()
            {
                return Rand.Next();
            }

            public static int Next(int minValue, int maxValue)
            {
                return Rand.Next(minValue, maxValue);
            }

            public static int Next(int maxValue)
            {
                return Rand.Next(maxValue);
            }

            public static double NextDouble()
            {
                return Rand.NextDouble();
            }

            public static void NextBytes(byte[] buffer)
            {
                Rand.NextBytes(buffer);
            }
        }

        public static class ActivationFunction
        {
            public static double Step(double x) => x < 0 ? 0 : 1;
            public static double Sigmoid(double x) => 1 / (1 + Math.Pow(Math.E, -x));
        }

        /// <summary>
        /// Writes the given object instance to a binary file.
        /// <para>Object type (and all child types) must be decorated with the [Serializable] attribute.</para>
        /// <para>To prevent a variable from being serialized, decorate it with the [NonSerialized] attribute; cannot be applied to properties.</para>
        /// </summary>
        /// <typeparam name="T">The type of object being written to the XML file.</typeparam>
        /// <param name="filePath">The file path to write the object instance to.</param>
        /// <param name="objectToWrite">The object instance to write to the XML file.</param>
        /// <param name="append">If false the file will be overwritten if it already exists. If true the contents will be appended to the file.</param>
        public static void WriteToBinaryFile<T>(string filePath, T objectToWrite, bool append = false)
        {
            using (Stream stream = File.Open(filePath, append ? FileMode.Append : FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, objectToWrite);
            }
        }

        /// <summary>
        /// Reads an object instance from a binary file.
        /// </summary>
        /// <typeparam name="T">The type of object to read from the XML.</typeparam>
        /// <param name="filePath">The file path to read the object instance from.</param>
        /// <returns>Returns a new instance of the object read from the binary file.</returns>
        public static T ReadFromBinaryFile<T>(string filePath)
        {
            if (!new FileInfo(filePath).Exists) return default(T);
            using (Stream stream = File.Open(filePath, FileMode.Open))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                return (T)binaryFormatter.Deserialize(stream);
            }
        }
    }
}