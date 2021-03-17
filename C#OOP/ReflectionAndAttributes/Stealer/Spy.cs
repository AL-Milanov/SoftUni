using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {

        public string StealFieldInfo(string className,params string[] nameOfTheFields)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Class under investigation: {className}");

            Type type = Type.GetType(className);
            FieldInfo[] classFields = type.GetFields((BindingFlags)60);

            var classInstance = Activator.CreateInstance(type, new object[] {});

            foreach (var field in classFields.Where(f => nameOfTheFields.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return sb.ToString().TrimEnd();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            StringBuilder sb = new StringBuilder();
            Type type = Type.GetType(className);
            FieldInfo[] fieldInfos = type.GetFields(BindingFlags.Public | 
                BindingFlags.Instance | 
                BindingFlags.Static);
            MethodInfo[] publicPropertyInfos = type.GetMethods(BindingFlags.Public | 
                BindingFlags.Instance |
                BindingFlags.Static);
            MethodInfo[] privatePropertyInfos = type.GetMethods(BindingFlags.NonPublic | 
                BindingFlags.Instance |
                BindingFlags.Static);

            foreach (var field in fieldInfos)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }
            foreach (var method in privatePropertyInfos.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }
            foreach (var method in publicPropertyInfos.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }


            return sb.ToString().TrimEnd();
        }

        public string RevealPrivateMethods(string className)
        {
            StringBuilder sb = new StringBuilder();

            Type type = Type.GetType(className);
            MethodInfo[] privateMethods = type.GetMethods(BindingFlags.NonPublic |
                BindingFlags.Instance |
                BindingFlags.Static);

            sb.AppendLine($"All Privarte Methods of Class: {className}");
            sb.AppendLine($"Base Class: {type.BaseType.Name}");


            foreach (var method in privateMethods)
            {
                sb.AppendLine(method.Name);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
