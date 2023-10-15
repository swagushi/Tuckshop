using System.ComponentModel.DataAnnotations;

namespace Tuckshop.Models
{
    public class Request
    {
        public int RequestID { get; set; }

        [Required]
        //the user cannot create an order without filling out the OrderNumber field 
        [Display(Name = "Order Number")]
        //When the user sees the page they will see Order Number instead of OrderNumber
        [Range(1, 1000, ErrorMessage = "Please Enter a value between 1 and 1000")]
        //The user can choose a number from 1-1000, but not anything above or below
        public int OrderNumber { get; set; }

        [Display(Name = "Date Ordered")]
        //When the user sees the page they will see Date Ordered instead of DateOrdered
        [Required]
        //the user cannot create an order without filling out the DateOrdered field 
        [DataType(DataType.Date)]
        //The user will only have to enter the date instead of the date and time 
        public DateTime DateOrdered { get; set; }

        public int FoodID { get; set; }
        public int StudentID { get; set; }
       

        public Student Student { get; set; }
        public Food Food { get; set; }
       
    }
}
    