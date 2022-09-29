using Core.Context;
using Core.Interfaces;

namespace Core.Generators
{
    public class BoolGenerator : IValueGenerator
    {
        public bool CanGenerate(Type type)
        {
            return type == typeof(bool);
        }

        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            return true;
        }

        public Type GetGeneratedType()
        {
            return typeof(bool);
        }
    }
}
