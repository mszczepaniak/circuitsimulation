using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CircuitSimulation.UI
{
    public partial class FormName : Form
    {
        public FormName()
        {
            InitializeComponent();
            Closing += OnClosing;
        }

        public string ElementName
        {
            get { return textBoxName.Text; }
            set { textBoxName.Text = value; }
        }

        public List<string> ExistingNames { get; set; }

        private void OnClosing(object sender, CancelEventArgs cancelEventArgs)
        {
            if (DialogResult != DialogResult.OK || !ExistingNames.Contains(ElementName)) 
                return;

            MessageBox.Show("Element name already exists, please enter other name.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            cancelEventArgs.Cancel = true;
        }
    }
}
