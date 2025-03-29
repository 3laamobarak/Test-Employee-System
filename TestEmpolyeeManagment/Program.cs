using TestEmpolyeeManagment;

namespace TestEmpolyeeManagment
{
    enum Statue
    {
        Active,
        Terminated
    }
    enum performance
    {
        Excellent = 5,
        VeryGood = 4,
        Good = 3,
        Average = 2,
        Fair = 1,
        Poor = 0
    }
    enum Rank
    {
        employee=10,
        manager=20,
        executive=30,
        director=40,
        vicePresident=50,
        president=60,
        ceo= 70
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Department department = new Department("IT", "Ahmed");
            Employee employee1 = new Employee(1, "Ahmed", 25, 5000, department);
            Employee employee2 = new Employee(2, "Ali", 30, 7000, new Department("HR", "Ali"), 15, Rank.manager);
            //employee1.promoted(6000);
            //employee2.promoted(8000);
            //Console.WriteLine(employee1);
            //Console.WriteLine(employee2);
            employee1.Transfer(new Department("HR", "Ali"));
            


        }
    }
}
