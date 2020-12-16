using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace timesheet.model
{ 
    public class TaskTimeSheet
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Range(0, int.MaxValue)]
        [Required]
        public int TaskId { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime Date { get; set; }

        [Range(0, double.MaxValue)]
        [Required]
        public double Hours { get; set; } 
    }
}
