using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using CircuitSimulation.Library.Data;

namespace CircuitSimulation.UI.DesignerControls
{
    public abstract partial class SocketControl : UserControl
    {
        private readonly ToolTip toolTip = new ToolTip();
        private readonly CircuitElementControl element;
        private readonly List<WireControl> wires = new List<WireControl>();

        public Guid SocketId { get; set; }
        public SignalType Signal { get; set; }

        public CircuitElementControl Element
        {
            get { return element; }
        }

        public string SocketName
        {
            get { return toolTip.GetToolTip(this); }
            set { toolTip.SetToolTip(this, value); }
        }

        public CircuitControl Designer { get; set; }
        public bool IsSimulation { get; set; }

        public SocketControl(CircuitElementControl element)
        {
            this.element = element;
            InitializeComponent();
            SocketId = Guid.NewGuid();
        }

        public abstract SocketData BuildData();

        public abstract void SetData(SocketData socketData);

        protected override CreateParams CreateParams
        {
            get
            {
                // ustawianie przezroczystości tła
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00000020; //WS_EX_TRANSPARENT

                return cp;
            }
        }

        public bool IsConnected { get; set; }

        public List<WireControl> Wires
        {
            get { return wires; }
        }

        public void ShowWires()
        {
            foreach (var wire in Wires)
            {
                wire.Reposition();
                wire.Show();
            }
        }

        public void HideWires()
        {
            foreach (var wire in Wires)
            {
                wire.Hide();
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // do nothing
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            if (!IsSimulation)
                DrawForDesigner(e.Graphics);
            else
                DrawForSimulation(e.Graphics);
        }

        protected virtual void DrawForDesigner(Graphics graphics)
        {
            var fillBrush = SystemBrushes.Control;

            if (IsConnected)
                fillBrush = new SolidBrush(Color.Black);

            using (var pen = new Pen(Color.Black, 2))
                graphics.DrawEllipse(pen, new Rectangle(5, 5, Width - 8, Height - 8));
            
            graphics.FillEllipse(fillBrush, new Rectangle(6, 6, Width - 10, Height - 10));
        }

        protected virtual void DrawForSimulation(Graphics graphics)
        {
            var fillBrush = Brushes.Black;
            if (Signal == SignalType.Off)
                fillBrush = Brushes.Teal;
            if (Signal == SignalType.On)
                fillBrush = Brushes.Lime;
            
            graphics.FillEllipse(fillBrush, new Rectangle(5, 5, Width - 8, Height - 8));
        }
    }
}
