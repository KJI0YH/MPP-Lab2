using Core.Context;
using Core.Interfaces;
using System.Collections;

namespace Core.Generators
{
    public class ListGenerator : IValueGenerator
    {
        public bool CanGenerate(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>);
        }

        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            int length = context.Random.Next(1, 6);
            IList? list = (IList?)Activator.CreateInstance(typeToGenerate, length);
            if (list != null)
            {
                for (int i = 0; i < length; i++)
                {
                    list.Add(context.Faker.Create(typeToGenerate.GetGenericArguments()[0]));
                }
            }

            return list;
        }

        public Type GetGeneratedType()
        {
            return typeof(List<>);
        }
    }
}
