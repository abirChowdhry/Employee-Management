using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class tblEmployeeRepo : Repo, IRepo<tblEmployee, int, bool, string>
    {
        public bool Insert(tblEmployee employee)
        {
            db.tblEmployees.Add(employee); 
            return db.SaveChanges() > 0;
        }

        public List<tblEmployee> GetAll()
        {
            return db.tblEmployees.ToList();
        }

        public bool GetByEmployeeCode(string EmployeeCode, int EmployeeId)
        {
            var employees = DataAccessFactory.tblEmployeeData().GetAll();
            var data = from e in employees
                       where e.employeeCode == EmployeeCode && e.employeeId != EmployeeId
                       select e;
            if (data.Any()) { return false; }
            return true;
        }

        public tblEmployee Get(int employeeId)
        {
            var data = db.tblEmployees.Find(employeeId);
            return data;
        }

        public List<tblEmployee> Show(int month)
        {
            throw new NotImplementedException();

        }

        public bool Update(tblEmployee employee)
        {
            var exst = Get(employee.employeeId);
            db.Entry(exst).CurrentValues.SetValues(employee);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var data = db.tblEmployees.Find(id);
            db.tblEmployees.Remove(data);
            return db.SaveChanges() > 0;
        }
    }
}
