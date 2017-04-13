namespace CodeJerk
{
    public class Method
    {
        public Method(string name, int pCount)
        {
            Name = name;
            ParamCount = pCount;
        }

        public string Name { get; set; }
        public int ParamCount { get; set; }

        public override string ToString()
        {
            return $"{Name} ({ParamCount} parameters)";
        }
    }
}
