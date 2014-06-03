using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using CircuitSimulation.Library.Data;

namespace CircuitSimulation.UI.DesignerControls
{
    public abstract partial class CircuitElementControl : UserControl
    {
        private bool isDragged;
        private Point draggingOffset;

        public List<InputSocketControl> Inputs;
        public List<OutputSocketControl> Outputs;
        public readonly int Delay;
        public CircuitElementControl()
        {
            InitializeComponent();
            ElementId = Guid.NewGuid();
            
            Inputs = CreateInputs();
            Outputs = CreateOutputs();

            foreach (var input in Inputs)
            {
                Controls.Add(input);
            }

            foreach (var output in Outputs)
            {
                Controls.Add(output);
            }
        }

        private CircuitControl designer;
        public CircuitControl Designer
        {
            get { return designer; }
            set
            {
                designer = value;
                foreach (var input in Inputs)
                {
                    input.Designer = designer;
                }
                foreach (var output in Outputs)
                {
                    output.Designer = designer;
                }
            }
        }

        private bool isSimulation;
        public bool IsSimulation
        {
            get { return isSimulation; }
            set
            {
                isSimulation = value;
                foreach (var input in Inputs)
                {
                    input.IsSimulation = isSimulation;
                }
                foreach (var output in Outputs)
                {
                    output.IsSimulation = isSimulation;
                }
            }
        }

        public bool IsSelected
        {
            get { return Designer != null && Designer.SelectedElement == this; }
        }

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

        public Guid ElementId { get; set; }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // tło ma być przezroczyste więc nie wywołujemy metody bazowej
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // narysuj obrazek
            DrawImage(e.Graphics);

            var borderColor = SystemColors.Control;
            var borderDash = DashStyle.Solid;
            if (IsSelected)
            {
                borderColor = Color.Gray;
                borderDash = DashStyle.Dash;
            }
            // narysuj zaznaczenie
            using (var pen = new Pen(borderColor, 1) { DashStyle = borderDash })
            {
                // zaznaczenie jest o jeden piksel węższe i niższe, żeby po odznaczeniu obrazek przykrył ramkę
                var borderRectangle = new Rectangle(0, 0, Width - 2, Height - 2);
                e.Graphics.DrawRectangle(pen, borderRectangle);
            }
        }

        protected virtual void DrawImage(Graphics graphics)
        {
            var controlRectangle = new Rectangle(0, 0, Width - 1, Height - 1);
            graphics.DrawImage(GetImage(), controlRectangle);
        }

        protected abstract Image GetImage();
        protected abstract List<InputSocketControl> CreateInputs();
        protected abstract List<OutputSocketControl> CreateOutputs();

        private void CircuitElementControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (IsSimulation)
                return;

            if (!IsSelected)
            {
                // zaznaczenie tego elementu
                Designer.SelectedElement = this;
            }
            else
            {
                // element był juz zaznaczony - rozpoczęcie przeciągania
                isDragged = true;
                // zapamiętujemy gdzie była mysz w stosunku do tego elementu
                draggingOffset.X = -e.Location.X;
                draggingOffset.Y = -e.Location.Y;

                foreach (var input in Inputs)
                {
                    input.HideWires();
                }

                foreach (var output in Outputs)
                {
                    output.HideWires();
                }
            }
        }

        private void CircuitElementControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsSimulation)
                return;
            
            if (isDragged)
            {
                var dragScreenLocation = PointToScreen(e.Location);
                var dragDesignerLocation = Designer.PointToClient(dragScreenLocation);
                dragDesignerLocation.Offset(draggingOffset);
                Location = dragDesignerLocation;
                Invalidate(true);
                Designer.IsModified = true;
            }
        }

        private void CircuitElementControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (IsSimulation)
                return;

            isDragged = false;

            foreach (var input in Inputs)
            {
                input.ShowWires();
            }

            foreach (var output in Outputs)
            {
                output.ShowWires();
            }

            Designer.Invalidate(true);
        }

        public abstract ElementData BuildData();

        public abstract void SetData(ElementData elementData);

        public InputSocketControl GetInputById(Guid id)
        {
            foreach (var input in Inputs)
            {
                if (input.SocketId == id)
                    return input;
            }

            return null;
        }

        public OutputSocketControl GetOutputById(Guid id)
        {
            foreach (var output in Outputs)
            {
                if (output.SocketId == id)
                    return output;
            }

            return null;
        }
    }
}
