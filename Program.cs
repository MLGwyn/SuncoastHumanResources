using System;
using System.Collections.Generic;
using System.Linq;

namespace SuncoastHumanResources
{
    class Employee
    {
        public string Name { get; set; }
        public int Department { get; set; }
        public int Salary { get; set; }
        public int MonthlySalary()
        {
            return Salary / 12;
        }
    }

    class Program
    {
        static void DisplayGreeting()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("    Welcome to Our Employee Database    ");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine();
            Console.WriteLine();
        }

        static string PromptForString(string prompt)
        {
            Console.Write(prompt);
            var userInput = Console.ReadLine();

            return userInput;
        }

        static int PromptForInteger(string prompt)
        {
            Console.Write(prompt);
            int userInput;
            var isThisGoodInput = Int32.TryParse(Console.ReadLine(), out userInput);

            if (isThisGoodInput)
            {
                return userInput;
            }
            else
            {
                Console.WriteLine("Sorry, that isn't a valid input, I'm using 0 as your answer.");
                return 0;
            }
        }

        static void Main(string[] args)
        {
            var employees = new List<Employee>();



            DisplayGreeting();

            var keepGoing = true;

            while (keepGoing)
            {
                Console.WriteLine();
                Console.Write("What do you want to do?\n(A)dd an employee\n(S)how all employees\n(F)ind an Employee\n(Q)uit\n: ");
                var choice = Console.ReadLine().ToUpper();

                if (choice == "Q")
                {
                    keepGoing = false;
                }
                else
                if (choice == "S")
                {
                    Console.WriteLine("SHOWING THE EMPLOYEES");
                    foreach (var emp in employees)
                    {
                        Console.WriteLine($"{emp.Name} is in department {emp.Department} and makes {emp.Salary}");
                    }
                }
                else
                if (choice == "F")
                {
                    var name = PromptForString("What employee are you looking for? ");

                    Employee foundEmployee = null;
                    foreach (var emp in employees)
                    {
                        if (emp.Name == name)
                        {
                            foundEmployee = emp;
                        }
                    }
                    if (foundEmployee == null)
                    {
                        Console.WriteLine($"No \"{name}\" found");
                    }
                    else
                    {
                        Console.WriteLine($"{foundEmployee.Name} is in department {foundEmployee.Department} and makes {foundEmployee.Salary}");
                    }
                }
                else
                {
                    var employee = new Employee();
                    employee.Name = PromptForString("What is your name? ");
                    employee.Department = PromptForInteger("What is your department number? ");
                    employee.Salary = PromptForInteger("What is your yearly salary (in dollars)? ");

                    Console.WriteLine($"Hello, {employee.Name} you make {employee.MonthlySalary()} dollars per month.");

                    employees.Add(employee);
                }
            }
        }
    }
}
