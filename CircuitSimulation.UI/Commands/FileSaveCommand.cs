using System;
using System.IO;
using CircuitSimulation.Library.Data;

namespace CircuitSimulation.UI.Commands
{
    public class FileSaveCommand : CommandBase
    {
        private readonly MainForm mainForm;

        public FileSaveCommand(MainForm mainForm)
        {
            this.mainForm = mainForm;
        }

        public override bool IsEnabled
        {
            get { return mainForm.ActiveDesigner != null && mainForm.ActiveDesigner.IsModified; }
        }

        public override string HelpText
        {
            get { return "Saves circuit."; }
        }

        public override void Execute()
        {
            var designer = mainForm.ActiveDesigner;
            if (!designer.IsModified)
                return;

            if (!designer.IsFileNameSet)
            {
                mainForm.FileSaveAsCommand.Execute();
                return;
            }

            var circuitData = designer.BuildData();

            using (var file = File.Open(designer.FilePath, FileMode.Create, FileAccess.Write))
            {
                CircuitDataWriter.Write(circuitData, file);
            }

            designer.IsModified = false;
        }
    }
}