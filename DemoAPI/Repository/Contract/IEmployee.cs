using DemoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.Repository.Contract
{
      public interface IEmployee
    {
        List<Employee> GetEmployees();  //detect all Employees in List
        Employee PostEmployee(Employee employee);   //take action on employees table like we did adition by Json 
        Employee GetEmployeeById(int id);  //detect employees by their Id.

        Employee DeleteEmployee(int id);   // detect employee by their Id
        Employee UpdateEmployee(Employee emp);
    }
}
