using System.ComponentModel.DataAnnotations;

namespace Tuckshop.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        [Required]
        [Display (Name="First Name")]
        [StringLength (50, MinimumLength =3)]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
         ErrorMessage = "Numbers and characters are not allowed.")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50, MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
         ErrorMessage = "Numbers and characters are not allowed.")]
        public string LastName { get; set; }
        [Display(Name = "Home Room")]
        
        public string Homeroom { get; set; }

        public ICollection<Request> Request { get; set; }

    }
}
