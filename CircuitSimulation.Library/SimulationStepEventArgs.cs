using System;

namespace CircuitSimulation.Library
{
    public class SimulationStepEventArgs : EventArgs
    {
        private readonly int currentStep;
        private readonly int totalSteps;

        public SimulationStepEventArgs(int currentStep, int totalSteps)
        {
            this.currentStep = currentStep;
            this.totalSteps = totalSteps;
        }

        public int CurrentStep
        {
            get { return currentStep; }
        }

        public int TotalSteps
        {
            get { return totalSteps; }
        }
    }
}
