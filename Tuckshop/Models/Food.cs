namespace Tuckshop.Models
{
    public class Food
    {
        public int FoodID { get; set; }
        public string FoodName { get; set; }
        public string DrinkName { get; set; }
        public int Amount { get; set; }
        public ICollection<Student> Student { get; set; }
        public ICollection<Payment> Payment { get; set; }
    }
}
