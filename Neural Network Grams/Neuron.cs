using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural_Network_Grams
{
    class Neuron
    {
        private decimal weight = 0.5m;
        public decimal LastError { get; private set; }
        public decimal Smoothing { get; set; } = 0.01m;

        private Neuron()
        {

        }

        private static readonly Neuron _neuron = new Neuron();

        public static Neuron GetNeuron()
        {
            return _neuron;
        }

        public decimal ProcessInputData(decimal input)
        {
            return input * weight;
        }

        public decimal RestoreInputData(decimal output)
        {
            return output / weight;
        }

        public void Train(decimal input, decimal expectedResult)
        {
            var actualResult = input * weight;
            LastError = expectedResult - actualResult;
            var correction = (LastError / actualResult) * Smoothing;
            weight += correction;
        }
    }
}
