using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CircuitSimulation.Library.Data;

namespace CircuitSimulation.UI.DesignerControls
{
    public abstract partial class FreeSocketControl : CircuitElementControl
    {
        private ToolTip toolTip = new ToolTip();
        public FreeSocketControl()
        {
            InitializeComponent();
            Width = 60;
            Height = 60;
        }

        public string SocketName
        {
            get { return toolTip.GetToolTip(this); }
            set { toolTip.SetToolTip(this, value); }
        }

        protected override void DrawImage(Graphics graphics)
        {
            var controlRectangle = new Rectangle(10, 10, Width - 21, Height - 21);
            graphics.DrawImage(GetImage(), controlRectangle);
        }

        private void FreeSocketControl_DoubleClick(object sender, System.EventArgs e)
        {
            string socketName;
            if (DialogUtils.AskForName(Designer, SocketName, Designer.SocketNames, out socketName))
                SocketName = socketName;
        }
    }
}
