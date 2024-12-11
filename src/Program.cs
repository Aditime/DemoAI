using System;
using System.Collections.Generic;

namespace DemoAI
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataProcessor = new DataProcessor();
            dataProcessor.AddData("John", 25);
            dataProcessor.AddData("Jane", 30);
            dataProcessor.AddData("Bob", 20);

            Console.WriteLine("All data:");
            foreach (var item in dataProcessor.GetData())
            {
                Console.WriteLine($"Name: {item.Key}, Age: {item.Value}");
            }

            Console.WriteLine("\nAverage age:");
            Console.WriteLine(dataProcessor.CalculateAverageAge());
        }
    }

    class DataProcessor
    {
        private Dictionary<string, int> data;

        public DataProcessor()
        {
            data = new Dictionary<string, int>();
        }

        public void AddData(string name, int age)
        {
            if (data.ContainsKey(name))
            {
                Console.WriteLine($"Error: Duplicate entry for {name}");
                return;
            }

            if (age < 0)
            {
                Console.WriteLine("Error: Age cannot be negative");
                return;
            }

            data[name] = age;
        }

        public Dictionary<string, int> GetData()
        {
            return data;
        }

        public double CalculateAverageAge()
        {
            if (data.Count == 0)
            {
                Console.WriteLine("Error: No data available");
                return 0;
            }

            double total = 0;
            foreach (var age in data.Values)
            {
                total += age;
            }

            return total / data.Count;
        }
    }
}