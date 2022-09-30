using Faker.Context;
using Faker.Interfaces;

namespace Faker.Generators
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
