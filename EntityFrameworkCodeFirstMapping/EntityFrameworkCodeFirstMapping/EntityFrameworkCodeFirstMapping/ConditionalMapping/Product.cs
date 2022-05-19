using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCodeFirstMapping
{
    public class Product
    {
        public int ID { get; set; }
        public bool IsOnSale { get; set; }
        public string ProductName { get; set; }
        public decimal? Price { get; set; }
        public short? UnitsInStock { get; set; }
        public string QuantityPerUnit { get; set; }
        public int CategoryID { get; set; }

        public virtual Category Category { get; set; }


        public override string ToString()
        {
            return $"{ProductName} | {IsOnSale}";
        }

        // Context class'ı içerisinde OnModelCreating() metodunu override ederek mapping esnasında IsOnSale sütunu üzerinden bir koşul belirleyeceğiz. Bu koşul ile ürün listesi getirilirken IsOnSale = false olan kısımlar gelmeyecek. Bunu şu şekilde de düşünebiliriz: SQL'e select * from Products dediğimizde SQL otomatik olarak bu sorguyu select * from Products where IsOnSale = 1 ifadesine çevirecektir...
    }
}
