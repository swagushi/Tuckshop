using System.ComponentModel.DataAnnotations;

namespace Tuckshop.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        [Required]
        //admin cannot add a student without filling out the firstname field 
        [Display (Name="First Name")]
        //when the admin goes to the web page instead of seeing "FirstName" they will see First Name
        [StringLength (50, MinimumLength =3)]
        //admin cannot create a student who has less than 3 letters in their name or more than 50 letters in their name
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
        //admin cannot add special characters or number but must instead add letters
         ErrorMessage = "Numbers and characters are not allowed.")]
        // if the admin adds special characters or numbers they will be shown this error message
        public string FirstName { get; set; }

        [Required]
        //admin cannot add a student without submitting their Lastname
        [Display(Name = "Last Name")]
        //when the admin goes to the web page instead of seeing "LastName" they will see Last Name
        [StringLength(50, MinimumLength = 3)]
        //admin cannot create a student who has less than 3 letters in their name or more than 50 letters in their name
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
         //admin cannot add special characters or number but must instead add letters
         ErrorMessage = "Numbers and characters are not allowed.")]
        // if the admin adds special characters or numbers they will be shown this error message
        public string LastName { get; set; }


        [Display(Name = "Home Room")]
        //when the admin goes to the web page instead of seeing "LastName" they will see Last Name
        public string Homeroom { get; set; }

        public ICollection<Request> Request { get; set; }

    }
}
