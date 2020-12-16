using System;
using System.Collections.Generic; 
using Microsoft.AspNetCore.Mvc;
using timesheet.business;
using timesheet.model;

namespace timesheet.api.controllers
{
    [Route("api/v1/employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService employeeService;
        public EmployeeController(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        /// <summary>
        /// Get All Employees List Api api/v1/employees/all
        /// </summary>
        /// <returns></returns>
        [HttpGet("all")]
        public IActionResult All()
        { 
            return new ObjectResult(this.employeeService.GetEmployees()); ;
        }

        /// <summary>
        /// Get Task List of an Employee with respect to Dates/Week 
        /// api/v1/employees/get_tasks
        /// </summary>
        /// <param name="employee_id"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        [HttpGet("get_tasks")]
        public IActionResult GetTasks(int employee_id, DateTime from, DateTime to)
        { 
            return new ObjectResult(this.employeeService.GetEmployeeTasks(employee_id, from, to));
        }

        /// <summary>
        /// Update Time Sheets of All Tasks of Selected Employee
        /// </summary>
        /// <param name="Tasks"></param>
        /// <returns></returns>
        [HttpPost("update")]
        public IActionResult UpdateTimeSheets([FromBody]List<EmployeeTask> Tasks)
        { 
            return new ObjectResult(this.employeeService.UpdateTimeSheets(Tasks));
        }
    }
}