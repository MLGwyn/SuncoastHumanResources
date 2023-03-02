using System.Collections.Generic;
using System.Linq;

namespace SuncoastHumanResources
{
    class EmployeeDatabase
    {
        private List<Employee> Employees { get; set; } = new List<Employee>();

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
