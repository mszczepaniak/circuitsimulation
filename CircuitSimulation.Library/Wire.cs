using System;

namespace CircuitSimulation.Library
{
    public class Wire
    {
        private readonly Input target;
        private readonly Output source;
        private Guid id;
        public Guid Id
        {
            get { return id; }
            set { id = value; }
        }
        public Input Target
        {
            get { return target; }
        }
        public Output Source
        {
            get { return source; }
        }

        // polaczenie kabelkiem source z targetem 
        public static Wire Connect(Output source, Input target)
        {
            source.SignalChanged += () => target.Signal = source.Signal;
            return new Wire(source, target);
        }
        // wire mozemy utworzyc jedynie z poziomu metody Connect 
        private Wire(Output source, Input target)
        {
            this.source = source;
            this.target = target;
        }
    }
}