using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin_app_recipe.Model;

namespace Xamarin_app_recipe.ViewModel
{
    public class IngredientInRecipeViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<IngredientInRecipe> ingredientInRecipes = 
            new ObservableCollection<IngredientInRecipe>();

        public ObservableCollection<IngredientInRecipe> IngredientInRecipes
        {
            get
            {
                return this.ingredientInRecipes;
            }
        }
        public string Title
        {
            get
            {
                return "Ingredients:";
            }
        }
        #region CURD
        #region Create
        public void LoadDataRang(ObservableCollection<IngredientInRecipe> ingredients)
        {
            ingredientInRecipes = ingredients;
        }
        public void LoadDataRang(List<IngredientInRecipe> ingredients)
        {
            ingredientInRecipes.Clear();
            LoadAddDataRang(ingredients);
        }
        public void LoadAddDataRang(List<IngredientInRecipe> ingredients)
        {
            foreach (IngredientInRecipe ingredientInRecipe in ingredients)
                ingredientInRecipes.Add(ingredientInRecipe);
        }
        public void LoadAddDataRang(ObservableCollection<IngredientInRecipe> ingredients)
        {
            foreach (IngredientInRecipe ingredient in ingredients)
                ingredientInRecipes.Add(ingredient);
        }
        #endregion
        #region Read
        public ObservableCollection<IngredientInRecipe> GetAllData()
        {
            return this.ingredientInRecipes;
        }
        public IngredientInRecipe GetDataItem(int id)
        {
            if (this.ingredientInRecipes.Where(i => i.Id == id).Count() == 0)
                return new IngredientInRecipe();

            return this.ingredientInRecipes.Where(i => i.Id == id).FirstOrDefault();
        }
        #endregion
        #region Update
        public void EditDataItem(int id, IngredientInRecipe ingredient)
        {
            if (this.ingredientInRecipes.Where(i => i.Id == id).Count() == 0)
                return;

            ingredient.Id = id;

            this.ingredientInRecipes[ingredientInRecipes
                .IndexOf(ingredientInRecipes
                .Where(i => i.Id == id)
                .FirstOrDefault())] = ingredient;
        }
        #endregion
        #region Delete
        public void RemoveDataItem(int id)
        {
            if (this.ingredientInRecipes.Where(i => i.Id == id).Count() == 0)
                return;


        }
        public void RemoveDataItem(IngredientInRecipe ingredient)
        {
            if (!this.ingredientInRecipes.Contains(ingredient))
                return;

            ingredientInRecipes.Remove(ingredient);
        }
        #endregion
        #endregion
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
