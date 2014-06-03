using System;

namespace CircuitSimulation.UI.Commands
{
    public abstract class CommandBase
    {
        public abstract bool IsEnabled { get; }
        public abstract string HelpText { get; }
        public abstract void Execute();

        public event EventHandler IsEnabledChanged;

        public void RefreshEnabled()
        {
            OnIsEnabledChanged();
        }

        protected virtual void OnIsEnabledChanged()
        {
            if (IsEnabledChanged != null)
                IsEnabledChanged(this, EventArgs.Empty);
        }
    }
}