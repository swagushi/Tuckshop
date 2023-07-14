using System.ComponentModel.DataAnnotations;

namespace Tuckshop.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        [Display (Name="First Name")]
        [StringLength (50, MinimumLength =3)]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [StringLength(50, MinimumLength = 3)]
        public string LastName { get; set; }
        [Display(Name = "Home Room")]
        [StringLength(3)]
        [RegularExpression(@"^[A-Z]{3}$", ErrorMessage = "Homeroom code cannot be more than 3 letters, and must be entered in all caps.")]
        public string Homeroom { get; set; }
        public ICollection<Order> Order { get; set; }

    }
}
