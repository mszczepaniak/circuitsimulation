using System.Drawing;
using System.Drawing.Drawing2D;
using CircuitSimulation.Library.Data;

namespace CircuitSimulation.UI.DesignerControls
{
    public partial class OutputSocketControl : SocketControl
    {
        public bool IsSelected { get; set; }

        public OutputSocketControl(CircuitElementControl element) : base(element)
        {
            InitializeComponent();
        }

        protected override void DrawForDesigner(Graphics graphics)
        {
            if (IsSelected)
            {
                graphics.FillEllipse(Brushes.Blue, new Rectangle(5, 5, Width - 8, Height - 8));
                return;
            }

            base.DrawForDesigner(graphics);
        }

        private void OutputSocketControl_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (IsSimulation)
                return;
            
            if (Designer.OutputToConnect != null && Designer.OutputToConnect != this)
            {
                Designer.OutputToConnect.IsSelected = false;
                Designer.OutputToConnect.Invalidate(true);
            }

            IsSelected = true;
            IsConnected = true;
            Designer.OutputToConnect = this;
            Invalidate(true);
        }

        public override SocketData BuildData()
        {
            return new OutputData
                       {
                           Id = SocketId,
                           Name = SocketName,
                           Signal = Signal
                       };
        }

        public override void SetData(SocketData data)
        {
            SocketId = data.Id;
            SocketName = data.Name;
            Signal = data.Signal;
        }
    }
}
