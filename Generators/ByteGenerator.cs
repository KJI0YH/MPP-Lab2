using Core.Context;
using Core.Interfaces;

namespace Core.Generators
{
    public class ByteGenerator : IValueGenerator
    {
        public bool CanGenerate(Type type)
        {
            return type == typeof(byte);
        }

        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            return context.Random.Next(1, byte.MaxValue);
        }

        public Type GetGeneratedType()
        {
            return typeof(byte);
        }
    }
}
