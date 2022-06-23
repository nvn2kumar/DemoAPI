using DemoAPI.Models;
using DemoAPI.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.Repository.Service
{
    public class EmployeeService : IEmployee
    {
        public readonly ApplicationDbContext dbContext;
        public EmployeeService(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public Employee DeleteEmployee(int id)
        {
            var emp = dbContext.Employees.SingleOrDefault(e => e.Id == id);
            if (emp != null)
            { dbContext.Employees.Remove(emp);
                dbContext.SaveChanges();
                return emp;
            }
            return null;
        }

        public Employee GetEmployeeById(int id)
        {
           var emp = dbContext.Employees.SingleOrDefault(e=> e.Id==id);
            return emp;
        }

        public List<Employee> GetEmployees()
        {
            return dbContext.Employees.ToList();
        }

        public Employee PostEmployee(Employee employee)
        {
            dbContext.Employees.Add(employee);
            dbContext.SaveChanges();
            return employee;
        }

        public Employee UpdateEmployee(Employee emp)
        {
            var eee = dbContext.Employees.SingleOrDefault(e => e.Id == emp.Id);
            if (eee != null)
            {
                eee.FirstName = emp.FirstName; // only 4 lines are updated. and nothing left null value on updation.
                eee.LastName = emp.LastName;
                eee.Email = emp.Email;
                eee.Address = emp.Address;
                dbContext.Employees.Update(eee);
                dbContext.SaveChanges();
                return emp;
            }
            return null;
        }
    }
}
