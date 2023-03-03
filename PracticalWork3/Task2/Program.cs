using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using System;
namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate<Product> predicate = FindCategory;
            for (int i = 1; i <= 10; i++)
            {
                string path = $@"E:\knute\oop\laboratory9\PracticalWork3\Task2\files\{i}.json";

                List<Product> products = JsonConvert.DeserializeObject<List<Product>>(File.ReadAllText(path));
                Console.WriteLine("All products in file:");
                foreach (Product product in products)
                {
                    Console.WriteLine(product);
                }
                Console.WriteLine();
                Console.WriteLine("Filter products by category:");
                List<Product> filteredProducts = products.FindAll(predicate);
                foreach (Product product in filteredProducts)
                {
                    Console.WriteLine(product);
                }
                Console.WriteLine();
            }
        }
        static bool FindCategory(Product p)
        {
            return p.Category == "Vegetable";
        }

    }
}