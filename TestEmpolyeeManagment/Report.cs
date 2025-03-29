using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEmpolyeeManagment
{
    public class Report
    {

        public Report() { }

        public static List<Employee> getDepartmentEmployees(Department department, List<Employee> employees)
        {
            List<Employee> departmentEmployees = new List<Employee>();
            int index = 0;
            foreach (Employee employee in employees)
            {
                if(employee.Department.Name == department.Name)
                {
                    departmentEmployees.Add(employee);
                    Console.WriteLine($"{index++} - {employee.ToString()}");
                }
            }
            return departmentEmployees;
        }

        public static void TopPerformanceEmployees(List<Employee> employees)
        {
            var topPerformers = employees
                .OrderByDescending(emp => emp.Score)
                .Take(5); // Get the top 5 employees
            Console.WriteLine("==========================");
            Console.WriteLine("Top Performance Employees");
            int index = 0;
            foreach (var emp in topPerformers)
            {
                Console.WriteLine($"{index++} - {emp.ToString()}");
                //Console.WriteLine($"\nName: {emp.Name}, Score: {emp.Score}");
            }

        }

        public static void SalaryDistribution(List<Employee> employees)
        {
            var salaryData = employees
                .GroupBy(emp => emp.Salary <= 1000 ? "0-1000" :
                                emp.Salary <= 2000 ? "1001-2000" :
                                emp.Salary <= 3000 ? "2001-3000" :
                                emp.Salary <= 4000 ? "3001-4000" :
                                emp.Salary <= 5000 ? "4001-5000" :
                                emp.Salary <= 10000 ? "5001-10000" : "10001+")
                .Select(group => new { Range = group.Key, Count = group.Count() });
            Console.WriteLine("===============================");
            Console.WriteLine($"Salary Distribution:");
            foreach (var data in salaryData)
            {
                Console.WriteLine($"\t{data.Range}: {data.Count} employees");
            }

        }

    }
}
