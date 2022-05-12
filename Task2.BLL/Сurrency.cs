using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.BLL
{
    public class Currency
    {
        public string title { get; set; }
        public double description { get; set; }
        public int quant { get; set; }

        public Currency(string title, double description, int quant)
        {
            this.title = title;
            this.description = description;
            this.quant = quant;
        }
        public Currency() { }
    }
}
