namespace CircuitSimulation.UI.Commands
{
    public class ToolsOptionsCommand : CommandBase
    {
        private readonly MainForm mainForm;

        public ToolsOptionsCommand(MainForm mainForm)
        {
            this.mainForm = mainForm;
        }
        public override bool IsEnabled
        {
            get { return true; }
        }
        public override string HelpText
        {
            get { return "Displays the Options window."; }
        }
        public override void Execute()
        {
            var optionsDialog = new FormOptions();
            optionsDialog.ShowDialog(mainForm);
        }
    }
}