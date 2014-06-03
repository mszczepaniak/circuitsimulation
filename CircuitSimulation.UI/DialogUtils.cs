using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CircuitSimulation.UI
{
    public static class DialogUtils
    {
        public static DialogResult ConfirmSavingChanges(MainForm mainForm, string fileName)
        {
            var title = "Confirm saving changes";
            var text = "Save changes to the following file?\n" + fileName;
            return MessageBox.Show(mainForm, text, title, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
        }

        public static bool OpenFile(MainForm mainForm, out string fileName)
        {
            var dialog = new OpenFileDialog();
            dialog.AddExtension = true;
            dialog.AutoUpgradeEnabled = true;
            dialog.CheckFileExists = true;
            dialog.DefaultExt = "cir";
            dialog.Multiselect = false;
            dialog.ShowReadOnly = false;
            dialog.Title = "Open circuit file";
            dialog.Filter = "Circuit files (*.cir)|*.cir|All files (*.*)|*.*";

            if (dialog.ShowDialog(mainForm) == DialogResult.OK)
            {
                fileName = dialog.FileName;
                return true;
            }

            fileName = null;
            return false;
        }

        public static bool SaveFile(MainForm mainForm, out string fileName)
        {
            var dialog = new SaveFileDialog();
            dialog.AddExtension = true;
            dialog.AutoUpgradeEnabled = true;
            dialog.CheckPathExists = true;
            dialog.DefaultExt = "cir";
            dialog.Title = "Save circuit file";
            dialog.Filter = "Circuit files (*.cir)|*.cir|All files (*.*)|*.*";

            if (dialog.ShowDialog(mainForm) == DialogResult.OK)
            {
                fileName = dialog.FileName;
                return true;
            }

            fileName = null;
            return false;
        }

        public static void ShowOpenFileError(MainForm mainForm, string fileName, string message)
        {
            var title = "Error opening file";
            var text = "Unable to read circuit data from file\n" + fileName + "\n" + message;
            MessageBox.Show(mainForm, text, title, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }

        public static bool AskForName(Control owner, string initialName, List<string> existingNames, out string name)
        {
            var form = new FormName();
            form.ElementName = initialName;
            form.ExistingNames = existingNames;
            if (form.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(form.ElementName))
            {
                name = form.ElementName;
                return true;
            }

            name = null;
            return false;
        }
    }
}