using System.ComponentModel.DataAnnotations;

namespace Tuckshop.Models
{
    public class Payment
    {
        public int PaymentID { get; set; }
        [Required]
        //the user cannot make a payment without filling out the PaymentName field 
        [Display(Name = "Payment Name")]
        //the user will see Payment Name instead of PaymentName
        [StringLength(50, MinimumLength = 3)]
        //The name the user will submit must be a minimum of 3 letters and a max of 50
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
            // the user cannot add any special characters only letters
         ErrorMessage = "Characters are not allowed.")]
        //if they do they will see this error message
        public string PaymentName { get; set; }

        [Required]
        //the user cannot make a payment without filling out the PaymentAmount field 
        [Display(Name = "Payment Amount")]
        //the user will see Payment Amount instead of PaymentAmount
        [Range(1,100, ErrorMessage ="Please Enter between $1 and $100")]
        //the user can only add a min of 1 and a max of 100
        [DataType(DataType.Currency)]
        //when the user makes a payment infront of the number will be a $
        public decimal PaymentAmount { get; set; }

        [Required]
        //the user cannot make a payment without filling out the Payment statement field 
        [Display(Name = "Payment Statement")]
        //the user will see Payment Statement instead of PaymentStatement
        [StringLength(50, MinimumLength = 3)]
        //When making their payment statement the minimum must be 3 and the max must be 50
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
        //the user cannot use special characters while making the payment statement 
         ErrorMessage = "Characters are not allowed.")]
        //if they do they will see this error message
        public string PaymentStatement { get; set; }
        public ICollection<Student> Student { get; set; }
        public ICollection<Request> Request { get; set; }

    }
}
