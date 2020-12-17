using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin_app_recipe.Model
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string HrefToSide { get; set; }
        public string HerfToThumbnail { get; set; }
        public List<IngredientInRecipe> ChildIngredients { get; set; } = new List<IngredientInRecipe>();
    }
}
