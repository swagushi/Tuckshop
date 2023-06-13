using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Tuckshop.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        [Display (Name="First Name")]
        [StringLength(30, MinimumLength = 3)]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [StringLength(30, MinimumLength = 3)]
        public string LastName { get; set; }
        [Display(Name = "Home Room")]

        public List<SelectListItem> Homeroom { get; set; }

    }
}
