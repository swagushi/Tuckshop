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
        [Display(Name = "Amount")]
        [Range(1, 100, ErrorMessage = "Please Enter atleast $1")]
        public int Amount { get; set; }
        public ICollection<Student> Student { get; set; }
        public ICollection<Payment> Payment { get; set; }
        public ICollection<Request> Request { get; set; }
    }
}
