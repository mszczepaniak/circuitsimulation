using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CircuitSimulation.Library.Data;

namespace CircuitSimulation.UI.DesignerControls
{
    public partial class GeneratorControl : CircuitElementControl
    {
        public GeneratorControl()
        {
            InitializeComponent();
        }

        public bool IsOn { get; set; }

        protected override Image GetImage()
        {
            return Images.generatorTrans;
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
            return new GeneratorData
                    {
                        Delay = this.Delay,
                        Id = ElementId,
                        Type = ElementType.Generator,
                        X = Left,
                        Y = Top,
                        Output = (OutputData) outputData
                    };

        }

        public override void SetData(ElementData elementData)
        {
            var data = (GeneratorData)elementData;
            ElementId = data.Id;
            Outputs[0].SetData(data.Output);
        }
    }
}
