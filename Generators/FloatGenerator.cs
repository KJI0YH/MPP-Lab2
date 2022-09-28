using Core.Context;
using Core.Interfaces;

namespace Core.Generators
{
    public class FloatGenerator : IValueGenerator
    {
        public bool CanGenerate(Type type)
        {
            return type == typeof(float);
        }

        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            return context.Random.NextSingle();
        }

        public Type GetGeneratedType()
        {
            return typeof(float);
        }
    }
}
