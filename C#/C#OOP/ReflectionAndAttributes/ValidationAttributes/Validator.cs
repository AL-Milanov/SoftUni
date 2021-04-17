using System.Linq;
using System.Reflection;
using ValidationAttributes.Attributes;

namespace ValidationAttributes
{
    static class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] properties = obj.GetType().GetProperties();

            foreach (var property in properties)
            {
                MyValidationAttribute[] attributes = property.GetCustomAttributes()
                    .Cast<MyValidationAttribute>()
                    .ToArray();

                var value = property.GetValue(obj);

                foreach (var attribute in attributes)
                {
                    var isValid = attribute.IsValid(value);

                    if (isValid == false)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
