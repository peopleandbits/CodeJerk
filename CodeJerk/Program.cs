using System;
using System.IO;
using System.Linq;

namespace CodeJerk
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var userArgs = CmdLineHelper.CheckArgs(args);
                var asm = AsmLoader.Load(Path.Combine(AsmLoader.AssemblyDirectory, userArgs.AssemblyFileNameWithExtension));
                var types = asm.GetTypes();
                var classes = Class.GetClasses(types);
                var output = ClassDumper.Dump(classes, userArgs.ParameterCountLimit);
                Console.WriteLine(output);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(-1);
            }
        }
    }
}
