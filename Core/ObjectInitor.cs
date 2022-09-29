﻿using Core.Interfaces;

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
            return obj;
        }

        private static object? GetDefaultValue(Type type)
        {
            return type.IsValueType ? Activator.CreateInstance(type) : null;
        }
    }
}
