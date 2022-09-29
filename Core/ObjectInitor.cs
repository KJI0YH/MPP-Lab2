using Core.Interfaces;
using System.Reflection;

namespace Core.Core
{
    public class ObjectInitor
    {
        private readonly IFaker _faker;

        public ObjectInitor(IFaker faker)
        {
            _faker = faker;
        }

        public object InitObject(object obj)
        {

            var fields = obj.GetType().GetFields(BindingFlags.Public);

            return obj;
        }

        private static object? GetDefaultValue(Type type)
        {
            return type.IsValueType ? Activator.CreateInstance(type) : null;
        }
    }
}
