using System.ComponentModel.DataAnnotations;

namespace Tuckshop.Models
{
    public class Payment
    {
        public int PaymentID { get; set; }
        [Display(Name = "Payment Name")]
        [StringLength(50, MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
         ErrorMessage = "Characters are not allowed.")]
        public string PaymentName { get; set; }
        [Display(Name = "Payment Amount")]
        [Range(1,100, ErrorMessage ="Please Enter between $1 and $100")]
        public int PaymentAmount { get; set; }
        [Display(Name = "Payment Statement")]
        [StringLength(50, MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
         ErrorMessage = "Characters are not allowed.")]
        public string PaymentStatement { get; set; }
        public ICollection<Student> Student { get; set; }
        public ICollection<Request> Request { get; set; }

    }
}
