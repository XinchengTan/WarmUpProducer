using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Producer
{
    // This is a visitor
    public class ConfigToFieldsTranslator
    {

        private readonly Dictionary<string, Func<JObject, Field>> translator = new Dictionary<string, Func<JObject, Field>>();
        private void AddCase(string typeID, Func<JObject, Field> translatorCase)
        {
            translator.Add(typeID, translatorCase);
        }

        private Field CaseAt(string typeID, JObject value)
        {
            return translator[typeID].Invoke(value);
        }

        public ConfigToFieldsTranslator()
        {
            this.AddCase("double", jObject => {
                string name = (string)jObject["name"];
                double mean = (double)jObject["distribution_params"]["mean"];
                FieldParam param = new FieldParam
                {
                    mean = mean
                };
                return new Field("double", name, param);
            });
        }

        // Takes in the whole config JSON file as a JObject and returns a list of Fields
        public List<Field> Translate(JObject config)
        {
            List<Field> fields = new List<Field>();
            foreach(JObject fieldConfig in config["dimension_attributes"])
            {
                string typeID = (string)fieldConfig["type"];
                fields.Add(this.CaseAt(typeID, fieldConfig));
            }
            return fields;
        }
    }
}
