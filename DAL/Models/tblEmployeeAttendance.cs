using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class tblEmployeeAttendance
    {

        [Key]
        public int attendanceId { get; set; }

        [Required]
        public int employeeId { get; set; }

        [Required]
        public DateTime attendanceDate { get; set; }

        [Required]
        public int isPresent { get; set; }

        [Required]
        public int isAbsent { get; set; }

        [Required]
        public int isOffday { get; set; }
    }
}
