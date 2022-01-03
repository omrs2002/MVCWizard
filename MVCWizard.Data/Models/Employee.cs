using System.ComponentModel.DataAnnotations;

namespace MVCWizard.Data.Models
{
    public class Employee
    {

        [Key]
        public int Id { get; set; }


        [Required]
        public string FullName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Gender { get; set; }


        [Required]
        public string Dept { get; set; }

        [Required]
        public double Salary { get; set; }


        [Required]
        public DateTime  DateOfStart { get; set; }


        [Required]
        public string Bio { get; set; }

        [Required]
        public bool CompletionStatus { get; set; } = false;
    }
}
