using System.ComponentModel.DataAnnotations;

namespace Tuckshop.Models
{
  public class Order
    {
        public int OrderID { get; set; }
        [Display(Name = "Order Name")]
        [StringLength(50, MinimumLength = 3)]
        public string OrderName { get; set; }
        [Display(Name = "Order Number")]
        public int OrderNumber { get; set; }
        [Display(Name = "Date Ordered")]
        public DateTime DateOrdered { get; set; }
        public ICollection<Student> Student { get; set; }
        public ICollection<Food> Food { get; set; }
    }
}
