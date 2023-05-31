namespace Tuckshop.Models
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public string PaymentName { get; set; }
        public int PaymentAmount { get; set; }
        public string PaymentStatement { get; set; }
        public ICollection<Student> Student { get; set; }
        public ICollection<Order> Order { get; set; }

    }
}
