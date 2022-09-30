using Faker.Context;
using Faker.Interfaces;

namespace Faker.Generators
{
    public class CharGenerator : IValueGenerator
    {
        private readonly char[] _chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()_+=-[]{}/\\'\"/|;:`~№<>.,".ToCharArray();

        public bool CanGenerate(Type type)
        {
            return type == typeof(char);
        }

        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            return _chars[context.Random.Next(0, _chars.Length)];
        }

        public Type GetGeneratedType()
        {
            return typeof(char);
        }
    }
}
