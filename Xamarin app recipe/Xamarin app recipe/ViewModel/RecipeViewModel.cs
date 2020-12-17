using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin_app_recipe.Model;

namespace Xamarin_app_recipe.ViewModel
{
    public class RecipeViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Recipe> recipes =
           new ObservableCollection<Recipe>();

        public ObservableCollection<Recipe> Recipes
        {
            get
            {
                return this.recipes;
            }
        }

        #region CURD
        #region Create
        public void AddData(Recipe recipe)
        {
            recipes.Add(recipe);
        }
        public void ReplaceDataRang(ObservableCollection<Recipe> recipesInput)
        {
            recipes = recipesInput;
        }
        public void ReplaceDataRang(List<Recipe> recipesInput)
        {
            foreach (Recipe item in recipesInput)
                AddData(item);
        }
        public void AddDataRang(ObservableCollection<Recipe> recipesInput)
        {
            foreach (Recipe recipe in recipesInput)
                AddData(recipe);
        }
        #endregion
        #region Read
        public ObservableCollection<Recipe> GetAllData()
        {
            return this.recipes;
        }
        public Recipe GetDataItem(int id)
        {
            if (this.recipes.Where(i => i.Id == id).Count() == 0)
                return new Recipe();

            return this.recipes.Where(i => i.Id == id).FirstOrDefault();
        }
        #endregion
        #region Update
        public void EditDataItem(int id, Recipe recipe)
        {
            if (this.recipes.Where(i => i.Id == id).Count() == 0)
                return;

            recipe.Id = id;

            this.recipes[recipes
                .IndexOf(recipes
                .Where(i => i.Id == id)
                .FirstOrDefault())] = recipe;
        }
        #endregion
        #region Delete
        public void RemoveDataItem(int id)
        {
            if (this.recipes.Where(i => i.Id == id).Count() == 0)
                return;


        }
        public void RemoveDataItem(Recipe recipe)
        {
            if (!this.recipes.Contains(recipe))
                return;

            recipes.Remove(recipe);
        }
        #endregion
        #endregion
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
