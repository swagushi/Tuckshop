using System.ComponentModel.DataAnnotations;

namespace Tuckshop.Models
{
    public class Food
    {
        public int FoodID { get; set; }
        [Display(Name = "Food Name")]
        public string FoodName { get; set; }
        [Display(Name = "Drink Name")]
        public string DrinkName { get; set; }
        [Range(2, 10, ErrorMessage = "Please use values between $2 to $10")]
        public int Amount { get; set; }
        public ICollection<Student> Student { get; set; }
        public ICollection<Payment> Payment { get; set; }
    }
}
