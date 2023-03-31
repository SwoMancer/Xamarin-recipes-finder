using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin_app_recipe.Model;

namespace Xamarin_app_recipe.ViewModel
{
    public class IngredientViewModel : INotifyPropertyChanged
    {
        private readonly Random random = new Random();
        private ObservableCollection<Ingredient> ingredients =
           new ObservableCollection<Ingredient>();

        public ObservableCollection<Ingredient> Ingredients
        {
            get
            {
                return ingredients;
            }
        }
        #region CURD
        #region Create

        public void AddData(Ingredient ingredient)
        {
            ingredients.Add(ingredient);
        }
        public void ReplaceDataRang(ObservableCollection<Ingredient> ingredientsInput)
        {
            ingredients = ingredientsInput;
        }
        public void ReplaceDataRang(List<Ingredient> ingredientsInput)
        {
            foreach (Ingredient item in ingredientsInput)
                AddData(item);
        }
        public void AddDataRang(ObservableCollection<Ingredient> ingredientsInput)
        {
            foreach (Ingredient item in ingredientsInput)
                AddData(item);
        }
        public void Create(Entry entry, bool isADemandItem)
        {
            Ingredient ingredient = new Ingredient();
            string input = entry.Text;

            if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
                return;

            input = input.Trim(new char[] { ' ', ',', '+', '-' }).ToLower();
            //Spelar inte så stor roll med id men...
            ingredient.Id = random.Next(0, 1000000);
            ingredient.Name = input;
            ingredient.IsADemandItem = isADemandItem;

            entry.Text = string.Empty;
            entry.Placeholder = input;

            AddData(ingredient);
            UpdateIntegrity();
        }
        #endregion
        #region Read
        public ObservableCollection<Ingredient> GetAllData()
        {
            return ingredients;
        }
        public Ingredient GetDataItem(int id)
        {
            if (ingredients.Where(i => i.Id == id).Count() == 0)
                return new Ingredient();

            return ingredients.Where(i => i.Id == id).FirstOrDefault();
        }
        #endregion
        #region Update
        public void EditDataItem(int id, Ingredient ingredient)
        {
            if (this.ingredients.Where(i => i.Id == id).Count() == 0)
                return;

            ingredient.Id = id;

            this.ingredients[ingredients
                .IndexOf(ingredients
                .Where(i => i.Id == id)
                .FirstOrDefault())] = ingredient;
        }
        #endregion
        #region Delete
        public void RemoveDataItem(int id)
        {
            if (ingredients.Where(i => i.Id == id).Count() == 0)
                return;
        }
        public void RemoveDataItem(Ingredient ingredient)
        {
            if (!this.ingredients.Contains(ingredient))
                return;

            ingredients.Remove(ingredient);
        }
        #endregion
        #endregion

        #region Funcs
        #region Sort
        public void SortMe()
        {
            ReplaceDataRang(ingredients
                .OrderBy(n => n.Name)
                .ThenBy(p => p.IsADemandItem)
                .ToList());
        }
        #endregion
        #region Clean
        public void UpdateIntegrity()
        {
            if (ingredients.Count <= 1)
                return;

            List<Ingredient> deletesIngredients = new List<Ingredient>();

            foreach (Ingredient ingredient in ingredients)
            {
                //Hitta om det finns flera med samma namn.
                List<Ingredient> tempIngredients = ingredients.Where(n => n.Name == ingredient.Name).ToList();

                if (tempIngredients is null)
                    return;

                if (tempIngredients.Count() == 2)
                {
                    if (tempIngredients[0].Prefix == tempIngredients[1].Prefix)
                    {
                        deletesIngredients.Add(tempIngredients[1]);
                    }
                    else
                    {
                        deletesIngredients.Add(tempIngredients[0]);
                        deletesIngredients.Add(tempIngredients[1]);
                    }
                }
                else if (tempIngredients.Count() >= 3)
                {
                    int plus, minus;

                    plus = tempIngredients.Where(p => p.IsADemandItem).Count();
                    minus = tempIngredients.Where(p => !p.IsADemandItem).Count();

                    if (plus == minus)
                    {
                        deletesIngredients.AddRange(tempIngredients);
                    }
                    else if (plus > minus)
                    {
                        tempIngredients.Remove(tempIngredients.Where(p => p.IsADemandItem).FirstOrDefault());
                        deletesIngredients.AddRange(tempIngredients);
                    }
                    else if (plus < minus)
                    {
                        tempIngredients.Remove(tempIngredients.Where(p => !p.IsADemandItem).FirstOrDefault());
                        deletesIngredients.AddRange(tempIngredients);
                    }
                }
            }

            if (deletesIngredients is null || deletesIngredients.Count == 0)
                return;

            deletesIngredients = deletesIngredients.Distinct().ToList();

            foreach (Ingredient beDelete in deletesIngredients)
                ingredients.Remove(beDelete);

        }
        #endregion
        #endregion
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
