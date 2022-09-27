using Core.Context;
using Core.Interfaces;

namespace Core.Core
{
    public class Faker : IFaker
    {
        private readonly GeneratorContext _generatorContext;
        private readonly List<IValueGenerator> _valueGenerators;

        public Faker()
        {
            _generatorContext = new GeneratorContext(new Random(), this);
            //_valueGenerators = 
        }

        public T Create<T>()
        {
            return (T)CreateInstance(typeof(T));
        }

        private object CreateInstance(Type type)
        {

        }
    }
}
