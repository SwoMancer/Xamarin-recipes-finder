using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin_app_recipe.ViewModel;

namespace Xamarin_app_recipe.Model
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string HrefToSide { get; set; }
        public string HerfToThumbnail { get; set; }
        //public List<IngredientInRecipe> ChildIngredients { get; set; } = new List<IngredientInRecipe>();
        public IngredientInRecipeViewModel IngredientInRecipeModel { get; set; } = new IngredientInRecipeViewModel();
        public ObservableCollection<IngredientInRecipe> JumpIngredientInRecipes
        {
            get
            {
                return this.IngredientInRecipeModel.IngredientInRecipes;
            }
        }
    }
}
