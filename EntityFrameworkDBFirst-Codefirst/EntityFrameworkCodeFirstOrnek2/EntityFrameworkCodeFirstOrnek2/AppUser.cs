using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCodeFirstOrnek2
{
    // Tablonun database'deki adını belirledik...
    [Table("Users")]
    public class AppUser : BaseEntity
    {
        // nvarchar(30)'a çevirir. Yani bu kolonun en fazla 30 karakter alacağını belirtmiş oluruz. Eğer bu attribute'u vermezsek, bu kolon nvarchar(MAX) olarak tanımlanacak...
        [MaxLength(30)]
        public string LastName { get; set; }

        // not null bir sütun oluşturur. Zorunlu alan demektir...
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool Gender { get; set; }
    }
}
