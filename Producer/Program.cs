using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Producer
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            JObject config = new JObject();
            ConfigToFieldsTranslator parser = new ConfigToFieldsTranslator();
            List<Field> fields = parser.Translate(config);
            RecordMaker recordMaker = new RecordMaker(fields);
            JArray record = recordMaker.MakeRecord();


        }
    }
}
