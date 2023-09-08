using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class tblEmployee
    {
        [Key]
        public int employeeId { get; set; }

        [Required]
        [StringLength(30)]
        public string employeeName { get; set; }

        [Required]
        public string employeeCode { get; set; }

        [Required]
        public int employeeSalary { get; set; }

        [Required]
        public int supervisorId { get; set; }
    }
}