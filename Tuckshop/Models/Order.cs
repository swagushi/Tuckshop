namespace Tuckshop.Models
{
  public class Order
    {
        public int OrderID { get; set; }
        public string OrderName { get; set; }
        public int OrderNumber { get; set; }

        public ICollection<Student> Student { get; set; }
    }
}
