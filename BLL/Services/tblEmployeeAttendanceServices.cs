using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class tblEmployeeAttendanceServices
    {
        public static bool Insert(tblEmployeeAttendanceDTO Attendance)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<tblEmployeeAttendanceDTO, tblEmployeeAttendance>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<tblEmployeeAttendance>(Attendance);

            return DataAccessFactory.tblEmployeeAttendanceData().Insert(mapped);
        }

        public static string GetMonthName(int month)
        {
            if (month >= 1 && month <= 12)
            {
                DateTimeFormatInfo dtfi = DateTimeFormatInfo.CurrentInfo;
                return dtfi.GetMonthName(month);
            }
            else
            {
                return "Invalid Month Number";
            }
        }

        public static List<MonthlyReportDTO> monthlyReport(int month)
        {
            var attendances = DataAccessFactory.tblEmployeeAttendanceData().Show(month);
            var employees = DataAccessFactory.tblEmployeeData().GetAll();

            var data = employees
                .Select(employee => new MonthlyReportDTO
                {
                    employeeName = employee.employeeName,
                    month = GetMonthName(month),
                    salary = employee.employeeSalary,
                    totalPresent = attendances.Count(a => a.employeeId == employee.employeeId && a.isPresent == 1),
                    totalAbsent = attendances.Count(a => a.employeeId == employee.employeeId && a.isAbsent == 1),
                    totalOffday = attendances.Count(a => a.employeeId == employee.employeeId && a.isOffday == 1)
                })
                .ToList();

            return data;
        }
    }
}
