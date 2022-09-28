using Core.Context;
using Core.Interfaces;
using System.Globalization;

namespace Core.Generators
{
    public class DateTimeGenerator : IValueGenerator
    {
        public bool CanGenerate(Type type)
        {
            return type == typeof(DateTime);
        }

        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            int year = context.Random.Next(1, 10000);
            int month = context.Random.Next(1, 13);
            int day = context.Random.Next(1, 29);
            int hour = context.Random.Next(0, 24);
            int minute = context.Random.Next(0, 60);
            int second = context.Random.Next(0, 60);
            DateTimeKind dtKind = DateTimeKind.Utc;
            Calendar dtCal = CultureInfo.InvariantCulture.Calendar;
            int microsecond = context.Random.Next(0, 1000);

            return new DateTime(year, month, day, hour, minute, second, microsecond, dtCal, dtKind);

        }

        public Type GetGeneratedType()
        {
            return typeof(DateTime);
        }
    }
}
