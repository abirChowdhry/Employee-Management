using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class tblEmployeeServices
    {
        public static bool Insert(tblEmployeeDTO Employee)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<tblEmployeeDTO, tblEmployee>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<tblEmployee>(Employee);

            return DataAccessFactory.tblEmployeeData().Insert(mapped);
        }

        public static bool Update(tblEmployeeDTO Employee)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<tblEmployeeDTO, tblEmployee>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<tblEmployee>(Employee);

            var existingEmployeeCode = DataAccessFactory.tblEmployeeData().GetByEmployeeCode(mapped.employeeCode, mapped.employeeId);

            if (existingEmployeeCode == true)
            {
                return DataAccessFactory.tblEmployeeData().Update(mapped);
            }
            return false;
        }

        public static tblEmployeeDTO GetThirdHighestSalary()
        {
            var employees = DataAccessFactory.tblEmployeeData().GetAll();

            var thirdHighestSalary = employees
                .OrderByDescending(e => e.employeeSalary)
                .Skip(2)
                .Take(1)
                .FirstOrDefault();

            if (thirdHighestSalary != null)
            {
                var cfg = new MapperConfiguration(c => {
                    c.CreateMap<tblEmployee, tblEmployeeDTO>();
                });
                var mapper = new Mapper(cfg);
                var mapped = mapper.Map<tblEmployeeDTO>(thirdHighestSalary);
                return mapped;
            }
            else
            {
                return null;
            }
        }

        public static List<tblEmployeeDTO> MaxToMinByAbsent()
        {
            var employees = DataAccessFactory.tblEmployeeData().GetAll();
            var absent = DataAccessFactory.tblEmployeeAttendanceData().GetAll();

            var data = employees
                .Where(e => !absent.Any(a => a.employeeId == e.employeeId && a.isAbsent == 1)) 
                .OrderByDescending(e => e.employeeSalary) 
                .ToList();

            var cfg = new MapperConfiguration(c => {
                c.CreateMap<tblEmployee, tblEmployeeDTO>();
            });

            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<tblEmployeeDTO>>(data);

            return mapped;
        }

        public static List<string> employeeHierarchy(int id)
        {
            var employee = DataAccessFactory.tblEmployeeData().Get(id);

            var hierarchy = new List<string>();

            while (employee != null)
            {
                var cfg = new MapperConfiguration(c => {
                    c.CreateMap<tblEmployee, tblEmployeeDTO>();
                });
                var mapper = new Mapper(cfg);
                var mapped = mapper.Map<tblEmployeeDTO>(employee);

                hierarchy.Add(mapped.employeeName);

                employee = DataAccessFactory.tblEmployeeData().Get(employee.supervisorId);
            }

            return hierarchy;
        }

    }
}
