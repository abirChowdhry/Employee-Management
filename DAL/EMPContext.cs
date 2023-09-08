using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EMPContext : DbContext
    {
        public DbSet<tblEmployee> tblEmployees { get; set; }
        public DbSet<tblEmployeeAttendance> tblEmployeeAttendances { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Token> Tokens { get; set; }
    }
}
