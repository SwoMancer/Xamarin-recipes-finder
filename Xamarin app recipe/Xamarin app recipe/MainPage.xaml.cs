using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin_app_recipe.Model;
using Xamarin.Essentials;
using Xamarin_app_recipe.ViewModel;

namespace Xamarin_app_recipe
{
    public partial class MainPage : ContentPage
    {
        #region items
        public static RecipeViewModel recipeModel { get; set; } = new RecipeViewModel();
        public static IngredientViewModel ingredientModel { get; set; } = new IngredientViewModel();


        private readonly Random random = new Random();
        #endregion

        public MainPage()
        {
            InitializeComponent();
            LoadRandomItems();
        }

        private void LoadRandomItems()
        {
            ingredientModel.ReplaceDataRang(API.DummyRecipepuppy.RandomIngredients(7));
            recipeModel.ReplaceDataRang(API.DummyRecipepuppy.RandomRecipes(3));

            ingredientModel.SortMe();
            ingredientModel.UpdateIntegrity();

            //BindingContext = ingredientModel;
            //BindingContext = recipeModel;
            listOfIngredients.ItemsSource = ingredientModel.Ingredients;
            listOfRecipes.ItemsSource = recipeModel.Recipes;
        }
        /*
        private void UpdateIngredientsView()
        {
            listOfIngredients.ItemsSource = null;
            listOfIngredients.ItemsSource = ingredients;
        }
        */
        
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
            ingredientModel.RemoveDataItem(selectedIngredient);
            //UpdateIngredientsView();
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
            ingredientModel.Create(entryInput, true);
        }
        private void btnBan_Clicked(object sender, EventArgs e)
        {
            ingredientModel.Create(entryInput, false);
        }
        private void btnFindRecipes_Clicked(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
