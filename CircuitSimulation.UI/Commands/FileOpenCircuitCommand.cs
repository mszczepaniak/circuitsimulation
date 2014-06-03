using System;
using System.Windows.Forms;
using CircuitSimulation.Library;
using CircuitSimulation.Library.Data;

namespace CircuitSimulation.UI.Commands
{
    public class FileOpenCircuitCommand : CommandBase
    {
        private readonly MainForm mainForm;

        public FileOpenCircuitCommand(MainForm mainForm)
        {
            this.mainForm = mainForm;
        }

        public override bool IsEnabled
        {
            get { return true; }
        }

        public override string HelpText
        {
            get { return "Opens existing circuit"; }
        }

        public override void Execute()
        {
            string fileName;
            if (!DialogUtils.OpenFile(mainForm, out fileName))
                return;

            var data = ReadData(fileName);
            if (data == null)
            {
                return;
            }

            var designer = new FormDesign();
            designer.MdiParent = mainForm;
            designer.SetCircuitData(data);

            mainForm.AddOpenedDesigner(designer);
            designer.Closed += (sender, args) => mainForm.RemoveOpenedDesigner(designer);

            designer.IsModified = false;
            designer.FilePath = fileName;
            designer.IsFileNameSet = true;

            designer.Show();
        }

        private CircuitData ReadData(string fileName)
        {
            try
            {
                return CircuitDataReader.ReadFromFile(fileName);
            }
            catch(SimulationException e)
            {
                DialogUtils.ShowOpenFileError(mainForm, fileName, e.InnerException.Message);
                return null;
            }
        }
    }
}