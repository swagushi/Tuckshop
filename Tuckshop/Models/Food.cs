﻿using System.ComponentModel.DataAnnotations;

namespace Tuckshop.Models
{
    public class Food
    {
        public int FoodID { get; set; }
       
        //the user cannot create an order without selecting the FoodName field 
        [Display(Name = "Food Name")]
        //instead of seeing FoodName they will see Food Name
        public string FoodName { get; set; }

    
        //The user cannot create an order without selecting the DrinkName field 
        [Display(Name = "Drink Name")]
        //the user will see Drink Name instead of DrinkName
        public string DrinkName { get; set; }

        [Required]
        //The user cannot create an order without inputing something in the Amount field
        [Display(Name = "Food Amount")]
        //the user will see Food Amount instead of Amount
        [Range(1, 10000, ErrorMessage = "You must enter between $1-10,000")]
        //The user must input a number between $1 and $100, if they do they will see an error message
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }
        public ICollection<Request> Request { get; set; }
    }
}
