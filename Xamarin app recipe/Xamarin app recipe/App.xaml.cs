using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin_app_recipe.ViewModel;

namespace Xamarin_app_recipe
{
    public partial class App : Application
    {
        
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
