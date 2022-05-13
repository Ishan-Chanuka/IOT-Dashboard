using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IOTply.Models
{
    public class EmployeeReg
    {
        [Key]
        public int EmpID { get; set; }
        public int FingerPrintID { get; set; }
        public string EmpName { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
        public string Post { get; set; }
        public string UserType { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
