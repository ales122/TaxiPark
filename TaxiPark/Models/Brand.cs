using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiPark.Models
{
    public class Brand
    {
        public string Name { get; private set; }

        public Brand(string name)
        {
            this.Name = name;
        }

    }
}
