using TestEmpolyeeManagment;

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

<<<<<<< HEAD
            Company company = new Company(new List<Employee>(), new List<Department>());
            bool running = true; // Keeps the program running

            while (running)
                
=======
            Data.LoadData();
            bool checkWrite= false;

            while (true)
>>>>>>> 8ee5043224366911ac6bd312a84c8e27706fa477
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

                try
                {
                    switch (choice)
                    {
                        case "1":
                            Console.Write("Enter Employee Name: ");
                            string name = Console.ReadLine();

<<<<<<< HEAD
                            Console.Write("Enter Age: ");
                            int age = int.Parse(Console.ReadLine());

                            Console.Write("Enter Salary: ");
                            decimal salary = decimal.Parse(Console.ReadLine());
=======
                        Console.Write("Enter Age: ");
                        //int age = 0;
                        if (int.TryParse(Console.ReadLine(), out int age) && age < 18)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Employee must be at least 18 years old.");
                            Console.ResetColor();
                            break;
                        }

                        Console.Write("Enter Salary: ");
                        //decimal salary = decimal.Parse(Console.ReadLine());
                        if (decimal.TryParse(Console.ReadLine(), out decimal salary) && salary < 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Salary must be a positive number.");
                            Console.ResetColor();
                           
                            break;
                        }
>>>>>>> 8ee5043224366911ac6bd312a84c8e27706fa477

                            Console.Write("Enter Department Name: ");
                            string deptName = Console.ReadLine();

<<<<<<< HEAD
                            Department dept = company.Departments.Find(d => d.Name == deptName);
                            if (dept == null)
=======
                        Department dept = company.Departments.Find(d => d.Name == deptName);
                        if (dept == null)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Department not found.");
                            Console.ResetColor();
                            break;
                        }

                        Employee emp = new Employee(company.Employees.Count+1, name, age, salary, dept);

                        company.AddEmployee(emp); // Manually add to company

                        Console.WriteLine("Employee added successfully!");
                        checkWrite = true;
                        break;

                    //////////////////////////////////////////////////////////////////////////////////////////

                    case "2":
                        Console.Write("Enter Employee Name to Remove: ");
                        string empName = Console.ReadLine();

                        Employee employeeToRemove = company.Employees.Find(e => e.Name == empName);
                        if (employeeToRemove != null)
                        {
                            // Remove employee from the company's employee list
                            company.RemoveEmployee(employeeToRemove);

                            // Remove employee from the department's employee list
                            if (employeeToRemove.Department != null)
>>>>>>> 8ee5043224366911ac6bd312a84c8e27706fa477
                            {
                                Console.WriteLine("Department not found.");
                                break;
                            }

<<<<<<< HEAD
                            Employee emp = new Employee(0, name, age, salary, dept);

                            company.AddEmployee(emp); // Manually add to company
=======
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Employee removed successfully.");
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
>>>>>>> 8ee5043224366911ac6bd312a84c8e27706fa477

                            Console.WriteLine("Employee added successfully!");
                            break;

                        //////////////////////////////////////////////////////////////////////////////////////////

                        case "2":
                            Console.Write("Enter Employee Name to Remove: ");
                            string empName = Console.ReadLine();

<<<<<<< HEAD
                            Employee employeeToRemove = company.Employees.Find(e => e.Name == empName);
                            if (employeeToRemove != null)
=======
                        Department newDept = new Department(newDeptName, deptHead);
                        company.AddDepartment(newDept);


                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Department added successfully!");
                        Console.ResetColor();
                        
                        checkWrite = true;
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
>>>>>>> 8ee5043224366911ac6bd312a84c8e27706fa477
                            {
                                // Remove employee from the company's employee list
                                company.RemoveEmployee(employeeToRemove);

                                // Remove employee from the department's employee list
                                if (employeeToRemove.Department != null)
                                {
                                    employeeToRemove.Department.employees.Remove(employeeToRemove);
                                }


<<<<<<< HEAD
                                Console.WriteLine("Employee removed successfully.");
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
                            string newDeptName = Console.ReadLine();

                            Console.Write("Enter Department Head: ");
                            string deptHead = Console.ReadLine();

                            Department newDept = new Department(newDeptName, deptHead);
                            company.AddDepartment(newDept);
                            Console.WriteLine("Department added successfully!");
                            break;

                        ///////////////////////////////////////////////////////////////////
                        case "5":
                            Console.Write("Enter Department Name to Remove: ");
                            string removeDeptName = Console.ReadLine();

                            Department departmentToRemove = company.Departments.Find(d => d.Name == removeDeptName);
                            if (departmentToRemove != null)
                            {
                                company.RemoveDepartment(departmentToRemove);
                                Console.WriteLine("Department removed successfully.");
=======
                                
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Employee transferred successfully.");
                                Console.ResetColor();
                                checkWrite = true;
>>>>>>> 8ee5043224366911ac6bd312a84c8e27706fa477
                            }
                            else
                            {

                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Department not found.");
                                Console.ResetColor();
                                
                            }
<<<<<<< HEAD

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
                            }
                            else
                            {
                                Console.WriteLine("Employee not found.");
                            }
                            break;
                        /////////////////////////////////////////////////////////////////////////////

                        //case "8":
                        //    Console.Write("Enter Employee Name to Transfer: ");
                        //    string transferName = Console.ReadLine();

                        //    Employee transferEmp = company.Employees.Find(e => e.Name == transferName);
                        //    if (transferEmp != null)
                        //    {
                        //        Console.Write("Enter New Department: ");
                        //        string newDeptTransfer = Console.ReadLine();

                        //        Department transferDept = company.Departments.Find(d => d.Name == newDeptTransfer);
                        //        if (transferDept != null)
                        //        {
                        //            transferEmp.Transfer(transferDept);
                        //            Console.WriteLine("Employee transferred successfully.");
                        //        }
                        //        else
                        //        {
                        //            Console.WriteLine("Department not found.");
                        //        }
                        //    }
                        //    else
                        //    {
                        //        Console.WriteLine("Employee not found.");
                        //    }
                        //    break;

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

                                    Console.WriteLine("Employee transferred successfully.");
                                }
                                else
                                {
                                    Console.WriteLine("Department not found.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Employee not found.");
                            }
                            break;


                        ////////////////////////////////////////////////////////////////////////////////
=======
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Employee not found.");
                            Console.ResetColor();
                          
                        }
                        break;

                    ////////////////////////////////////////////////////////////////////////////////
>>>>>>> 8ee5043224366911ac6bd312a84c8e27706fa477

                        case "9":
                            Console.Write("Enter Employee Name to Terminate: ");
                            string terminateName = Console.ReadLine();

<<<<<<< HEAD
                            Employee terminateEmp = company.Employees.Find(e => e.Name == terminateName);
                            if (terminateEmp != null)
                            {
                                terminateEmp.terminate();
                                Console.WriteLine("Employee terminated successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Employee not found.");
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
                                Console.WriteLine("Performance review added successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Employee not found.");
                            }
                            break;
                        /////////////////////////////////////////////////////////////////////////////////////

                        case "11":
                            Console.WriteLine("Exiting program...");
                            return;

                        default:
                            Console.WriteLine("Invalid choice. Please enter a valid option.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("{ex.Message}");
                    // The loop continues instead of crashing
=======
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
>>>>>>> 8ee5043224366911ac6bd312a84c8e27706fa477
                }

                if (checkWrite)
                {
                    Data.SaveData();
                }

            }
        }
    }
}
