using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delegates_3
{
    class Program
    {
        static void Main(string[] args)
        {
            OrganizationOne orgOne = new OrganizationOne();
            OrganizationTwo orgTwo = new OrganizationTwo();

            List<Employee> employees = new List<Employee>();
            Employee e1 = new Employee(){ID = 1,Name = "Mark",Salary = 2500,Experience = 5};
            Employee e2 = new Employee(){ID = 1,Name = "Sara",Salary = 10000,Experience = 3};
            Employee e3 = new Employee(){ID = 1,Name = "Greg",Salary = 5000,Experience = 2};
            Employee e4 = new Employee(){ID = 1,Name = "Cindy",Salary = 8000,Experience = 6};

            employees.Add(e1);
            employees.Add(e2);
            employees.Add(e3);
            employees.Add(e4);

            //EXAMPLE USES:

            //decoupled logic from the employee class!
            Employee.PromoteEmployee(employees, Promote);
            Console.WriteLine();

            //pass in method based on different user classes 
            //(different organizations may have different promotion logics)
            Employee.PromoteEmployee(employees,orgOne.Promote);
            Console.WriteLine();
            Employee.PromoteEmployee(employees, orgTwo.Promote);
            Console.WriteLine();

            //use with inline lambda expression
            Employee.PromoteEmployee(employees, emp => emp.Salary > 8500);
            Console.WriteLine();


        }

        public static bool Promote(Employee employee)
        {
            if (employee.Name == "Sara")
                return true;
            else
                return false;
        }
    }

    delegate bool IsPromotable(Employee employee);

    class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public int Experience{ get; set; }

        //what is this flexible method called?
        public static void PromoteEmployee(List<Employee> employees,IsPromotable IsEligibleForPromotion)
        {
            foreach (Employee e in employees)
            {
                //now this class has no hardcoded logic, and can be used 
                //however the end user(s) want to define their IsEligibleForPromotion 
                //method.
                if(IsEligibleForPromotion(e))
                    Console.WriteLine(e.Name +" promoted");
            }
        }
    }

    //now these classes can use the same PromoteEmployee method, but differently!
    class OrganizationOne
    {
        internal bool Promote(Employee employee)
        {
            if (employee.Experience >= 5)
                return true;
            else
                return false;
        }
    }
    class OrganizationTwo
    {
        internal bool Promote(Employee employee)
        {
            if (employee.Experience >= 5 && employee.Salary > 5000)
                return true;
            else
                return false;
        }
    }
}
