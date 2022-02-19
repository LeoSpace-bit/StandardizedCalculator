namespace StandardizedCalculator.Integration
{
    public class Accumulator
    {
        public double Value { get; private set; } = 0;

        public void Add(double x) => Value += x;
    }
}