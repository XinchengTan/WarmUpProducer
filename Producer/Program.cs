using System;

namespace Producer
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            IntegerDataGenerator gen = new IntegerDataGenerator();
            NullErrorGenerator<int> errgen = new NullErrorGenerator<int>(gen);
            var data = errgen.Make(10);
            data.ForEach(x => Console.WriteLine(x.ToString()));
            // errgen.Make(10);
            // Console.WriteLine(np.random.normal(0.0, 1.0, 10).ToString());
        }
    }
}
