using System;

namespace CodeJerk
{
    public class CmdLineHelper
    {
        public static UserGivenArgs CheckArgs(string[] args)
        {
            if (args == null || args.Length == 0)
                throw new ArgumentException("Assembly filename missing.");

            if (args.Length == 1)
                Console.WriteLine("Parameter count limit not set by user. Setting default 4.");

            int pCountLimit = 4;

            if (args.Length == 2)
            {
                if (!int.TryParse(args[1], out pCountLimit))
                    Console.WriteLine("Invalid parameter count limit. Setting default 4.");
            }

            return new UserGivenArgs()
            {
                AssemblyFileNameWithExtension = args[0],
                ParameterCountLimit = pCountLimit
            };
        }
    }
}
