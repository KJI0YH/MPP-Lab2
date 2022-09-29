using Core.Interfaces;

namespace Core.Core
{
    public class ObjectCreator
    {
        private readonly IFaker _faker;

        public ObjectCreator(IFaker faker)
        {
            _faker = faker;
        }

        public object CreateObject(Type type)
        {
            object? result = null;

            // Get all constructors
            var constructros = type.GetConstructors()
                .OrderByDescending(c => c.GetParameters().Length)
                .ToList();

            // Try to create object with as many parameters as possible
            foreach (var ctor in constructros)
            {
                try
                {
                    // Try to init constructor parameters
                    var args = ctor.GetParameters()
                        .Select(p => p.ParameterType)
                        .Select(_faker.Create)
                        .ToArray();

                    result = ctor.Invoke(args);
                    return result;
                }
                catch
                {
                    continue;
                }
            }

            if (result == null && type.IsValueType)
            {
                result = Activator.CreateInstance(type);
            }

            if (result != null)
            {
                return result;
            }
            else
            {
                throw new FakerException("There are no public constructors");
            }
        }
    }
}
