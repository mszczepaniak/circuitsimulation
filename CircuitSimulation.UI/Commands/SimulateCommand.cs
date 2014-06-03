namespace CircuitSimulation.UI.Commands
{
    public class SimulateCommand : CommandBase
    {
        private readonly FormDesign formDesign;

        public SimulateCommand(FormDesign formDesign)
        {
            this.formDesign = formDesign;
        }

        public override bool IsEnabled
        {
            get { return true; }
        }

        public override string HelpText
        {
            get { return "Simulates created circuit"; }
        }

        public override void Execute()
        {
            var simulationDialog = new FormSimulation();
            var circuitData = formDesign.BuildData();
            simulationDialog.SetData(circuitData);

            simulationDialog.ShowDialog(formDesign.MainForm);
        }
    }
}