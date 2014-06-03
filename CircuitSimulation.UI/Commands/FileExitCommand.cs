using System.Windows.Forms;

namespace CircuitSimulation.UI.Commands
{
    public class FileExitCommand : CommandBase
    {
        public override bool IsEnabled
        {
            get { return true; }
        }

        public override string HelpText
        {
            get { return "Exits the application."; }
        }

        public override void Execute()
        {
            Application.Exit();
        }
    }
}