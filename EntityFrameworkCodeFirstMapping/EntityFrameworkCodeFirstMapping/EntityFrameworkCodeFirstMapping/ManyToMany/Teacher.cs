using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCodeFirstMapping
{
    public class Teacher
    {
        public int TeacherID { get; set; }
        public string TeacherName { get; set; }

        // Students-Teachers tabloları arasında many-to-many relation (çoka çok ilişki) vardır. Bunun sağlanmasını her iki sınıfa da liste koyarak yapabiliriz...
        public virtual List<Student> Students { get; set; }
    }
}
