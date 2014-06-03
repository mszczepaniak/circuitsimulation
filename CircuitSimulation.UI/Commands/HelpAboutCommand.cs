namespace CircuitSimulation.UI.Commands
{
    public class HelpAboutCommand : CommandBase
    {
        private readonly MainForm mainForm;

        public HelpAboutCommand(MainForm mainForm)
        {
            this.mainForm = mainForm;
        }

        public override bool IsEnabled
        {
            get { return true; }
        }

        public override string HelpText
        {
            get { return "Displays the About window."; }
        }

        public override void Execute()
        {
            var aboutDialog = new FormAbout();
            aboutDialog.ShowDialog(mainForm);
        }
    }
}