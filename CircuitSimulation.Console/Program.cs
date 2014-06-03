using System.Collections.Generic;
using CircuitSimulation.Library;
using CircuitSimulation.Library.Data;

namespace CircuitSimulation.Console
{
    class Program
    {
        /// <summary>
        /// console application that enables simulation
        /// </summary>
        /// <param name="args">
        /// 0 - File that has saved circuit to xml
        /// 1 - File in which simulation results will be saved
        /// </param>
        static void Main(string[] args)
        {
            var arguments = ProgramArguments.GetFromCommandLine(args);
            if (arguments.AreOk)
            {
                Run(arguments);
            }
            else
            {
                PrintUsage();
            }

            System.Console.WriteLine("Press any key to continue...");
            System.Console.ReadKey(true);
        }

        private static void Run(ProgramArguments arguments)
        {
            try
            {
                var circuitData = CircuitDataReader.ReadFromFile(arguments.CircuitFile);

                var simulator = new CircuitSimulator(circuitData);
                var simulationData = simulator.Simulate(new List<InitialSwitchState>(), new List<InitialGeneratorState>());

                var writer = new SimulationDataWriter(simulationData);
                writer.WriteToFile(simulationData, arguments.OutputSimulationFile);
            }
            catch (SimulationException exception)
            {
                System.Console.WriteLine("Error while producing simulation:");
                System.Console.WriteLine(exception.ToString());
            }
        }

        static void PrintUsage()
        {
            System.Console.WriteLine("-----------------------------------------------------");
            System.Console.WriteLine("Usage: CircuitSimulation.Console circuit_file output");
            System.Console.WriteLine("circuit_file - File that has saved circuit to xml");
            System.Console.WriteLine("output - File in which simulation results will be saved");
        }
    }
}
