using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace timesheet.model
{
    public class EmployeeTask
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Range(0, int.MaxValue)]
        public int EmployeeID { set; get; }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [NotMapped]
        public List<TaskTimeSheet> TimeSheets { set; get; }
    }
}
