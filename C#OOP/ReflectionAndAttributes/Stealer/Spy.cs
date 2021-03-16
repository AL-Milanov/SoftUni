using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {

        public string StealFieldInfo(string nameOfTheClass,params string[] nameOfTheFields)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Class under investigation: {nameOfTheClass}");

            Type type = Type.GetType(nameOfTheClass);
            FieldInfo[] classFields = type.GetFields((BindingFlags)60);

            var classInstance = Activator.CreateInstance(type, new object[] {});

            foreach (var field in classFields.Where(f => nameOfTheFields.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
