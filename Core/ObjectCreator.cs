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
            // get all constructors
            // try to init object with many parameters
            // else - another constructor

            // init all fields
            // recursion
            // check cycle dependency?
        }
    }
}
