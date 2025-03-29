using TestEmpolyeeManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEmpolyeeManagment
{
    internal class Company
    {
        public List<Employee> Employees { get; private set; }
        public List<Department> Departments { get; private set; }

        public Company(List<Employee> employees, List<Department> departments)
        {
            Employees = employees;
            Departments = departments;
        }
        public void AddEmployee(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentException("Invalid input");
            }
            Employees.Add(employee);
        }
        public void AddDepartment(Department department)
        {
            if (department == null)
            {
                throw new ArgumentException("Invalid input");
            }
            Departments.Add(department);
        }
        public void RemoveEmployee(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentException("Invalid input");
            }
            else if (!Employees.Contains(employee))
            {
                throw new ArgumentException("Employee not found");
            }
            else Employees.Remove(employee); 
            employee.Department.RemoveEmployee(employee);
        }
        public void RemoveDepartment(Department department)
        {
            if (department == null)
            {
                throw new ArgumentException("Invalid input");
            }
            else if (!Departments.Contains(department))
            {
                throw new ArgumentException("Department not found");
            }
            else Departments.Remove(department);
        }
        public void showEmployees()
        {
            if (Employees.Count == 0)
            {
                Console.WriteLine("No employees in this company");
            }
            else
            {
                foreach (Employee employee in Employees)
                {
                    Console.WriteLine(employee);
                }
            }
        }
        public void showDepartments()
        {
            if (Departments.Count == 0)
            {
                Console.WriteLine("No departments in this company");
            }
            else
            {
                foreach (Department department in Departments)
                {
                    Console.WriteLine(department);
                }
            }
        }
    }
}