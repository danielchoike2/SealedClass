using System;
namespace Employees
{// start of employees namespace

    interface IEmployee
    {
        //Properties
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //Methods
        public string Fullname();
        public double Pay();
        public int DisplayId();
       

    }
    class Employee : IEmployee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Employee()
        {
            Id = 0;
            FirstName = string.Empty;
            LastName = string.Empty;
        }
        public Employee(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
        public string Fullname()
        {
            return FirstName + " " + LastName;
        }
        public virtual double Pay()
        {
            double salary;
            Console.WriteLine($"What is {this.Fullname()}'s weekly salary?");
            salary = double.Parse(Console.ReadLine());
            return salary;
        }// end of virtual double 

        public int DisplayId()
        {
            return Id;
        }

       
        sealed  class Executive : Employee
        {
            public double Rate { get; set; }
            public int Hours { get; set; }
            
            public int Salary { get; set; }

            public string Title { get; set; }

           

            public Executive() :base()
            {
                Rate = 0;
                Hours = 0;
                Salary = 0;
                Title = string.Empty;
            }
            public Executive(int id, string firstName,string lastName,double rate, int hours, int salary, string title)
                :base(id, firstName, lastName)
            {
                Rate= rate;
                Hours = hours;
                Salary = salary;
                Title = title;
            }
            sealed public override double Pay()
            {
                if (Hours > 40)
                    return 40 * Rate + (2.5 * ((Hours - 40) * Rate));
                else
                    return Rate * Hours;
            }
            public double DisplayRate()
            {
                return Rate;
            }
            public int DisplayHours()
            {
                return Hours;
            }
            public int DisplaySalary()
            {
                return Salary;
            }
            public string DisplayTitle()
            {
                return Title;
            }

        }// end of sealed class 
        static void Main(string[] args)
        {
            // Employee object
            Employee george = new Employee(5, "George", "Costanza");
            george.Pay();
            Console.WriteLine("");

            // Executive object created using parameterized constructor
            Executive jerry = new Executive(6, "Jerry", "Seinfeld",1042, 40, 500160, "Vice President");
            Console.WriteLine(jerry.Fullname());
            Console.WriteLine("Weekly Rate: $" + jerry.Pay());
            Console.WriteLine("Hourly Rate: $" + jerry.DisplayRate());
            Console.WriteLine("Hours Worked This Week: " + jerry.DisplayHours());
            Console.WriteLine("Annual Salary: $" + jerry.DisplaySalary());
            Console.WriteLine("Executive Title: " + jerry.DisplayTitle());


            //Executive object created using the default constructor
            //values are assigned using properties

            Executive larry = new Executive();
            larry.Id = 20;
            larry.FirstName = "Larry";
            larry.LastName = "David";
            larry.Rate = 1050;
            larry.Hours = 40;
            larry.Salary = 504000;
            larry.Title = "President";
            Console.WriteLine("");
            Console.WriteLine("Executive Information:");
            Console.WriteLine(larry.Fullname());
            Console.WriteLine("Weekly Rate: $" + larry.Pay());
            Console.WriteLine("Hourly Rate: $" + larry.DisplayRate());
            Console.WriteLine("Hours Worked This Week: " + larry.DisplayHours());
            Console.WriteLine("Annual Salary: $" + larry.DisplaySalary());
            Console.WriteLine("Executive Title: " + larry.DisplayTitle());

        }


    }// end of interface 


}// end of employees namespace 

