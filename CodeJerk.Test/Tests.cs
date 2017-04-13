using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace CodeJerk.Test
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void Class_GetClasses()
        {
            var classes = GetTestClasses();

            Assert.AreEqual(2, classes.Length);

            Assert.AreEqual(2, classes[0].Methods.Length);
            Assert.AreEqual(2, classes[0].Methods[0].ParamCount);
            Assert.AreEqual(5, classes[0].Methods[1].ParamCount);

            Assert.AreEqual(3, classes[1].Methods.Length);
            Assert.AreEqual(0, classes[1].Methods[0].ParamCount);
            Assert.AreEqual(8, classes[1].Methods[1].ParamCount);
            Assert.AreEqual(2, classes[1].Methods[2].ParamCount);
        }

        [TestMethod]
        public void ClassDumper_Dump()
        {
            Assert.IsNotNull(ClassDumper.Dump(GetTestClasses()));
        }

        [TestMethod]
        public void CmdLineHelper_GoodArgs()
        {
            var result = CmdLineHelper.CheckArgs(new[] { "TestDll.dll", "1" });
            Assert.AreEqual("TestDll.dll", result.AssemblyFileNameWithExtension);
            Assert.AreEqual(1, result.ParameterCountLimit);
        }

        [TestMethod]
        public void CmdLineHelper_BadArgs()
        {
            ExpectException<ArgumentException>(() => CmdLineHelper.CheckArgs(null));
            ExpectException<ArgumentException>(() => CmdLineHelper.CheckArgs(new string[] { }));
        }

        static Class[] GetTestClasses()
        {
            var userArgs = new UserGivenArgs() { AssemblyFileNameWithExtension = "TestDll.dll", ParameterCountLimit = 1 };
            var asm = AsmLoader.Load(Path.Combine(AsmLoader.AssemblyDirectory, userArgs.AssemblyFileNameWithExtension));
            var types = asm.GetTypes();
            var classes = Class.GetClasses(types);
            return classes;
        }

        static void ExpectException<T>(Action action) where T : Exception
        {
            try
            {
                action();
                Assert.Fail("Expected exception " + typeof(T));
            }
            catch (T)
            {
                // Expected
            }
        }
    }
}