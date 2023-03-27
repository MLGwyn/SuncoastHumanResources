using System;

namespace SuncoastHumanResources
{

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
            var userInput = Console.ReadLine().ToUpper();

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

            // var employees = new List<Employee>();
            var database = new EmployeeDatabase();

            DisplayGreeting();

            var keepGoing = true;
            database.LoadEmployees();
            while (keepGoing)
            {
                Console.WriteLine();
                Console.Write("What do you want to do?\n(A)dd an employee\n(S)how all employees\n(F)ind an employee\n(D)elete an employee\n(U)pdate an employee\n(Q)uit\n: ");
                var choice = Console.ReadLine().ToUpper();

                switch (choice)
                {
                    case "Q":
                        keepGoing = false;
                        break;
                    case "S":
                        ShowEmployees(database);
                        break;
                    case "F":
                        FindEmployee(database);
                        break;
                    case "D":
                        DeleteEmployee(database);
                        database.SaveEmployees();
                        break;
                    case "U":
                        UpdateEmployee(database);
                        database.SaveEmployees();
                        break;
                    case "A":
                        AddEmployee(database);
                        database.SaveEmployees();
                        break;
                    default:
                        Console.WriteLine("Not a valid input. ☠️ ");
                        break;
                }

            }

        }

        private static void DeleteEmployee(EmployeeDatabase database)
        {
            // Console.WriteLine($"You have {database.FindOneEmployee} employees. ");
            var name = PromptForString("Which employee would you like to delete? ");

            var foundEmployee = database.FindOneEmployee(name);
            if (foundEmployee == null)
            {
                Console.WriteLine($"No \"{name}\" found.");
            }
            else
            {
                // var listOfEmployees = employees.Select(emp => emp.Name).ToList();
                // var indexOfEmployee = listOfEmployees.IndexOf(name);
                // var response = PromptForString($"Are you sure you want to delete {employees[indexOfEmployee].Name} from department {employees[indexOfEmployee].Department}? (Y/N) ");
                // var response = PromptForString($"Are you sure you want to delete {foundEmployee.Name} from department {foundEmployee.Department}? (Y/N) ");
                var response = PromptForString($"Are you sure you want to Delete {foundEmployee.Name} from department {foundEmployee.Department}? [Y/N]");

                if (response == "Y")
                {
                    //employees = employees.Where(emp => emp.Name != name).ToList();
                    // employees = employees.Where(emp => emp != foundEmployee).ToList();
                    // employees.RemoveAt(indexOfEmployee);
                    // Console.WriteLine($"You have {employees.Count} employees. ");
                    database.DeleteEmployee(foundEmployee);
                    // Console.WriteLine($"You have {database.GetAllEmployees} employees. ");
                }
            }
        }

        private static void FindEmployee(EmployeeDatabase database)
        {
            var name = PromptForString("What employee are you looking for? ");

            Employee foundEmployee = database.FindOneEmployee(name);
            if (foundEmployee == null)
            {
                Console.WriteLine($"No \"{name}\" found");
            }
            else
            {
                Console.WriteLine($"{foundEmployee.Name} is in department {foundEmployee.Department} and makes {foundEmployee.Salary}");
            }
        }

        private static void UpdateEmployee(EmployeeDatabase database)
        {
            var name = PromptForString("Which employee would you like to update? ");

            var foundEmployee = database.FindOneEmployee(name);
            if (foundEmployee == null)
            {
                Console.WriteLine($"No \"{name}\" found");
            }
            else
            {
                Console.WriteLine($"{foundEmployee.Name} is in department {foundEmployee.Department} and makes ${foundEmployee.Salary}. ");
                var response = PromptForString("What would you like to change [Name/Department/Salary]? ").ToUpper();

                if (response == "NAME")
                {
                    foundEmployee.Name = PromptForString("What is the employees new name? ");
                }
                if (response == "DEPARTMENT")
                {
                    foundEmployee.Department = PromptForInteger("What is the employees new department number? ");
                }
                if (response == "SALARY")
                {
                    foundEmployee.Salary = PromptForInteger("What is the employees new salary? ");
                }
            }
        }

        private static void AddEmployee(EmployeeDatabase database)
        {
            var employee = new Employee();
            employee.Name = PromptForString("What is your name? ");
            employee.Department = PromptForInteger("What is your department number? ");
            employee.Salary = PromptForInteger("What is your yearly salary (in dollars)? ");

            Console.WriteLine($"Hello, {employee.Name} you make {employee.MonthlySalary()} dollars per month. ");

            database.AddEmployee(employee);
        }

        private static void ShowEmployees(EmployeeDatabase database)
        {
            Console.WriteLine("SHOWING THE EMPLOYEES");
            foreach (var emp in database.GetAllEmployees())
            {
                Console.WriteLine($"{emp.Name} is in department {emp.Department} and makes {emp.Salary}");
            }
        }
    }
}
