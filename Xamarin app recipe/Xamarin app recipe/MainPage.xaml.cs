using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin_app_recipe.Model;
using Xamarin.Essentials;

namespace Xamarin_app_recipe
{
    public partial class MainPage : ContentPage
    {
        #region items
        List<Ingredient> ingredients = new List<Ingredient>();
        List<Recipe> recipes = new List<Recipe>();
        private readonly Random random = new Random();
        #endregion

        public MainPage()
        {
            InitializeComponent();
            LoadRandomItems();
        }

        private void LoadRandomItems()
        {
            ingredients = API.DummyRecipepuppy.RandomIngredients(3);
            recipes = API.DummyRecipepuppy.RandomRecipes(2);

            ingredients = ingredients.OrderBy(n => n.Name).ThenBy(p => p.IsADemandItem).ToList();
            UpdateIntegrityIngredientsList();

            listOfIngredients.ItemsSource = ingredients;
            listOfRecipes.ItemsSource = recipes;
        }
        private void UpdateIntegrityIngredientsList()
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
        private void UpdateIngredientsView()
        {
            listOfIngredients.ItemsSource = null;
            listOfIngredients.ItemsSource = ingredients;
        }
        private void UpdateRecipesView()
        {
            if (recipes.Count <= 0)
                return;

            listOfRecipes.ItemsSource = null;
            listOfRecipes.ItemsSource = recipes;
        }
        private void CreateIngredient(bool isADemandItem)
        {
            Ingredient ingredient = new Ingredient();
            string input = entryInput.Text;

            if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
                return;

            input = input.Trim(new char[] { ' ', ',', '+', '-' }).ToLower();
            //Spelar inte så stor roll med id men...
            ingredient.Id = random.Next(0, 1000000);
            ingredient.Name = input;
            ingredient.IsADemandItem = isADemandItem;

            entryInput.Text = string.Empty;
            entryInput.Placeholder = input;

            ingredients.Add(ingredient);
        }
        private async System.Threading.Tasks.Task OpenLink(string link)
        {
            try
            {
                await Browser.OpenAsync(link, BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Exception", link + "\n" + ex.ToString(), "Oki doki :<");
            }
        }
        #region gen event
        private void listOfIngredients_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is null)
                return;

            Ingredient selectedIngredient = (Ingredient)e.SelectedItem;

            //ingredients.Remove(ingredients.Where(n => n.Name == selectedIngredient.Name && n.Id == selectedIngredient.Id).FirstOrDefault());
            ingredients.Remove(selectedIngredient);
            UpdateIngredientsView();
        }
        private async void listOfRecipes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is null)
                return;

            Recipe selectedRecipe = (Recipe)e.SelectedItem;

            await OpenLink(selectedRecipe.HrefToSide);
        }
        private void btnAdd_Clicked(object sender, EventArgs e)
        {
            CreateIngredient(true);
            UpdateIntegrityIngredientsList();
            UpdateIngredientsView();
        }
        private void btnBan_Clicked(object sender, EventArgs e)
        {
            CreateIngredient(false);
            UpdateIntegrityIngredientsList();
            UpdateIngredientsView();
        }
        private void btnFindRecipes_Clicked(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
