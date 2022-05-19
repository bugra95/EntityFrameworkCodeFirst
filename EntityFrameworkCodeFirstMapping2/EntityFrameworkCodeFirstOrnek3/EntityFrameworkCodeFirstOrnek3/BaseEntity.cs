using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCodeFirstOrnek3
{
    public class BaseEntity
    {
        // Key isimli attribute ID isimli property'nin primary key olacağı anlamına gelir...
        [Key]
        [Column(Order = 1)]
        public int ID { get; set; }

        // Database'deki sütun sıralamasını belirleriz...
        [Column(Order = 2)]
        public string Name { get; set; }

        // Sütun veri tipini belirleriz...
        [Column(TypeName = "datetime2")]
        public DateTime? AddedDate { get; set; }    // ? ile nullable yaptık...

        public bool IsActive { get; set; }
    }
}
