using Core.Context;
using Core.Interfaces;

namespace Core.Generators
{
    public class IntGenerator : IValueGenerator
    {
        public bool CanGenerate(Type type)
        {
            return type == typeof(int);
        }

        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            return context.Random.Next(1, int.MaxValue);
        }

        public Type GetGeneratedType()
        {
            return typeof(int);
        }
    }
}
