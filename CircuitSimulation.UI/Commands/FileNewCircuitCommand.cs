namespace CircuitSimulation.UI.Commands
{
    public class FileNewCircuitCommand : CommandBase
    {
        private static int newCircuitNumber = 1;

        private readonly MainForm mainForm;
        
        public FileNewCircuitCommand(MainForm mainForm)
        {
            this.mainForm = mainForm;
        }

        public override bool IsEnabled
        {
            get { return true; }
        }

        public override string HelpText
        {
            get { return "Creates a new circuit."; }
        }

        public override void Execute()
        {
            var designer = new FormDesign {MdiParent = mainForm};

            mainForm.AddOpenedDesigner(designer);
            designer.Closed += (sender, args) => mainForm.RemoveOpenedDesigner(designer);

            designer.IsModified = true;
            designer.FilePath = "Untitled " + newCircuitNumber++ + ".cir";

            designer.Show();
        }
    }
}