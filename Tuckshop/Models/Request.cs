using System.ComponentModel.DataAnnotations;

namespace Tuckshop.Models
{
    public class Request
    {
        public int RequestID { get; set; }
        [Display(Name = "Order Name")]
        [StringLength(50, MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
         ErrorMessage = "Characters are not allowed.")]
        public string OrderName { get; set; }
        [Display(Name = "Order Number")]
        [Range(1, 1000, ErrorMessage = "Please Enter between $1 and $100")]
        public int OrderNumber { get; set; }
        [Display(Name = "Date Ordered")]
        public DateTime DateOrdered { get; set; }
        public ICollection<Student> Student { get; set; }
        public ICollection<Food> Food { get; set; }
    }
}
