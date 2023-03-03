using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class Product
    {
        private string name;
        private string category;
        private int price;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Category
        {
            get { return category; }
            set { category = value; }
        }
        public int Price
        {
            get { return price; }
            set { price = value; }
        }
        public override string ToString()
        {
            return $"{Name} [{Category}]: {Price}";
        }
    }
}
