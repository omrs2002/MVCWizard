using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MVCWizard.Web.Models
{
    public class EmployeeDto
    {

        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "Name required")]
        public string FullName { get; set; }


        [Required(ErrorMessage = "Date Of Birth required")]
        [BindProperty, DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Gender required")]
        public string Gender { get; set; }


        [Required(ErrorMessage = "Dept required")]
        public string Dept { get; set; }

        [Required(ErrorMessage = "Salary required")]
        public double Salary { get; set; }


        [Required(ErrorMessage = "Date Of Start required")]
        [DataType(DataType.Date)]
        [BindProperty, DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yyyy}")]
        public DateTime DateOfStart { get; set; }


        [Required(ErrorMessage = "Bio required")]
        public string Bio { get; set; }

        [Required]
        public bool CompletionStatus { get; set; } = false;
    }
}
