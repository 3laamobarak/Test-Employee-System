using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEmpolyeeManagment;

namespace TestEmpolyeeManagment
{
    internal class Department
    {
        public int Id;
        public string Name;
        public string DepartmentHead;
        public List<Employee> employees = new List<Employee>();
        public Department(string name, string departmentHead, int id = 0)
        {
            Name = name;
            DepartmentHead = departmentHead;
            employees = new List<Employee>();
            Id = id != 0 ? id : GetHashCode();
        }
        public void AddEmployee(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentException("Invalid input");
            }
            employees.Add(employee);
        }
        public void AddEmployee(List<Employee> employees)
        {
            foreach (Employee employee in employees)
            {
                if (employee == null)
                {
                    throw new ArgumentException("Invalid input");
                }
                else AddEmployee(employee);
            }
        }
        public void RemoveEmployee(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentException("Invalid input");
            }
            else if(!employees.Contains(employee))
            {
                throw new ArgumentException("Employee not found");
            }
            else this.employees.Remove(employee);
        }
        public void showEmployees()
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("No employees in this department");
            }
            else
            {
                foreach (Employee employee in employees)
                {
                    Console.WriteLine(employee);
                }
            }
        }
        public void EditDepartment(string name, string departmentHead)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(departmentHead))
            {
                throw new ArgumentException("Invalid input");
            }
            else
            {
                Name = name;
                DepartmentHead = departmentHead;
            }
        }
        public void TopPerformer()
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("No employees in this department");
            }
            else
            {
                employees = employees.OrderByDescending(e => e.Score).ToList();
                foreach (Employee employee in employees)
                {
                    Console.WriteLine(employee);
                }
            }
        }
        public void EmpoloyeeSalary()
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("No employees in this department");
            }
            else
            {
                employees = employees.OrderByDescending(e => e.Salary).ToList();
                foreach (Employee employee in employees)
                {
                    Console.WriteLine(employee);
                }
            }
        }
       
        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, " +
                   $"Department Head: {DepartmentHead}, " +
                   $"Number of Employees: {employees.Count}\n" +
                   $"Employees:\n{string.Join("\n", employees)}";
        }


    }
}