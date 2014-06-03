using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CircuitSimulation.UI.Commands;

namespace CircuitSimulation.UI
{
    public partial class MainForm : FormBase
    {
        private readonly List<FormDesign> openDesigners = new List<FormDesign>();

        public FormDesign ActiveDesigner
        {
            get { return ActiveMdiChild as FormDesign; }
        }

        public FormSimulation ActiveSimulation
        {
            get { return ActiveMdiChild as FormSimulation; }
        }

        // all commands as the properties
        public FileNewCircuitCommand FileNewCircuitCommand { get; private set; }
        public FileOpenCircuitCommand FileOpenCircuitCommand { get; private set; }
        public FileSaveCommand FileSaveCommand  { get; private set; }
        public FileSaveAsCommand FileSaveAsCommand { get; private set; }
        public FileExitCommand FileExitCommand { get; private set; }
        public EditCutCommand EditCutCommand { get; private set; }
        public EditCopyCommand EditCopyCommand { get; private set; }
        public EditPasteCommand EditPasteCommand { get; private set; }
        public EditDeleteCommand EditDeleteCommand { get; private set; }
        public ToolsOptionsCommand ToolsOptionsCommand { get; private set; }
        public HelpAboutCommand HelpAboutCommand { get; private set; }

        public MainForm()
        {
            InitializeComponent();
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            FileNewCircuitCommand = new FileNewCircuitCommand(this);
            BindMenuItem(newToolStripMenuItem, FileNewCircuitCommand);

            FileOpenCircuitCommand = new FileOpenCircuitCommand(this);
            BindMenuItem(openToolStripMenuItem, FileOpenCircuitCommand);

            FileSaveCommand = new FileSaveCommand(this);
            BindMenuItem(saveToolStripMenuItem, FileSaveCommand);

            FileSaveAsCommand = new FileSaveAsCommand(this);
            BindMenuItem(saveAsToolStripMenuItem, FileSaveAsCommand);

            FileExitCommand = new FileExitCommand();
            BindMenuItem(exitToolStripMenuItem, FileExitCommand);

            EditCutCommand = new EditCutCommand(this);
            BindMenuItem(cutToolStripMenuItem, EditCutCommand);

            EditCopyCommand = new EditCopyCommand(this);
            BindMenuItem(copyToolStripMenuItem, EditCopyCommand);

            EditPasteCommand = new EditPasteCommand(this);
            BindMenuItem(pasteToolStripMenuItem, EditPasteCommand);

            EditDeleteCommand = new EditDeleteCommand(this);
            BindMenuItem(deleteToolStripMenuItem, EditDeleteCommand);

            ToolsOptionsCommand = new ToolsOptionsCommand(this);
            BindMenuItem(optionsToolStripMenuItem, ToolsOptionsCommand);

            HelpAboutCommand = new HelpAboutCommand(this);
            BindMenuItem(aboutToolStripMenuItem, HelpAboutCommand);

            MdiChildActivate += (sender, args) => RefreshCommandEnabled();
        }

        private void BindMenuItem(ToolStripItem toolStripMenuItem, CommandBase command)
        {
            toolStripMenuItem.Click += (sender, args) => command.Execute();
            toolStripMenuItem.MouseEnter += (sender, args) => SetStatus(command.HelpText);
            toolStripMenuItem.MouseLeave += (sender, args) => ClearStatus();
            toolStripMenuItem.Enabled = command.IsEnabled;
            command.IsEnabledChanged += (sender, args) => toolStripMenuItem.Enabled = command.IsEnabled;
        }

        private void SetStatus(string text)
        {
            statusStrip1.Items[0].Text = text;
        }

        private void ClearStatus()
        {
            statusStrip1.Items[0].Text = "";
        }

        public void AddOpenedDesigner(FormDesign form)
        {
            openDesigners.Add(form);
            form.ModifiedChanged += AfterModifiedChanged;
        }

        public void RemoveOpenedDesigner(FormDesign form)
        {
            openDesigners.Remove(form);
            form.ModifiedChanged -= AfterModifiedChanged;
        }

        private void RefreshCommandEnabled()
        {
            FileSaveCommand.RefreshEnabled();
            FileSaveAsCommand.RefreshEnabled();
            EditCutCommand.RefreshEnabled();
            EditCopyCommand.RefreshEnabled();
            EditPasteCommand.RefreshEnabled();
            EditDeleteCommand.RefreshEnabled();
        }

        private void AfterModifiedChanged(object sender, EventArgs args)
        {
            RefreshCommandEnabled();
        }
    }
}
