using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class MonthlyReportDTO
    {
        public String employeeName { get; set; }
        public String month { get; set;}
        public int salary { get; set;}
        public int totalPresent { get; set;}
        public int totalAbsent { get; set;}
        public int totalOffday { get; set; }
    }
}
