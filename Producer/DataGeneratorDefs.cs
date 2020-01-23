using System;
using System.Collections.Generic;
using NumSharp;

namespace Producer

{

    public interface IDataGenerator<T>
    {

        List<T> Make(int amount);

    }

    public class IntegerDataGenerator : IDataGenerator<int>
    {
        private static readonly double DEFAULT_MEAN = 0.0;
        private static readonly double DEFAULT_STANDARD_DEVIATION = 20.0;

        public IntegerDataGenerator(double mean, double standardDeviation)
        {
            this.Mean = mean;
            this.StandardDeviation = standardDeviation;
        }

        public IntegerDataGenerator(double mean) : this(mean, DEFAULT_STANDARD_DEVIATION) { }

        public IntegerDataGenerator() : this(DEFAULT_MEAN) { }

        public double Mean { get; private set; }

        public double StandardDeviation { get; set; }

        public List<int> Make(int amount)
        {
            // Dummy result
            var data = np.random.normal(this.Mean, this.StandardDeviation, amount);
            var data2 = data.ToArray<double>();


            List<int> processedData = new List<int>();

            // var h = hi.ToList<double>();
            foreach (double x in data2)
            {
                processedData.Add((int) x);
            }

            return processedData;
        }

    }

    public abstract class AErrorGenerator<T, U> : IDataGenerator<U>
    {
        private static readonly double DEFAULT_ERROR_RATE = 0.05;

        public double ErrorRate { get; private set; }

        public IDataGenerator<T> DataGenerator { get; private set; }

        protected AErrorGenerator(double errorRate, IDataGenerator<T> dataGenerator)
        {
            this.ErrorRate = errorRate;
            this.DataGenerator = dataGenerator;
        }

        protected AErrorGenerator(IDataGenerator<T> dataGenerator) : this(DEFAULT_ERROR_RATE, dataGenerator) { }

        public abstract List<U> Make(int amount);
        
    }

    public class NullErrorGenerator<T> : AErrorGenerator<T, T?>
    {
        public NullErrorGenerator(double errorRate, IDataGenerator<T> dataGenerator) : base(errorRate, dataGenerator) { }

        public NullErrorGenerator(IDataGenerator<T> dataGenerator) : base(dataGenerator) { }

        public override List<T?> Make(int amount)
        {
            List<T?> data = this.DataGenerator.Make(amount);

            // Object is not nullable so we have to change something in the definition of this method
            // It's supposed to be List<Object?> but it's not compiling I haven't figured out why yet
            // data[0] = null;


            return data;

        }
    }





}

