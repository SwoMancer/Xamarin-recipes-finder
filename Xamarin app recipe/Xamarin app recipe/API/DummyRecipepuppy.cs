using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin_app_recipe.Model;

namespace Xamarin_app_recipe.API
{
    public static class DummyRecipepuppy
    {
        #region Testing
        private static Random random = new Random();
        private static string[] texts = "tomato, onions, red pepper, garlic, olive oil, zucchini, cream cheese, vermicelli, eggs, parmesan cheese, milk, italian seasoning, salt, black pepper, eggs, salt, black pepper, butter, black pepper, bacon, onions, garlic, roasted red peppers, oregano, black pepper, eggs, broccoli, onions, parmesan cheese, lowfat milk, salt, basil, garlic, tomato, parmesan cheese, caraway seed, coriander, eggplant, eggs, garlic, lemon, olive oil, onions, black pepper, salt, eggplant, olive oil, onions, garlic, egg, caraway seed, coriander, salt, black pepper, lemon, onions, garlic, chicken broth, cottage cheese, oregano, black pepper, egg substitute, bread, mozzarella cheese, butter, olive oil, onions, leaves, garlic, eggs, parsley, basil, thyme, gruyere cheese, parmesan cheese, eggs, garlic, parmesan cheese, olive oil, onions, peas, potato, red pepper, salt, tomato, zucchini, vegetable oil, green pepper, onions, water, milk, eggs, black pepper, mushroom, garlic, salt, chili powder, egg substitute, milk, parsley, thyme, salt, black pepper, eggs, flour, nonstick cooking spray, onions, garlic, salad greens, salad greens, red wine vinegar, olive oil, goat cheese, almonds".Split(',').Distinct().ToArray();
        private static string[] imagesLinks = new string[] { "https://picsum.photos/200",
            "https://i.picsum.photos/id/44/200/200.jpg?hmac=W5KcqhapHjBgEIHGQpQnX6o9jdOXQEVCKEdGIohjisY", 
            "https://i.picsum.photos/id/616/200/200.jpg?hmac=QEzyEzU6nVn4d_vdALhsT9UAtTUEVhwrT-kM5ogBqKM", 
            "https://i.picsum.photos/id/312/200/200.jpg?hmac=5WzBp3yXad4TGeGL1pX1DTzSXpn84Ftmc3dwkukuHEk" };
        #region Random lists
        public static List<Recipe> RandomRecipes(int max)
        {
            List<Recipe> recipes = new List<Recipe>();

            for (int i = 0; i < max; i++)
                recipes.Add(RandomRecipe(i));
            
            return recipes;
        }
        public static List<Ingredient> RandomIngredients(int max)
        {
            List<Ingredient> Ingredients = new List<Ingredient>();
            
            for (int i = 0; i < max; i++)
            {
                Ingredients.Add(RandomIngredient(i));
            }
            return Ingredients;
        }
        #endregion
        #region Random Items
        public static Recipe RandomRecipe(int i)
        {
            Recipe recipe = new Recipe();
            recipe.Id = i;
            recipe.HerfToThumbnail = imagesLinks[random.Next(0, imagesLinks.Length - 1)];
            recipe.HrefToSide = "https://155.4.70.67/API/Logging";
            recipe.Name = RandomName();
            for (int j = 0; j < random.Next(5, 34); j++)
                recipe.ChildIngredients.Add(new IngredientInRecipe(RandomIngredient(j)));
            
            return recipe;
        }

        private static string RandomName()
        {
            return texts[random.Next(0, texts.Length - 1)].Trim();
        }

        public static Ingredient RandomIngredient(int i)
        {
            Ingredient ingredient = new Ingredient();

            ingredient.Id = i;
            ingredient.IsADemandItem = random.Next(0, 2) != 0;
            ingredient.Name = RandomName();

            return ingredient;
        }
        #endregion
        #endregion
    }
}
