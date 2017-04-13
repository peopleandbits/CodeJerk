using System;
using System.Linq;

namespace CodeJerk
{
    public class Class
    {
        public Class(string name, Method[] methods)
        {
            Name = name;
            Methods = methods;
        }

        public string Name { get; set; }
        public Method[] Methods { get; set; }

        static string[] _NotWantedMethods = new[] { "GetHashCode", "GetType", "Equals", "ToString" };

        public static Class[] GetClasses(Type[] types)
        {
            return types.Where(c => c.IsClass).Select(c => GetClass(c)).ToArray();
        }

        public override string ToString()
        {
            return $"{Name} ({Methods?.Length} methods)";
        }

        static Class GetClass(Type t)
        {
            var methodInfos = t.GetMethods().Where(m => m.IsPublic && !_NotWantedMethods.Contains(m.Name)).ToArray();
            var methods = methodInfos.Select(m => new Method(m.Name, m.GetParameters().Length)).ToArray();
            return new Class(t.Name, methods);
        }
    }
}
