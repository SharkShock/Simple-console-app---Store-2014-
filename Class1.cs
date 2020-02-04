using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppStore
{
    //Ovo bi trebalo da bude poseban file(.cs), desni klik na ConsoleAppStore Add/new Item/Class => pa mu das ime Product i to je to, napravice novi Product.cs file koji koristis normalno :)
    public class Product
    {
        //_____________________________________________________________

        public string Name { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }

        //_____________________________________________________________

        //Ovo ti se zove konstruktor klase i on se poziva svaki put kad mu pozoves new (napravis objekat). P.s bravo za to :)
        public Product(string name, decimal cost, int instock)
        {
            this.Name = name;
            this.Price = cost;
            this.InStock = instock;
        }


        //_____________________________________________________________
    }
}
