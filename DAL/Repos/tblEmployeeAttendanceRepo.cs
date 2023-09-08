using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class tblEmployeeAttendanceRepo : Repo, IRepo<tblEmployeeAttendance, int, bool, string>
    {
        public bool Insert(tblEmployeeAttendance employeeAttendance)
        {
            db.tblEmployeeAttendances.Add(employeeAttendance);
            return db.SaveChanges() > 0;
        }

        public List<tblEmployeeAttendance> GetAll()
        {
            return db.tblEmployeeAttendances.ToList();
        }

        public bool GetByEmployeeCode(string employeeCode, int EmployeeId)
        {
            throw new NotImplementedException();
        }

        public tblEmployeeAttendance Get(int id)
        {
            var data = db.tblEmployeeAttendances.Find(id);
            return data;
        }

        public List<tblEmployeeAttendance> Show(int month)
        {
            var attendances = DataAccessFactory.tblEmployeeAttendanceData().GetAll();

            var data = from a in attendances
                       where a.attendanceDate.Month == month
                       select a;
            return data.ToList();
        }

        public bool Update(tblEmployeeAttendance employeeAttendance)
        {
            var exst = Get(employeeAttendance.employeeId);
            db.Entry(exst).CurrentValues.SetValues(employeeAttendance);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var data = db.tblEmployeeAttendances.Find(id);
            db.tblEmployeeAttendances.Remove(data);
            return db.SaveChanges() > 0;
        }
    }
}
