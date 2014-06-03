using CircuitSimulation.Library.Data;

namespace CircuitSimulation.UI.DesignerControls
{
    public partial class InputSocketControl : SocketControl
    {
        public InputSocketControl(CircuitElementControl element) : base(element)
        {
            InitializeComponent();
        }

        private void InputSocketControl_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (IsSimulation)
                return;
            
            if (Designer.OutputToConnect != null)
            {
                var wire = new WireControl(Designer, this, Designer.OutputToConnect);
                Wires.Add(wire);
                Designer.OutputToConnect.Wires.Add(wire);
                Designer.Wires.Add(wire);
                Designer.OutputToConnect.IsSelected = false;
                Designer.OutputToConnect.IsConnected = true;
                Designer.OutputToConnect.Invalidate();
                IsConnected = true;
                Invalidate();
                Designer.Controls.Add(wire);
                Designer.IsModified = true;
            }
        }

        public override SocketData BuildData()
        {
            return new InputData
                       {
                           Id = SocketId,
                           Name = SocketName,
                           Signal = Signal
                       };
        }

        public override void SetData(SocketData socketData)
        {
            SocketId = socketData.Id;
            SocketName = socketData.Name;
            Signal = socketData.Signal;
        }

        public void SetData(InputData data)
        {
            SocketId = data.Id;
            SocketName = data.Name;
        }
    }
}
