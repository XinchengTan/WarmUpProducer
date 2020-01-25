using System;
namespace Producer
{
    // Same as DimentionAttribute
    public struct Field
    {
        public readonly string name;
        public readonly string typeID;
        public readonly FieldParam param;
        
    }

    public struct FieldParam
    {
        public readonly double? mean;
        public readonly double? standard_deviation;
        public readonly int? max_len;

        // TODO: add all possible args

    }

    

    //public class FullConfig
    //{
    //    public int threads_count { get; }
    //    public int records_count { get; }
    //    public double error_rate { get; }
    //    public List<DimensionAttribute> dimension_attributes { get; }

    //    public FullConfig(JObject jConfig)
    //    {
    //        this.threads_count = (int)jConfig["threads_count"];
    //        this.records_count = (int)jConfig["records_count"];
    //        this.error_rate = (double)jConfig["error_rate"];
    //        this.dimension_attributes = ((JArray)jConfig["dimension_attributes"]).ToObject<List<DimensionAttribute>>();
    //    }
    //}

    //public struct DimensionAttribute
    //{
    //    string? name;
    //    string? type;
    //    JObject? dim_parameters; // TODO: Seems sketchy to leave JObject here and rely on producer to correctly access it
    //}
}
