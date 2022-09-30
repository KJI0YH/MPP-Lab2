using Faker.Context;
using Faker.Interfaces;

namespace Faker.Generators
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
