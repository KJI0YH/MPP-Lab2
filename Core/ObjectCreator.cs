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
            // Get all constructors
            var constructros = type.GetConstructors()
                .OrderByDescending(c => c.GetParameters().Length)
                .ToList();

            // Try to init object with as many parameters as possible
            foreach (var ctor in constructros)
            {
                try
                {
                    var parameters = ctor.GetParameters()
                        .Select(t => t.ParameterType)
                        .Select(_faker.Create)
                        .ToArray();

                    return ctor.Invoke(parameters);
                }
                catch
                {

                }
            }

            //throw new NoPublicConstructorsException



            // init all fields
            // recursion
            // check cycle dependency?
        }
    }
}
