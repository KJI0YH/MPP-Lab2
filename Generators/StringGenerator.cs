using Core.Context;
using Core.Interfaces;

namespace Core.Generators
{
    public class StringGenerator : IValueGenerator
    {
        private readonly string _dict = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()_+=-[]{}/\\'\"/|;:`~№<>.,";

        public bool CanGenerate(Type type)
        {
            return type == typeof(string);
        }

        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            int lenght = context.Random.Next(8, 100);
            string result = string.Empty;
            for (int i = 0; i < lenght; i++)
            {
                result += _dict[context.Random.Next(0, _dict.Length)];
            }
            return result;
        }

        public Type GetGeneratedType()
        {
            return typeof(string);
        }
    }
}
