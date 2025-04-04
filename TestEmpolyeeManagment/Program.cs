﻿using TestEmpolyeeManagment;

namespace TestEmpolyeeManagment
{
    public enum Statue
    {
        Active,
        Terminated
    }
    public enum performance
    {
        Excellent = 5,
        VeryGood = 4,
        Good = 3,
        Average = 2,
        Fair = 1,
        Poor = 0
    }
    public enum Rank
    {
        employee = 10,
        manager = 20,
        executive = 30,
        director = 40,
        vicePresident = 50,
        president = 60,
        ceo = 70
    }
    public class Program
    {
        public static Company company = new Company(new List<Employee>(), new List<Department>());
        static void Main(string[] args)
        {

            Data.LoadData();
            bool checkWrite= false;

            while (true)
            {
                checkWrite = false;
                // Print the header
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("|     Employee Management System Menu  |");
                Console.WriteLine("---------------------------------------");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("-|-------------------------------------|");
                Console.WriteLine($"|1 | Add Employee                     |");
                Console.WriteLine($"|2 | Remove Employee                  |");
                Console.WriteLine($"|3 | Show Employees                   |");
                Console.WriteLine($"|4 | Add Department                   |");
                Console.WriteLine($"|5 | Remove Department                |");
                Console.WriteLine($"|6 | Show Departments                 |");
                Console.WriteLine($"|7 | Promote Employee                 |");
                Console.WriteLine($"|8 | Transfer Employee                |");
                Console.WriteLine($"|9 | Terminate Employee               |");
                Console.WriteLine($"|10| Add Performance Review           |");
                Console.WriteLine($"|11| Show Department Employees        |");
                Console.WriteLine($"|12| Top Performing Employees         |");
                Console.WriteLine($"|13| Employees Salary Distributions   |");
                Console.WriteLine($"|14| Exit                             |");
                Console.WriteLine($"|-------------------------------------|");
                Console.ResetColor();
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Employee Name: ");  
                        string name;  
                        while (true)  
                        {  
                            name = Console.ReadLine();  
                            if (!string.IsNullOrWhiteSpace(name))  
                                break;  
                            Console.Write("Invalid name. Please enter a valid name: ");  
                        }  

                        // Age Validation  
                        Console.Write("Enter Age: ");  
                        int age;  
                        while (true)  
                        {  
                            string ageInput = Console.ReadLine();  
                            if (int.TryParse(ageInput, out age) && age >= 18 && age <= 65)  
                                break;  
                            Console.Write("Invalid age. Please enter a number between 18-65: ");  
                        }  

                        // Salary Validation  
                        Console.Write("Enter Salary: ");  
                        decimal salary;  
                        while (true)  
                        {  
                            string salaryInput = Console.ReadLine();  
                            if (decimal.TryParse(salaryInput, out salary) && salary > 0)  
                                break;  
                            Console.Write("Invalid salary. Please enter a positive number: ");  
                        }  

                        // Department Validation  
                        Console.Write("Enter Department Name: ");  
                        string deptName;  
                        while (true)  
                        {  
                            deptName = Console.ReadLine();  
                            if (!string.IsNullOrWhiteSpace(deptName))  
                                break;  
                            Console.Write("Invalid department. Please enter a valid name: ");  
                        }  

                        Department dept = company.Departments.Find(d => d.Name == deptName);  
                        if (dept == null)  
                        {  
                            Console.WriteLine("Department not found.");  
                            break;  
                        }  

                        Employee emp = new Employee(0, name, age, salary, dept);  
                        company.AddEmployee(emp);  
                        Console.WriteLine("Employee added successfully!");  
                        break;

                    //////////////////////////////////////////////////////////////////////////////////////////

                    case "2":
                        Console.Write("Enter Employee Name to Remove: ");  
                        string empName;  
                        while (true)  
                        {  
                            empName = Console.ReadLine();  
                            if (!string.IsNullOrWhiteSpace(empName))  
                                break;  
                            Console.Write("Invalid name. Please enter a valid employee name: ");  
                        }  

                        // Case-insensitive search with StringComparison.OrdinalIgnoreCase  
                        Employee employeeToRemove = company.Employees  
                            .FirstOrDefault(e => e.Name.Equals(empName, StringComparison.OrdinalIgnoreCase));  

                        if (employeeToRemove != null)  
                        {  
                            // Confirmation prompt  
                            Console.Write($"Are you sure you want to remove {employeeToRemove.Name}? (y/n): ");  
                            string confirmation = Console.ReadLine()?.ToLower();  

                            if (confirmation == "y" || confirmation == "yes")  
                            {  
                                company.RemoveEmployee(employeeToRemove);  

                                if (employeeToRemove.Department != null)  
                                {  
                                    employeeToRemove.Department.employees.Remove(employeeToRemove);  
                                }  

                                Console.WriteLine("Employee removed successfully.");  
                            }  
                            else  
                            {  
                                Console.WriteLine("Employee removal canceled.");  
                            }  
                        }  
                        else  
                        {  
                            Console.WriteLine("Employee not found.");  
                        }  
                        break;  

                    ////////////////////////////////////////////////////////////////
                    case "3":
                        company.showEmployees();
                        break;

                    /////////////////////////////////////////////////////////////////
                    case "4":
                        Console.Write("Enter Department Name: ");  
                        string newDeptName;  
                        while (true)  
                        {  
                            newDeptName = Console.ReadLine()?.Trim();  
        
                            if (!string.IsNullOrWhiteSpace(newDeptName))  
                            {  
                                // Check if department already exists (case-insensitive)  
                                bool deptExists = company.Departments  
                                    .Any(d => d.Name.Equals(newDeptName, StringComparison.OrdinalIgnoreCase));  
            
                                if (!deptExists)  
                                    break;  
                
                                Console.Write($"Department '{newDeptName}' already exists. Enter a different name: ");  
                            }  
                            else  
                            {  
                                Console.Write("Invalid department name. Please enter a valid name: ");  
                            }  
                        }  

                        Console.Write("Enter Department Head: ");  
                        string deptHead;  
                        while (true)  
                        {  
                            deptHead = Console.ReadLine()?.Trim();  
                            if (!string.IsNullOrWhiteSpace(deptHead))  
                            {
                                break;  
                            }  
                            Console.Write("Invalid department head. Please enter a valid name: ");  
                        }  

                        Department newDept = new Department(newDeptName, deptHead);  
                        company.AddDepartment(newDept);  
                        Console.WriteLine($"Department '{newDeptName}' added successfully with head '{deptHead}'!");  
                        break;  
                    ///////////////////////////////////////////////////////////////////
                    case "5":
                        Console.Write("Enter Department Name to Remove: ");
                        string removeDeptName = Console.ReadLine();

                        Department departmentToRemove = company.Departments.Find(d => d.Name == removeDeptName);
                        if (departmentToRemove != null)
                        {
                            company.RemoveDepartment(departmentToRemove);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Department removed successfully.");
                            Console.ResetColor();
                        
                            checkWrite = true;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Department not found.");
                            Console.ResetColor();
                      
                        }

                        break;

                    ///////////////////////////////////////////////////////////////////////
                    case "6":
                        company.showDepartments();
                        break;
                    ////////////////////////////////////////////////////////////////////////
                    case "7":
                        Console.Write("Enter Employee Name to Promote: ");
                        string promoteName = Console.ReadLine();

                        Employee promoteEmp = company.Employees.Find(e => e.Name == promoteName);
                        if (promoteEmp != null)
                        {
                            Console.Write("Enter New Salary: ");
                            decimal newSalary = decimal.Parse(Console.ReadLine());
                            promoteEmp.promoted(newSalary);
                            checkWrite = true;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Employee not found.");
                            Console.ResetColor();
                        
                        }
                        break;
                    /////////////////////////////////////////////////////////////////////////////

                    case "8":
                        Console.Write("Enter Employee Name to Transfer: ");
                        string transferName = Console.ReadLine();

                        Employee transferEmp = company.Employees.Find(e => e.Name == transferName);
                        if (transferEmp != null)
                        {
                            Console.Write("Enter New Department: ");
                            string newDeptTransfer = Console.ReadLine();

                            Department transferDept = company.Departments.Find(d => d.Name == newDeptTransfer);
                            if (transferDept != null)
                            {
                                // Remove employee from the old department
                                foreach (var deptt in company.Departments)
                                {
                                    if (deptt.employees.Contains(transferEmp))
                                    {
                                        deptt.employees.Remove(transferEmp);
                                        break; // Exit loop once found
                                    }
                                }

                                // Transfer employee to the new department
                                transferEmp.Transfer(transferDept);
                                transferDept.employees.Add(transferEmp);

                                
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Employee transferred successfully.");
                                Console.ResetColor();
                                checkWrite = true;
                            }
                            else
                            {

                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Department not found.");
                                Console.ResetColor();
                                
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Employee not found.");
                            Console.ResetColor();
                          
                        }
                        break;

                    ////////////////////////////////////////////////////////////////////////////////

                    case "9":
                        Console.Write("Enter Employee Name to Terminate: ");
                        string terminateName = Console.ReadLine();

                        Employee terminateEmp = company.Employees.Find(e => e.Name == terminateName);
                        if (terminateEmp != null)
                        {
                            terminateEmp.terminate();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Employee terminated successfully.");
                            Console.ResetColor();
                            
                            checkWrite = true;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Employee not found.");
                            Console.ResetColor();
                           
                        }
                        break;
                    ///////////////////////////////////////////////////////////////////////////////////
                    case "10":
                        Console.Write("Enter Employee Name for Review: ");
                        string reviewEmpName = Console.ReadLine();
                        Employee reviewEmp = company.Employees.Find(e => e.Name == reviewEmpName);
                        if (reviewEmp != null)
                        {
                            Console.Write("Enter Performance Rating (1-5): ");
                            int rating = int.Parse(Console.ReadLine());
                            PerformanceReview review = new PerformanceReview(reviewEmp, (performance)rating, "Annual Review", DateTime.Now);
                            reviewEmp.PerformanceRating(rating);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Performance review added successfully.");
                            Console.ResetColor();
                          
                            checkWrite = true;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Employee not found.");
                            Console.ResetColor();
                           
                        }
                        break;
                    /////////////////////////////////////////////////////////////////////////////////////

                    case "11":
                        int index = 0;
                        foreach (Department department in company.Departments)
                        {
                            Console.WriteLine($"{index++} - {department.Name}");
                        }
                        if (int.TryParse(Console.ReadLine(), out index) && index < company.Departments.Count)
                        {
                            Report.getDepartmentEmployees(company.Departments[index], company.Employees);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid department index.");
                            Console.ResetColor();
                            
                        }
                        break;
                    case "12":
                        Report.TopPerformanceEmployees(company.Employees);
                        break;
                    case "13":
                        Report.SalaryDistribution(company.Employees);
                        break;
                    case "14":
                        Console.WriteLine("Exiting program...");
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        Console.ResetColor();
                        
                        break;
                }

                if (checkWrite)
                {
                    Data.SaveData();
                }

            }
        }
    }
}