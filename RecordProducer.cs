using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Producer
{
    public class RecordProducer
    {
        private IProducerToConsumerAdpt adapter;
        private List<IJSONDataGenerator> generators;
        private static readonly Dictionary<string, IJSONDataGeneratorFactory> typeToFacMap = new Dictionary<string, IJSONDataGeneratorFactory>
        {
            {"double", new DoubleJSONDataGeneratorFactory() },
        };

        public RecordProducer(List<Field> fields, IProducerToConsumerAdpt adpt)
        {
            this.adapter = adpt;
            this.generators = this.MakeGenerators(fields);

        }

        private List<IJSONDataGenerator> MakeGenerators(List<Field> fields)
        {
            List<IJSONDataGenerator> generators = new List<IJSONDataGenerator>();
            fields.ForEach(field => generators.Add(this.MakeGenerator(field)));
            return generators;
        }

        private IJSONDataGenerator MakeGenerator(Field field)
        {
            return typeToFacMap[field.typeID].Make(field.param);
        }

        private JToken MakeRecord()
        {
            JArray record = new JArray();
            generators.ForEach(generator => record.Add(generator.GenerateJsonData()));
            return record;
        }

        private JToken ApplyError(JToken record)
        {
            //TODO: do something here
            return record;
        }
        public void SendRecord()
        {
            
            adapter.Send(this.ApplyError(MakeRecord()));
        }

        
    }
}
