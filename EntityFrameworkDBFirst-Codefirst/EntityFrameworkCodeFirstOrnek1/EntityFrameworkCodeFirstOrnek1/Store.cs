using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCodeFirstOrnek1
{
    public class Store
    {
        public int ID { get; set; }
        public string Name { get; set; }

        // bir store'da birden fazla product yer alır...
        public IEnumerable<Product> Products { get; set; }
    }
}
