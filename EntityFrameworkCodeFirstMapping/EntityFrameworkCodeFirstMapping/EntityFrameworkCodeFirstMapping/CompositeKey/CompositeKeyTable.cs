using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCodeFirstMapping
{
    public class CompositeKeyTable
    {
        [Key, Column(Order = 1)]
        public int TestID { get; set; }

        [Key, Column(Order = 2)]
        public int DemoID { get; set; }
    }
}
