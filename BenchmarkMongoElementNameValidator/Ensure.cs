using System;

namespace BenchmarkMongoElementNameValidator
{
    public static class Ensure
    {
        public static T IsNotNull<T>(T value, string paramName) where T : class
        {
            if (value == null)
            {
                throw new ArgumentNullException(paramName, "Value cannot be null.");
            }
            return value;
        }
    }
}
