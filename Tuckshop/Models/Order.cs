using System.ComponentModel.DataAnnotations;

namespace Tuckshop.Models
{
  public class Order
    {
        public int OrderID { get; set; }
        [Display(Name = "Order Name")]
        public string OrderName { get; set; }
        [Display(Name = "Order Number")]
        public int OrderNumber { get; set; }

        public ICollection<Student> Student { get; set; }
    }
}
