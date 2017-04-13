using System.Linq;
using System.Text;

namespace CodeJerk
{
    public class ClassDumper
    {
        public static string Dump(Class[] klasses, int pCountLimit = 999)
        {
            var sb = new StringBuilder();
            sb.Clear();

            foreach (var k in klasses)
            {
                if (!HasMethodsPassingLimit(k, pCountLimit))
                    continue;

                sb.AppendLine($"{k.Name}:");
                sb.AppendLine(Dump(k, pCountLimit));
            }

            return sb.ToString();
        }

        static string Dump(Class klass, int pCountLimit = 999)
        {
            var sb = new StringBuilder();

            var sorted = GetSortedMethods(klass, pCountLimit);

            foreach (var m in sorted)
                sb.AppendLine(m.ToString());

            return sb.ToString();
        }

        static Method[] GetSortedMethods(Class klass, int limit)
        {
            return klass.Methods.OrderByDescending(c => c.ParamCount).Where(c => c.ParamCount >= limit).ToArray();
        }

        static bool HasMethodsPassingLimit(Class klass, int limit = 999)
        {
            return GetSortedMethods(klass, limit).Any();
        }
    }
}
