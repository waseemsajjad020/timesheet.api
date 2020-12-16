using Microsoft.EntityFrameworkCore.Migrations;

namespace timesheet.data.Migrations
{
    public partial class task_seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                INSERT INTO EmployeeTask Values('Sick Leave', 'Apply this task on sick leave.',1)
                INSERT INTO EmployeeTask Values('Scrum Ceremonies', 'Scrum meetings, standup, sprint plannig, grooming etc.',2)
                INSERT INTO EmployeeTask Values('Internal Meeting', 'Meetings Meetings.',3)
                INSERT INTO EmployeeTask Values('Development', 'Development tasks, features, change requets.',1)
                INSERT INTO EmployeeTask Values('Bug Fixes', 'You know what it means.',1)
                  GO  ");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
