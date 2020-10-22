using MyCooking.BLL.Models.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCooking.BLL.Models
{
    public class Ingredient : BaseEntity
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        [ForeignKey("Recipe")]
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}
