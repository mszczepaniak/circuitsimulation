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
    public partial class DiodeControl : CircuitElementControl
    {
        public DiodeControl()
        {
            InitializeComponent();
        }

        private bool isOn;
        public bool IsOn
        {
            get { return isOn; }
            set
            {
                isOn = value;
                Invalidate(true);
            }
        }

        protected override Image GetImage()
        {
            if (!IsSimulation || !IsOn)
                return Images.diode;
            return Images.diodeOn;
        }

        protected override List<InputSocketControl> CreateInputs()
        {
            var input = new InputSocketControl(this) { Left = 0, Top = 20 };
            var result = new List<InputSocketControl>();
            result.Add(input);
            return result;
        }

        protected override List<OutputSocketControl> CreateOutputs()
        {
            return new List<OutputSocketControl>();
        }

        public override ElementData BuildData()
        {
            var inputData = Inputs[0].BuildData();

            return new DiodeData
                       {
                           Delay = this.Delay,
                           Id = ElementId,
                           Input = (InputData) inputData,
                           X = Left,
                           Y = Top
                       };
        }

        public override void SetData(ElementData elementData)
        {
            var data = (DiodeData) elementData;
            ElementId = elementData.Id;
            Inputs[0].SetData(data.Input);
        }
    }
}
