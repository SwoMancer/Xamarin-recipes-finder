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
        public List<IngredientInRecipe> IngredientListInRecipes
        {
            get
            {
                return ingredientInRecipes.ToList();
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
        public void ReplaceDataRang(ObservableCollection<IngredientInRecipe> ingredients)
        {
            ingredientInRecipes = ingredients;
        }
        public void ReplaceDataRang(List<IngredientInRecipe> ingredients)
        {
            ingredientInRecipes.Clear();
            AddDataRang(ingredients);
        }
        public void AddData(IngredientInRecipe ingredient)
        {
            ingredientInRecipes.Add(ingredient);
        }
        public void AddDataRang(List<IngredientInRecipe> ingredients)
        {
            foreach (IngredientInRecipe ingredientInRecipe in ingredients)
                AddData(ingredientInRecipe);
        }
        public void AddDataRang(ObservableCollection<IngredientInRecipe> ingredients)
        {
            foreach (IngredientInRecipe ingredient in ingredients)
                AddData(ingredient);
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
