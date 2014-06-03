using System.IO;

namespace CircuitSimulation.Console
{
    class ProgramArguments
    {
        public bool AreOk { get; set; }
        public string CircuitFile { get; set; }
        public string OutputSimulationFile { get; set; }

        public static ProgramArguments GetFromCommandLine(string[] args)
        {
            // sprawdz czy sa 2
            if (args.Length != 2)
            {
                System.Console.WriteLine("Error: Wrong argument number");
                return new ProgramArguments {AreOk = false};
            }
            //jesli sa podane w zlej kolejnosci

            //czy istnieje plik
            if (!File.Exists(args[0]))
            {
                System.Console.WriteLine("Error: File {0} does not exists! ", args[0]);
                return new ProgramArguments {AreOk = false};
            }
            //czy targetowy nie istnieje
            if (File.Exists(args[1]))
            {
                System.Console.WriteLine("Error: File {0} exists! ", args[1]);
                return new ProgramArguments {AreOk = false};
            }

            return new ProgramArguments
                       {
                           AreOk = true,
                           CircuitFile = args[0],
                           OutputSimulationFile = args[1]
                       };
        }
    }
}