using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CircuitSimulation.Library.Data;

namespace CircuitSimulation.UI.DesignerControls
{
    public partial class WireControl : UserControl
    {
        private readonly Control parent;
        private readonly InputSocketControl input;
        private readonly OutputSocketControl output;

        private bool isInverted;
        private int actualWidth;
        private int actualHeight;

        public WireControl(Control parent, InputSocketControl input, OutputSocketControl output)
        {
            this.parent = parent;
            this.input = input;
            this.output = output;

            DetermineSizeAndPosition();

            WireId = Guid.NewGuid();

            InitializeComponent();
        }

        public Guid WireId { get; set; }

        public bool IsSimulation { get; set; }

        public void Reposition()
        {
            DetermineSizeAndPosition();
            Invalidate();
        }

        private void DetermineSizeAndPosition()
        {
            var inputOnScreen = Input.Element.PointToScreen(Input.Location);
            var outputOnScreen = Output.Element.PointToScreen(Output.Location);
            var inputPoint = parent.PointToClient(inputOnScreen);
            var outputPoint = parent.PointToClient(outputOnScreen);

            Left = Math.Min(inputPoint.X, outputPoint.X) + Input.Width / 2;
            Top = Math.Min(inputPoint.Y, outputPoint.Y) + Input.Width / 2;

            actualWidth = Math.Abs(inputPoint.X - outputPoint.X);
            actualHeight = Math.Abs(inputPoint.Y - outputPoint.Y);

            Width = Math.Max(actualWidth, 5);
            Height = Math.Max(actualHeight, 5);

            isInverted =
                (outputPoint.X > inputPoint.X && outputPoint.Y < inputPoint.Y) ||
                (outputPoint.X < inputPoint.X && outputPoint.Y > inputPoint.Y);
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

        public InputSocketControl Input
        {
            get { return input; }
        }

        public OutputSocketControl Output
        {
            get { return output; }
        }

        protected override void OnMove(EventArgs e)
        {
            RecreateHandle();
        }

        protected override void OnResize(EventArgs eventargs)
        {
            RecreateHandle();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            if (!IsSimulation)
                DrawForDesigner(e.Graphics);
            else
                DrawForSimulation(e.Graphics);
        }

        private void DrawForDesigner(Graphics graphics)
        {
            DrawLine(graphics, Color.Black);
        }

        private void DrawForSimulation(Graphics graphics)
        {
            var color = Color.Black;

            if (Input.Signal == SignalType.Off)
                color = Color.Teal;
            if (Input.Signal == SignalType.On)
                color = Color.Lime;

            DrawLine(graphics, color);
        }

        private void DrawLine(Graphics graphics, Color color)
        {
            using (var pen = new Pen(color, 2))
            {
                if (!isInverted)
                    graphics.DrawLine(pen, 0, 0, actualWidth, actualHeight);
                else
                    graphics.DrawLine(pen, 0, actualHeight, actualWidth, 0);
            }
        }

        public WireData BuildData()
        {
            var sourceData = Output.BuildData();
            var targetData = Input.BuildData();
            return new WireData
                       {
                           Id = WireId,
                           Source = (OutputData) sourceData,
                           Target = (InputData) targetData
                       };
        }
    }
}
