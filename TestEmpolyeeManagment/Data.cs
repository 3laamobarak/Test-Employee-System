using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEmpolyeeManagment
{
    public class Data
    {
        public static string departmentFilePath = "departments.csv";
        public static string employeeFilePath = "employees.csv";
        public static void LoadData()
        {
            LoadDepartmentData();
            LoadSEmployeesData();
        }

        public static void SaveData()
        {
            SaveDepartmentsData();
            SaveEmployeesData();
        }

        public static void SaveDepartmentsData()
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(departmentFilePath))
            {
                file.WriteLine("Id,Name,DepartmentHead");
                foreach (Department department in Program.company.Departments)
                {
                    file.WriteLine($"{department.Id},{department.Name},{department.DepartmentHead}");
                }
            }
        }

        public static void SaveEmployeesData()
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(employeeFilePath))
            {
                file.WriteLine("Id,Name,Age,Salary,DepartmentId,Score");
                foreach (Employee employee in Program.company.Employees)
                {
                    file.WriteLine($"{employee.Id},{employee.Name},{employee.Age},{employee.Salary},{employee.Department.Name},{employee.Score}");
                }
            }
        }

        public static void LoadDepartmentData()
        {

            using (StreamReader reader = new StreamReader(departmentFilePath))
            {
                int index = 0;
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(',');
                    if(index != 0)
                    {
                        Program.company.Departments.Add(new Department(values[1], values[2], int.Parse(values[0])));
                    }

                    index++;
                }
            }

            //Department.ListDepartments();
        }

        public static void LoadSEmployeesData()
        {

            using (StreamReader reader = new StreamReader(employeeFilePath))
            {
                Department department;
                int index = 0;
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(',');
                    if (index != 0 && int.TryParse(values[0], out int id))
                    {
                        
                        department = Program.company.Departments.Find(x => x.Name == values[4]);
                        if(department != null)
                        {
                            Program.company.Employees.Add(
                                new Employee(id: id, name: values[1], 
                                age: int.Parse(values[2]), salary: decimal.Parse(values[3]), 
                                department: department, score: int.Parse(values[5])));
                        }
                    }

                    index++;
                }
            }
        }
       
    }
}
