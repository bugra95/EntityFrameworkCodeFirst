using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCodeFirstMapping
{
    public class EmployeeContactDetail
    {
        public int EmployeeID { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public Employee Employee { get; set; }

        // Table splitting, birden fazla entity'nin SQL üzerinde tek bir tabloda olmasını sağlar...
    }
}
