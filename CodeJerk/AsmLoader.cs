using System;
using System.IO;
using System.Reflection;

namespace CodeJerk
{
    public class AsmLoader
    {
        public static Assembly Load(string asmFullPath)
        {
            return Assembly.LoadFile(asmFullPath);
        }

        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                var uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }
    }
}
