using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCWizard.Web.Models
{
    public class EmployeeDto
    {

        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "Name required")]
        public string? FullName { get; set; }


        [Required(ErrorMessage = "Date Of Birth required")]
        [BindProperty]
        //"{0:yyyy-MM-dd}"
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Gender required")]
        public int Gender { get; set; }


        [Required(ErrorMessage = "Dept required")]
        public string? Dept { get; set; }

        [Required(ErrorMessage = "Salary required")]
        public double Salary { get; set; }


        [Required(ErrorMessage = "Date Of Start required")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]

        public DateTime DateOfStart { get; set; }


        [Required(ErrorMessage = "Bio required")]
        [DataType(DataType.MultilineText)]
        public string? Bio { get; set; }

        [Required]
        [Range(1, 2)]
        public int CompletionStatus { get; set; } = 1;


        [Required(ErrorMessage = "Date Of Birth required")]
        [DisplayName("Date Of Birth")]
        public string DateOfBirthAsString
        {
            get
            {
                return DateOfBirth.ToString("dd-MM-yyyy");
            }
            set
            {
                DateOfBirth = DateTime.Parse(value);
            }
        }

        [Required(ErrorMessage = "Date Of Start required")]
        [DisplayName("Date Of Start")]
        public string DateOfStartAsString
        {
            get
            {
                return DateOfStart.ToString("dd-MM-yyyy");
            }
            set
            {
                DateOfStart = DateTime.Parse(value);
            }
        }

        public SelectList GenderList
        {
            get
            {
               IList<object> gender_list = new List<object>()
               {
                    new  { ID="1",Name="Male"}, 
                    new { ID = "2", Name = "Female" } 
               };
                return new SelectList(gender_list, "ID", "Name");

            }
        }

    }
}
