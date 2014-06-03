namespace CircuitSimulation.UI.Commands
{
    public class EditDeleteCommand : CommandBase
    {
        private readonly MainForm mainForm;

        public EditDeleteCommand(MainForm mainForm)
        {
            this.mainForm = mainForm;
        }

        public override bool IsEnabled
        {
            get { return mainForm.ActiveDesigner != null; }
        }

        public override string HelpText
        {
            get { return "Deletes selected element."; }
        }

        public override void Execute()
        {
            if (mainForm.ActiveDesigner == null)
                return;

            mainForm.ActiveDesigner.DeleteActiveElement();
        }
    }
}