using System;
using System.Collections.Generic;
using System.Linq;
using timesheet.data;
using timesheet.model;

namespace timesheet.business
{
    public class EmployeeService
    {
        public TimesheetDb db { get; }
        public EmployeeService(TimesheetDb dbContext)
        {
            this.db = dbContext;
        }

        /// <summary>
        /// Get All Employees from database 
        /// </summary>
        /// <returns></returns>
        public IQueryable<Employee> GetEmployees()
        {
            return this.db.Employees;
        }
         
        /// <summary>
        /// Get Tasks List of an Employee with Respect to Dates/Week
        /// </summary>
        /// <param name="EmployeeID"></param>
        /// <param name="From"></param>
        /// <param name="To"></param>
        /// <returns></returns>
        public IQueryable<EmployeeTask> GetEmployeeTasks(int EmployeeID, DateTime From, DateTime To)
        {
            IQueryable<EmployeeTask> Response = null;
            try
            {
                Response = this.db.EmployeeTask.Where(p => p.EmployeeID == EmployeeID);
                foreach (var Task in Response)
                {
                    try
                    {
                        Task.TimeSheets = new System.Collections.Generic.List<TaskTimeSheet>();
                        Task.TimeSheets.Add(new TaskTimeSheet() { Id = 0, Date = From, Hours = 0 });
                        Task.TimeSheets.Add(new TaskTimeSheet() { Id = 0, Date = From.AddDays(1), Hours = 0 });
                        Task.TimeSheets.Add(new TaskTimeSheet() { Id = 0, Date = From.AddDays(2), Hours = 0 });
                        Task.TimeSheets.Add(new TaskTimeSheet() { Id = 0, Date = From.AddDays(3), Hours = 0 });
                        Task.TimeSheets.Add(new TaskTimeSheet() { Id = 0, Date = From.AddDays(4), Hours = 0 });
                        Task.TimeSheets.Add(new TaskTimeSheet() { Id = 0, Date = From.AddDays(5), Hours = 0 });
                        Task.TimeSheets.Add(new TaskTimeSheet() { Id = 0, Date = From.AddDays(6), Hours = 0 });

                        var TimeSheets = this.db.TaskTimeSheet.Where(p => p.TaskId == Task.Id && p.Date >= From && p.Date <= To).ToList();
                        foreach (var sheet in TimeSheets)
                        {
                            Task.TimeSheets.Where(p => p.Date == sheet.Date).First().Id = sheet.Id;
                            Task.TimeSheets.Where(p => p.Date == sheet.Date).First().Hours = sheet.Hours;
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
            catch (Exception ex)
            {

            }
            return Response;
        }
         
        /// <summary>
        /// Update Time Sheet of all Tasks for Employee
        /// </summary>
        /// <param name="_Task"></param>
        /// <returns></returns>
        public string UpdateTimeSheets(List<EmployeeTask> _Task)
        {
            string Response = string.Empty;
            try
            {
                foreach (EmployeeTask task in _Task)
                {
                    foreach (TaskTimeSheet sheet in task.TimeSheets)
                    {
                        if (sheet.Id == 0)
                        {
                            sheet.TaskId = task.Id;
                            db.TaskTimeSheet.Add(sheet);
                        }
                        else
                        { 
                            db.Entry(sheet).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        }
                        db.SaveChanges();
                    }
                }
                Response = "SUCCESS";
            }
            catch (Exception ex)
            {

            }
            return Response;
        } 
    }
}