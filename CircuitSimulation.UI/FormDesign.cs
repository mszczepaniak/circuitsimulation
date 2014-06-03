using System;
using System.IO;
using System.Windows.Forms;
using CircuitSimulation.Library.Data;
using CircuitSimulation.UI.Commands;

namespace CircuitSimulation.UI
{
    public partial class FormDesign : FormBase
    {
        // all commands as the properties
        public SimulateCommand SimulateCommand { get; private set; }

        private string filePath;

        public string FilePath
        {
            get { return filePath; }
            set
            {
                filePath = value;
                RefreshTitle();
            }
        }

        public string ShortFileName
        {
            get { return Path.GetFileName(FilePath); }
        }

        public bool IsModified
        {
            get { return circuitControl1.IsModified; }
            set
            {
                OnModifiedChanged();
                circuitControl1.IsModified = value;
            }
        }

        public bool IsFileNameSet { get; set; }

        public FormDesign()
        {
            InitializeComponent();
            Closing += FormDesign_Closing;

            InitializeCommands();
            circuitControl1.ModifiedChanged += circuitControl1_ModifiedChanged;
        }

        void circuitControl1_ModifiedChanged(object sender, System.EventArgs e)
        {
            RefreshTitle();
            OnModifiedChanged();
        }

        public CircuitData BuildData()
        {
            return circuitControl1.BuildData();
        }

        private void FormDesign_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!IsModified)
                return;

            var result = DialogUtils.ConfirmSavingChanges(MainForm, filePath);

            if (result == DialogResult.Cancel)
                e.Cancel = true;

            if (result == DialogResult.Yes)
                MainForm.FileSaveCommand.Execute();
        }

        private void InitializeCommands()
        {
            SimulateCommand = new SimulateCommand(this);
            BindItem(buttonSimulate, SimulateCommand);
        }

        private void BindItem(ButtonWithImage buttonSimulate, CommandBase command)
        {
            buttonSimulate.Click += (sender, args) => command.Execute();
            buttonSimulate.Enabled = command.IsEnabled;
        }

        private void RefreshTitle()
        {
            Text = "Circuit - " + ShortFileName + (IsModified ? "*" : "");
        }

        private void listView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(listViewElements.SelectedItems[0].Tag, DragDropEffects.Move);
        }

        public void SetCircuitData(CircuitData data)
        {
            circuitControl1.SetCircuitData(data);
        }

        public void DeleteActiveElement()
        {
            circuitControl1.DeleteSelectedElement();
        }

        public event EventHandler ModifiedChanged;

        protected virtual void OnModifiedChanged()
        {
            if (ModifiedChanged != null)
                ModifiedChanged(this, EventArgs.Empty);
        }
    }
}
