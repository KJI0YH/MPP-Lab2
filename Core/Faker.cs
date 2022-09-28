using Core.Context;
using Core.Interfaces;

namespace Core.Core
{
    public class Faker : IFaker
    {
        private readonly GeneratorContext _generatorContext;
        private readonly Dictionary<Type, IValueGenerator> _valueGenerators = new();

        public Faker()
        {
            _generatorContext = new GeneratorContext(new Random(), this);

            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(t => t.GetTypes())
                .Where(i => typeof(IValueGenerator).IsAssignableFrom(i));

            foreach (var type in types)
            {
                IValueGenerator? generator = (IValueGenerator?)Activator.CreateInstance(type);

                if (generator != null)
                {
                    _valueGenerators.Add(generator.GetGeneratedType(), generator);
                }
            }

        }

        public T Create<T>()
        {
            return (T)CreateInstance(typeof(T));
        }

        public object Create(Type type)
        {
            return CreateInstance(type);
        }

        private object CreateInstance(Type type)
        {
            // check cycle dependency
            // create object
            // init object

            return new object();
        }
    }
}
