using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Lab12
{
    static class Reflector
    {
        static public string GetAssemblyInfo(Type t)
        {
            Assembly a = t.Assembly;
            return a.GetName().Name;
        }

        static public  bool IsPublishConstructors(Type t)
        {
            var constructors = t.GetConstructors();

            if (constructors.Length > 0) return true;

            return false;
        }

        static public IEnumerable<string> GetMetodsInfo(Type t)
        {
            var metods = from i in t.GetMethods() select i.Name;
            return metods;
        }

        static public IEnumerable<string> GetFieldInfo(Type t)
        {
            var fields = from i in t.GetFields() select i.Name;
            return fields;
        }

        static public IEnumerable<string> GetInterfaceInfo(Type t)
        {
            var fields = from i in t.GetInterfaces() select i.Name;
            return fields;
        }

        static public void OutputMetodsNameFromParamType(Type t)
        {
            Console.WriteLine("Eneter parameter type ...");
            string paramType = Console.ReadLine();
            var metods = t.GetMethods();
            var resultMetods = from i in metods where 
                               (from c in i.GetParameters() select c.ParameterType.Name).Contains(paramType) select i.Name;
            foreach (var i in resultMetods)
                Console.WriteLine(i);
        }

        static public object CreateExample(Type t)
        {
            object obj = Activator.CreateInstance(t);
            return obj;
        }

        static public void Invoke(object t, string metodName, object[] arr)
        {
            MethodInfo m = t.GetType().GetMethod(metodName);
            m.Invoke(t, arr);
        }
    }
}
