using Microsoft.EntityFrameworkCore;
using System;
using timesheet.model;

namespace timesheet.data
{
    public class TimesheetDb : DbContext
    {
        public TimesheetDb(DbContextOptions<TimesheetDb> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeTask> EmployeeTask { get; set; }
        public DbSet<TaskTimeSheet> TaskTimeSheet { get; set; }
    }
}
