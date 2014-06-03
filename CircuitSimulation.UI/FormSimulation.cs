using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CircuitSimulation.Library;
using CircuitSimulation.Library.Data;
using CircuitSimulation.UI.Commands;
using CircuitSimulation.UI.DesignerControls;

namespace CircuitSimulation.UI
{
    public partial class FormSimulation : FormBase
    {
        public FormSimulation()
        {
            InitializeComponent();
        }

        public void SetData(CircuitData data)
        {
            simulationControl.SetData(data);

            backgroundWorker.DoWork += backgroundWorker_DoWork;
            backgroundWorker.ProgressChanged += backgroundWorker_ProgressChanged;
            backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            progressBarSimulation.Show();
            buttonStart.Enabled = false;
            var circuitData = simulationControl.BuildData();
            backgroundWorker.RunWorkerAsync(circuitData);
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var simulator = new CircuitSimulator((CircuitData) e.Argument);

            simulator.SimulationStep += simulator_SimulationStep; 
            var results = simulator.Simulate(simulationControl.GetSwitchStates(), simulationControl.GetGeneratorStates());
            e.Result = results;
        }

        void simulator_SimulationStep(object sender, SimulationStepEventArgs e)
        {
            var progressPercent = (e.CurrentStep * 100)/e.TotalSteps;

            if (progressPercent != 0 && progressPercent % 10 == 0) // co 10%
                backgroundWorker.ReportProgress(progressPercent);
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBarSimulation.Value = e.ProgressPercentage;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBarSimulation.Hide();
            progressBarSimulation.Value = 0;

            var simulationData = (SimulationData) e.Result;
            listBoxEvents.Items.Clear();
            
            foreach (var evnt in simulationData.Events)
            {
                listBoxEvents.Items.Add(evnt.Description);
            }

            HandleDiodeFinalStates(simulationData.Events);
            HandleSocketFinalStates(simulationData.Events);
            simulationControl.Invalidate(true);

            buttonStart.Enabled = true;
        }

        private void HandleSocketFinalStates(List<EventData> events)
        {
            foreach (var eventData in events)
            {
                if (eventData is InputChangedData)
                {
                    var evnt = (InputChangedData) eventData;
                    var found = simulationControl.SetInputState(evnt.InputId, evnt.NewSignal);
                    if (!found) throw new ApplicationException("Cannot find input " + evnt.InputId);
                }
                if (eventData is OutputChangedData)
                {
                    var evnt = (OutputChangedData) eventData;
                    var found = simulationControl.SetOutputState(evnt.OutputId, evnt.NewSignal);
                    if (!found) throw new ApplicationException("Cannot find output " + evnt.OutputId);
                }
            }
        }

        private void HandleDiodeFinalStates(List<EventData> events)
        {
            foreach (var eventData in events)
            {
                if (eventData is LightChangedData)
                {
                    var lightChangedData = (LightChangedData) eventData;
                    simulationControl.SetDiodeState(lightChangedData.DiodeId, lightChangedData.IsLightOn);
                }
            }
        }
    }
}
