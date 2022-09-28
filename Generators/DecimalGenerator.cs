using Core.Context;
using Core.Interfaces;

namespace Core.Generators
{
    public class DecimalGenerator : IValueGenerator
    {
        public bool CanGenerate(Type type)
        {
            return type == typeof(decimal);
        }

        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            int lo = context.Random.Next(0, int.MaxValue);
            int mid = context.Random.Next(0, int.MaxValue);
            int hi = context.Random.Next(0, int.MaxValue);
            bool isNegative = context.Random.Next(0, 2) == 1;
            byte scale = (byte)context.Random.Next(0, 29);
            return new decimal(lo, mid, hi, isNegative, scale);

        }
    }
}
