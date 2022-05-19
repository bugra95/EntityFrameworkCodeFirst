using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCodeFirstMapping
{
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }

        // Students-Teachers tabloları arasında many-to-many relation (çoka çok ilişki) vardır. Bunun sağlanmasını her iki sınıfa da liste koyarak yapabiliriz...
        public virtual List<Teacher> Teachers { get; set; }
    }
}
