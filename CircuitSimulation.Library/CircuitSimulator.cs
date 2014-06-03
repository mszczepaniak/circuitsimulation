using System;
using System.Collections.Generic;
using CircuitSimulation.Library.CircuitBuilders;
using CircuitSimulation.Library.Data;
using CircuitSimulation.Library.SimulationResultsBuilders;

namespace CircuitSimulation.Library
{
    public class CircuitSimulator
    {
        private readonly CircuitData circuitData;
        private readonly int totalSteps = 10000;
        private int currentStep;

        public CircuitSimulator(CircuitData circuitData)
        {
            this.circuitData = circuitData;
        }

        public SimulationData Simulate(List<InitialSwitchState> initialSwitchStates, List<InitialGeneratorState> initialGeneratorStates)
        {
            var simulation = new Simulation(totalSteps); 
            var builder = new CircuitBuilder(circuitData, simulation);
            var circuit = builder.BuildCircuit();
            circuit.SetSwiches(initialSwitchStates);
            circuit.SetGenerators(initialGeneratorStates);
            var results = RunSimulation(simulation);
            return results;
        }

        private SimulationData RunSimulation(Simulation simulation)
        {
            while (simulation.ShouldContinue)
            {
                simulation.SimulateNextTimeframe();
                currentStep++;
                OnSimulationStep();
            }

            var builder = new SimulationDataBuilder(simulation.ProcessedEvents);
            return builder.BuildResults();
        }

        protected virtual void OnSimulationStep()
        {
            if (SimulationStep != null)
                SimulationStep(this, new SimulationStepEventArgs(currentStep, totalSteps));
        }

        public event EventHandler<SimulationStepEventArgs> SimulationStep;
    }
}