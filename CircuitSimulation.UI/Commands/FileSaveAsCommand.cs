using System;

namespace CircuitSimulation.UI.Commands
{
    public class FileSaveAsCommand : CommandBase
    {
        private readonly MainForm mainForm;

        public FileSaveAsCommand(MainForm mainForm)
        {
            this.mainForm = mainForm;
        }

        public override bool IsEnabled
        {
            get { return mainForm.ActiveDesigner != null; }
        }

        public override string HelpText
        {
            get { return "Saves Circuit as..."; }
        }

        public override void Execute()
        {
            var designer = mainForm.ActiveDesigner;
            if (!designer.IsModified)
                return;

            string fileName;
            if (!DialogUtils.SaveFile(mainForm, out fileName)) 
                return;

            designer.FilePath = fileName;
            designer.IsFileNameSet = true;
            mainForm.FileSaveCommand.Execute();
        }
    }
}