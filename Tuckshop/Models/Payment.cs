using System.ComponentModel.DataAnnotations;

namespace Tuckshop.Models
{
    public class Payment
    {
        public int PaymentID { get; set; }
        [Display(Name = "Payment Name")]
        [StringLength(50, MinimumLength = 3)]
        public string PaymentName { get; set; }
        [Display(Name = "Payment Amount")]
        [Range(1,100, ErrorMessage ="Please Enter atleast $1")]
        public int PaymentAmount { get; set; }
        [Display(Name = "Payment Statement")]
        [StringLength(50, MinimumLength = 3)]
        public string PaymentStatement { get; set; }
        public ICollection<Student> Student { get; set; }
        public ICollection<Order> Order { get; set; }

    }
}
