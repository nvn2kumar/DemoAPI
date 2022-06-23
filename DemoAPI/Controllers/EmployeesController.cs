using DemoAPI.Models;
using DemoAPI.Repository.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]              //unless we autharise we cannot access accountController
    public class EmployeesController : ControllerBase
    {
        private IEmployee employeeService;
        public EmployeesController(IEmployee employee)
        {
            employeeService = employee;
        }


        [HttpGet]
        [Route("GetAllEmployees")]
        public IActionResult GetAllEmployees()
        {
            var results = employeeService.GetEmployees();
            if (results.Count > 0)
            {

                return Ok(results);
            }
            else
            {
                return NotFound("Employee Not Found !");  //  404 error
            }

        }

        [HttpGet]
        [Route("GetEmployeeById/{id}")]
        public IActionResult GetEmployeeById(int id)
        { var results = employeeService.GetEmployeeById(id);
            if (results != null)
            {

                return Ok(results);
            }
            else
            {
                return NotFound("Employee Not Found !");  //  404 error
            }


        }

        [HttpPost]
        [Route("CreateEmployee")]
        public IActionResult Post(Employee employee)
        {
            var result = employeeService.PostEmployee(employee);
            if (result != null)
            {
                return Ok(result);
            }

            else
            {
                return Ok();    // passed null data

            }
        }

        [HttpDelete]
        [Route("DeleteEmployee/{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            else
            {
                var result= employeeService.DeleteEmployee(id);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound();
                
                }
            }


        }

        [HttpPut]
        [Route("UpdateEmployee")]
        public IActionResult Update(Employee emp)
        {
            if (emp == null)
            {
                return BadRequest();
            }
            else 
            {
                var result = employeeService.UpdateEmployee(emp);
                if (result != null)
                {
                    return Ok(result);

                }
                else
                {
                    return NotFound();
                }
            }
        
        
        }
    }
  
}
