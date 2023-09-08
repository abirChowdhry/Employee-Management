using DAL.Interfaces;
using DAL.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class DataAccessFactory
    {
        public static IRepo<tblEmployee, int, bool, string> tblEmployeeData()
        {
            return new tblEmployeeRepo();
        }

        public static IRepo<tblEmployeeAttendance, int, bool, string> tblEmployeeAttendanceData()
        {
            return new tblEmployeeAttendanceRepo();
        }

        public static IRepo<User, string, User, int> UserData()
        {
            return new UserRepo();
        }

        public static IAuth<bool> AuthData()
        {
            return new UserRepo();
        }

        public static IRepo<Token, string, Token, int> TokenData()
        {
            return new TokenRepo();
        }

    }
}
