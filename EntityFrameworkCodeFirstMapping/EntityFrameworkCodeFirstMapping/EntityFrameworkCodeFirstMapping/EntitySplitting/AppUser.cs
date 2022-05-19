using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCodeFirstMapping
{
    public class AppUser
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }

        // User için tek bir tablo oluşturmak yerine, bu tabloyu 2 tabloya ayıracağız. Tablolardan birinde kullanıcı hakkında bağlantı bilgilerini tutarken, diğerinde hesap bilgilerini tutuyor olacağız. Bunu Context class'ı içerisinde OnModelCreating() metodunu override ederek sağlayacağız. Bu ayar sonucunda 1'e 1 bağlanmış iki tablo oluşturulmuş olacak. Fakat C# tarafında hala tek bir class objesi üzerinden işlemler yapılacak...
    }
}
