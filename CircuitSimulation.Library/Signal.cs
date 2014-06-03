using System;
using CircuitSimulation.Library.Data;

namespace CircuitSimulation.Library
{

    // base class for SignalOn, SignalOff, SignalUndefined
    public abstract class Signal
    {
        public abstract bool IsOn { get; }

        public abstract bool IsUndefined { get; }
        public abstract Signal Not { get; }

        public static Signal On
        {
            get { return new SignalOn(); }
        }

        public static Signal Off
        {
            get { return new SignalOff(); }
        }

        public static Signal Undefined
        {
            get { return new SignalUndefined(); }
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (ReferenceEquals(this, obj)) return true;
            return GetType() == obj.GetType();
        }

        // when overriding Equals one needs to override GetHashCode also
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public abstract Signal And(Signal otherSignal);

        public abstract Signal Or(Signal otherSignal);
        // nand = not after and
        public Signal Nand(Signal otherSignal)
        {
            return And(otherSignal).Not;
        }

        // nor = not after or
        public Signal Nor(Signal otherSignal)
        {
            return Or(otherSignal).Not;
        }

        public Signal Exor(Signal otherSignal)
        {
            return (And(otherSignal.Not)).Or(Not.And(otherSignal));
        }

        public Signal Exnor(Signal otherSignal)
        {
            return (And(otherSignal)).Or(Not.And(otherSignal.Not));
        }

        // method that is needed for testing 
        public static Signal FromInt(int value)
        {
            switch (value)
            {
                case 0:
                    return Off;
                case 1:
                    return On;
                default:
                    throw new ArgumentOutOfRangeException("Cannot create signal from " + value);
            }
        }

        public static Signal FromSignalType(SignalType signal)
        {
            switch (signal)
            {
                case SignalType.On:
                    return On;
                case SignalType.Off:
                    return Off;
                case SignalType.Undefined:
                    return Undefined;
                default:
                    throw new ArgumentOutOfRangeException("signal");
            }
        }

        public abstract SignalType GetSignalType();
    }
    // signal turned on
    public class SignalOn : Signal
    {
        // IsOn is always true
        public override bool IsOn
        {
            get { return true; }
        }

        //IsUndefined is always false
        public override bool IsUndefined
        {
            get { return false; }
        }

        //Return Off Signal because initial signal is ON.
        public override Signal Not
        {
            get { return new SignalOff(); }
        }

        // Return other Signal, when other signal is on, and is on, when off, and is off
        public override Signal And(Signal otherSignal)
        {
            return otherSignal;
        }

        // Return On signal, because initial signal is On
        public override Signal Or(Signal otherSignal)
        {
            return new SignalOn();
        }

        public override SignalType GetSignalType()
        {
            return SignalType.On;
        }

        // useful for testing
        public override string ToString()
        {
            return "On";
        }
    }

    // signal turned off
    public class SignalOff : Signal
    {
        // initial signal is Off, that is why IsOn property always return false
        public override bool IsOn
        {
            get { return false; }
        }

        // initial signal is Off, IsUndefined is always false
        public override bool IsUndefined
        {
            get { return false; }
        }

        // initial signal is off, so not returns signal On as a contrary
        public override Signal Not
        {
            get { return new SignalOn(); }
        }

        // initial signal is off, so and return signal
        public override Signal And(Signal otherSignal)
        {
            return new SignalOff();
        }

        // initial signal is off, so or returns other signal, when other signal is off, or is off, when on then on.
        public override Signal Or(Signal otherSignal)
        {
            return otherSignal;
        }

        public override SignalType GetSignalType()
        {
            return SignalType.Off;
        }

        // useful for testing
        public override string ToString()
        {
            return "Off";
        }
    }

    // signal undefined
    public class SignalUndefined : Signal
    {
        // initial signal is undefined, IsOn property returns always false
        public override bool IsOn
        {
            get { return false; }
        }

        // initial signal is undefined, IsUndefined property returns always true
        public override bool IsUndefined
        {
            get { return true; }
        }

        // not ,  and , or return undefined on undefined signal
        public override Signal Not
        {
            get { return this; }
        }

        public override Signal And(Signal otherSignal)
        {
            return this;
        }

        public override Signal Or(Signal otherSignal)
        {
            return this;
        }

        public override SignalType GetSignalType()
        {
            return SignalType.Undefined;
        }

        // useful for testing 
        public override string ToString()
        {
            return "Undefined";
        }
    }
}