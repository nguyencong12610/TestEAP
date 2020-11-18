﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EmployeeManagerServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmployeeManager" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EmployeeManager.svc or EmployeeManager.svc.cs at the Solution Explorer and start debugging.
    public class EmployeeManager : IEmployeeManager
    {
        EmpployeeManagerDataContext data = new EmpployeeManagerDataContext(); 
        public bool AddDepartment(Department department)
        {
            try
            {
                data.Departments.InsertOnSubmit(department);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool AddEmployee(Employee employee)
        {
            try
            {
                data.Employees.InsertOnSubmit(employee);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteDepartment(string id)
        {
            try
            {
                var department = data.Departments.Where(b => b.DepartmentID == int.Parse(id)).FirstOrDefault();
                data.Departments.DeleteOnSubmit(department);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteEmployee(string id)
        {
            try
            {
                var employee = data.Employees.Where(b => b.EmployeeID == int.Parse(id)).FirstOrDefault();
                data.Employees.DeleteOnSubmit(employee);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool EditDepartment(string id, Department newDepartment)
        {
            try
            {
                var department = data.Departments.Where(b => b.DepartmentID == int.Parse(id)).FirstOrDefault();
                data.Departments.DeleteOnSubmit(department);
                data.Departments.InsertOnSubmit(newDepartment);
                data.SubmitChanges();
                return true;
            }
            catch { return false; }
        }

        public bool EditEmployee(string id, Employee newEmployee)
        {
            try
            {
                var employee = data.Employees.Where(b => b.EmployeeID == int.Parse(id)).FirstOrDefault();
                data.Employees.DeleteOnSubmit(employee);
                data.Employees.InsertOnSubmit(newEmployee);
                data.SubmitChanges();
                return true;
            }
            catch { return false; }
        }

        public List<Department> GetDepartments()
        {
          try
            {
                var departments = (from Department in data.Departments select Department).ToList();
                return departments;
            }
            catch { return null; }
        }

        public List<Employee> GetEmployees()
        {
            try
            {
                var employees = (from employee in data.Employees select employee).ToList();
                return employees;
            }
            catch { return null; }
        }
    }
}
