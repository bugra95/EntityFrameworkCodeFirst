using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCodeFirstOrnek4
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [MaxLength(50)]
        [Required]
        public string ProductName { get; set; }

        public short? UnitsInStock { get; set; }

        public decimal? UnitPrice { get; set; }

        public int CategoryID { get; set; }

        // Bir ürüne ait bir kategori olur ilişkisi... Foreign key yaptık...
        public virtual Category Category { get; set; }
    }
}
