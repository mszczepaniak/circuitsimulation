using System;

namespace CircuitSimulation.Library
{
    public abstract class Socket
    {
        #region Delegates

        public delegate void SignalChangedEventHandler();

        #endregion

        protected Socket()
        {
            Id = Guid.NewGuid();
        }

        private string name;
        private Signal signal = Signal.Undefined;
        public Guid Id { get; set; }

        protected Socket(string name)
        {
            this.name = name; // useful only for tostring
        }

        public Signal Signal
        {
            get { return signal; }
            set
            {
                Signal oldSignal = signal; // najpierw zapisujemy zmienna jako jakis stary sygnal
                signal = value; // przypisujemy nowa wartosc do sygnalu
                OnSignalChanged(oldSignal, signal); // sprawdzamy czy sygnal sie zmienil = czy trzeba wywolac zdarzenie
            }
        }

        public string Name
        {
            get { return name; }
        }

        // useful for tests
        public override string ToString()
        {
            return name + ":" + Signal;
        }

        public void SetInitialSocketSignal(Signal initialSignal)
        {
            // sets the initial signal without firing the events
            signal = initialSignal;
        }

        // new event 
        public event SignalChangedEventHandler SignalChanged;
        // virtual - can be overridden 
        protected virtual void OnSignalChanged(Signal oldSignal, Signal newSignal)
        {
            // if signals are equal - do nothing
            if (oldSignal.Equals(newSignal))
                return;

            if (SignalChanged != null)
                SignalChanged(); // if signals are not eqal or null - fire event!
        }
    }
}