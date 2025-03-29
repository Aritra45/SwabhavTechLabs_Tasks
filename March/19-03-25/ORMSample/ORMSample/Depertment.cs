using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMSample
{
    internal class Depertment
    {
        [Key]
        public int DeptID { get; set; }
        public string DeptName { get; set; }

    }
}
