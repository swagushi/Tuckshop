using System.ComponentModel.DataAnnotations;

namespace Tuckshop.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        [Display (Name="First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Home Room")]

        public string Homeroom { get; set; }

    }
}
