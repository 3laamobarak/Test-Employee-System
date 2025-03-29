using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEmpolyeeManagment
{
    internal class PerformanceReview
    {
        public Employee Employee;
        public performance Perform;
        public string Review;
        public DateTime ReviewDate;
        public PerformanceReview(Employee employee, performance perform, string review, DateTime reviewDate)
        {
            Employee = employee;
            Perform = perform;
            Review = review;
            ReviewDate = reviewDate;
        }
        public void AddReview(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentException("Invalid input");
            }
            else
            {
                Employee = employee;
                performance score = Perform;
            }
        }
        public void AddScore(performance score)
        {
            if (score < performance.Poor || score > performance.Excellent)
            {
                throw new ArgumentException("Invalid input");
            }
            else
            {
                Perform = score;
            }
        }


    }
}