using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace SuncoastHumanResources
{
    class EmployeeDatabase
    {
        private List<Employee> Employees { get; set; } = new List<Employee>();

        public void LoadEmployees()
        {
            // var employees = new List<Employee>();
            if (File.Exists("employees.csv"))
            {
                var fileReader = new StreamReader("employees.csv");
                var csvReader = new CsvReader(fileReader, CultureInfo.InvariantCulture);
                Employees = csvReader.GetRecords<Employee>().ToList();
                fileReader.Close();
            }
        }
        public void SaveEmployees()
        {
            var fileWriter = new StreamWriter("employees.csv");
            var csvWriter = new CsvWriter(fileWriter, CultureInfo.InvariantCulture);
            csvWriter.WriteRecords(Employees);
            fileWriter.Close();
        }
        public void AddEmployee(Employee newEmployee)
        {
            Employees.Add(newEmployee);
        }

        public List<Employee> GetAllEmployees()
        {
            return Employees;
        }

        public Employee FindOneEmployee(string nameToFind)
        {
            Employee foundEmployee = Employees.FirstOrDefault(employee => employee.Name == nameToFind);
            return foundEmployee;
        }

        public void DeleteEmployee(Employee employeeToDelete)
        {
            Employees.Remove(employeeToDelete);
        }


    }
}
