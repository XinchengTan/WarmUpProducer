using System;
using System.Collections;
using System.Collections.Generic;

namespace Producer
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            DoubleDataGenerator gen = new DoubleDataGenerator();

            Dictionary<string, IJSONDataGeneratorFactory> dict = new Dictionary<string, IJSONDataGeneratorFactory>();

            dict.Add("double", new DoubleJSONDataGeneratorFactory());


        }
    }
}
