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
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
         ErrorMessage = "Characters are not allowed. And HR code must be 3 letters long")]
        public string Homeroom { get; set; }

        public ICollection<Request> Request { get; set; }

    }
}
