using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IOTply.Models
{
    public class LogDetails
    {
        [Key]
        public int LogID { get; set; }
        public string FingerPrintID { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public string Temperature { get; set; }
        public string TempStatus { get; set; }
    }
}
