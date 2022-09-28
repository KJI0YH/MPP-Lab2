using Core.Context;
using Core.Interfaces;

namespace Core.Generators
{
    public class ShortGenerator : IValueGenerator
    {
        public bool CanGenerate(Type type)
        {
            return type == typeof(short);
        }

        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            return context.Random.Next(1, short.MaxValue);
        }

        public Type GetGeneratedType()
        {
            return typeof(short);
        }
    }
}
