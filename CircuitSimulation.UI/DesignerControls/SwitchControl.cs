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
    public partial class SwitchControl : CircuitElementControl
    {
        public SwitchControl()
        {
            InitializeComponent();
        }

        public bool IsOn { get; set; }

        protected override Image GetImage()
        {
            if (!IsSimulation || !IsOn)
                return Images.switchOffTrans;
            return Images.switchOnTrans;
        }

        protected override List<InputSocketControl> CreateInputs()
        {
            return new List<InputSocketControl>();
        }

        protected override List<OutputSocketControl> CreateOutputs()
        {
            var output = new OutputSocketControl(this) { Left = 98, Top = 22 };
            var result = new List<OutputSocketControl>();
            result.Add(output);
            return result;
        }

        public override ElementData BuildData()
        {
            var outputData = Outputs[0].BuildData();
            return new SwitchData
                       {
                           Delay = this.Delay,
                           Id = ElementId,
                           Type = ElementType.Switch,
                           X = Left,
                           Y = Top,
                           Output = (OutputData) outputData
                       };
        }

        public override void SetData(ElementData elementData)
        {
            var data = (SwitchData) elementData;
            ElementId = data.Id;
            Outputs[0].SetData(data.Output);
        }

        private void SwitchControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (!IsSimulation)
                return;

            IsOn = !IsOn;
            Invalidate(true);
        }
    }
}
