using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Producer
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            Console.WriteLine("Please enter an absolute path to config file:\n");
            string? filePath = Console.ReadLine();
            JObject config = ParseConfig(filePath);

            ConfigToFieldsTranslator parser = new ConfigToFieldsTranslator();
            List<Field> fields = parser.Translate(config);
            RecordMaker recordMaker = new RecordMaker(fields);
            JArray record = recordMaker.MakeRecord();

            Console.WriteLine("Console printing: ");
            Console.WriteLine(record.ToString());
            Console.WriteLine("Console exiting...");

            


        }

        private static JObject ParseConfig(string? filePath)
        {
            Console.WriteLine($"Echoing input file path: {filePath}");
            if (String.IsNullOrEmpty(filePath))
            {
                // TODO: Throw exception
                Console.WriteLine("Got empty file path! Start trying default path...");
                filePath = "/Users/caratan/Desktop/Spring 2020/config.json";
            }
            using (StreamReader stream = File.OpenText(filePath))
            using (JsonTextReader reader = new JsonTextReader(stream))
            {
                // FullConfig cfg = new FullConfig(((JObject)JToken.ReadFrom(reader)));
                return (JObject) JToken.ReadFrom(reader);
                // return cfg;
            }
        }
    }
}
