using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CircuitSimulation.Library;
using CircuitSimulation.Library.Data;

namespace CircuitSimulation.UI.DesignerControls
{
    public partial class FreeOutputControl : FreeSocketControl
    {
        public FreeOutputControl()
        {
            InitializeComponent();
        }

        protected override Image GetImage()
        {
            return Images.outputTrans;
        }

        protected override List<InputSocketControl> CreateInputs()
        {
            var input = new InputSocketControl(this);
            input.Left = 1;
            input.Top = 17;

            var list = new List<InputSocketControl>();
            list.Add(input);
            return list;
        }

        protected override List<OutputSocketControl> CreateOutputs()
        {
            return new List<OutputSocketControl>();
        }

        public override ElementData BuildData()
        {
            return new FreeOutputData
                       {
                           Delay = 0,
                           Id = ElementId,
                           X = Left,
                           Y = Top,
                           Input = (InputData) Inputs[0].BuildData(),
                           Name = SocketName
                       };
        }

        public override void SetData(ElementData elementData)
        {
            var data = (FreeOutputData) elementData;
            ElementId = elementData.Id;
            Inputs[0].SetData(data.Input);
        }
    }
}
