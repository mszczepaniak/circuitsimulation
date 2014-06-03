using System;

namespace CircuitSimulation.UI.Commands
{
    public class EditCopyCommand : CommandBase
    {
        private readonly MainForm mainForm;

        public EditCopyCommand(MainForm mainForm)
        {
            this.mainForm = mainForm;
        }

        public override bool IsEnabled
        {
            get { return false; }
        }

        public override string HelpText
        {
            get { return "Copies selected element"; }
        }

        public override void Execute()
        {
            
        }
    }
}