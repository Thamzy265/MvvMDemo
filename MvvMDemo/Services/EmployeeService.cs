using MvvMDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvMDemo.Services
{
    class EmployeeService
    {
        List<Employee> employees;

        public EmployeeService()
        {
            employees = new List<Employee>
            {
                new Employee
                {
                    Name = "William Nasoni",
                    Age = 20,
                    ID = 100
                }
            };
        }

        public bool AddEmployee(Employee employee)
        {
            bool result = false;
            if (employee.Age >= 18 || employee.Age <= 50 )
            {
                employees.Add(employee);
                result = true;
            }
           

            return result;
        }

        public bool UpdateEmployee(Employee employee)
        {
            bool result = false;

            int index = employees.FindIndex(p => p.ID == employee.ID);

            if (index != -1)
            {
                employees[index].Age = employee.Age;
                employees[index].Name = employee.Name;
                result = true;
            }
            else
                result = false;

            return result;
        }

        public bool DeleteEmployee(int id)
        {
            bool result = false;

            int index = employees.FindIndex(p => p.ID == id);

            if (index != -1)
            {
                employees.RemoveAt(index);
                result = true;
            }
            else
                result = false;

            return result;
        }

        public Employee GetEmployee(int ID)
        {
            var result = employees.FirstOrDefault(p => p.ID == ID);

            return result;
        }
        public List<Employee> GetEmployees()
        {
            return employees;
        }
    }
}
