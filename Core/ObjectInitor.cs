using Faker.Interfaces;
using System.Reflection;

namespace Faker.Core
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
            var members = obj.GetType().GetMembers()
                .Where(m => m.MemberType == MemberTypes.Field || m.MemberType == MemberTypes.Property);

            // Try to initialize all public members
            foreach (var member in members)
            {
                try
                {
                    switch (member.MemberType)
                    {

                        // Initialize public fields
                        case MemberTypes.Field:
                            {
                                FieldInfo field = (FieldInfo)member;
                                if (Equals(field.GetValue(obj), GetDefaultValue(field.FieldType)))
                                {
                                    field.SetValue(obj, _faker.Create(field.FieldType));
                                }
                            }
                            break;

                        // Initialize public prorepties
                        case MemberTypes.Property:
                            {
                                PropertyInfo prop = (PropertyInfo)member;
                                if (Equals(prop.GetValue(obj), GetDefaultValue(prop.PropertyType)))
                                {
                                    prop.SetValue(obj, _faker.Create(prop.PropertyType));
                                }
                            }
                            break;
                    }
                }
                catch
                {

                }
            }

            return obj;
        }

        public static object? GetDefaultValue(Type type)
        {
            return type.IsValueType ? Activator.CreateInstance(type) : null;
        }
    }
}
