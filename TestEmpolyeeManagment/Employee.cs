using TestEmpolyeeManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEmpolyeeManagment
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public int Score { get; set; }
        public Department Department { get; set; }
        public DateTime EmploymentDate { get; set; }
        public Statue statue;
        public Rank rank { get; set; }
        public performance performance;

        public Employee(int id,string name, int age, decimal salary, Department department, int score=10, Rank rank=Rank.employee)
        {
            Id = id != 0 ? id : GetHashCode();
            Name = name;
            Age = age;
            Salary = salary;
            Department = department;
            EmploymentDate = DateTime.Now;
            statue = Statue.Active;
            performance = performance.Fair;
            Score = score;
            this.rank = rank;
           department.employees.Add(this); // ✅ Add employee to the department list
        }
        // promoted Done
        public void promoted(decimal newSalary)
        {
            if (newSalary.GetType() != typeof(decimal))
            {
                throw new ArgumentException("Invalid input");
            }
            else if (newSalary <= Salary)
            {
                throw new ArgumentException("cant promote with lower or Equal salary");
            }
            else
            {
                Rank oldrank = rank;

                if (Score >= 0 && Score <= 10)
                {
                    oldrank = Rank.employee;
                }
                else if (Score >= 11 && Score <= 20)
                {
                    oldrank = Rank.manager;
                }
                else if (Score >= 21 && Score <= 30)
                {
                    oldrank = Rank.executive;
                }
                else if (Score >= 31 && Score <= 40)
                {
                    oldrank = Rank.director;
                }
                else if (Score >= 41 && Score <= 50)
                {
                    oldrank = Rank.vicePresident;
                }
                else if (Score >= 51 && Score <= 60)
                {
                    oldrank = Rank.president;
                }
                else if (Score >= 61 && Score <= 70)
                {
                    oldrank = Rank.ceo;
                }
                else
                {
                    throw new ArgumentException("Invalid score");
                }
                if (oldrank == Rank.ceo)
                {
                    throw new ArgumentException("Cant promote CEO");
                }
                Rank newrank = oldrank + 10;
                Score = Score + 10;
                rank = newrank;
                Salary = newSalary;
                Console.WriteLine($"Promoted {Name} from {oldrank} to {newrank} with new salary: {newSalary:C}");
            }
        }



        //public void PerformanceRating(decimal Rating)
        //{
        //    if(Rating.GetType() != typeof(decimal))
        //    {
        //        throw new ArgumentException("Invalid input");
        //    }
        //    else if (Rating <= 0 || Rating >= 5)
        //    {
        //        throw new ArgumentException("Invalid rating");
        //    }
        //    performance = (performance)Rating;

        //}

        public void PerformanceRating(decimal Rating)
        {
            if (Rating < 0 || Rating > 5)  // ✅ Allow full range (0 to 5)
            {
                throw new ArgumentException("Invalid rating. Must be between 0 and 5.");
            }

            performance = (performance)(int)Math.Round(Rating); // ✅ Convert to int before casting
        }





        public void Transfer(Department department)
        {
            if (department == null)
            {
                throw new ArgumentException("Invalid input");
            }
            else Department = department;
        }

        public void terminate()
        {
            if (statue == Statue.Terminated)
            {
                throw new ArgumentException("Employee already terminated");
            }
            else statue = Statue.Terminated;
        }
        public void EditEmployee(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentException("Invalid input");
            }
            else
            {
                Name = employee.Name;
                Age = employee.Age;
                Salary = employee.Salary;
                Department = employee.Department;
                EmploymentDate = employee.EmploymentDate;
                statue = employee.statue;
                rank = employee.rank;
                performance = employee.performance;
            }
        }
        public override string ToString()
        {

            return $"Id: {Id}, Name: {Name}, Salary: {Salary:C}, " +
                   $"Department: {Department.Name}, Statue: {statue}, Rank: {rank}, Performance :{performance}";
        }

    }
}
