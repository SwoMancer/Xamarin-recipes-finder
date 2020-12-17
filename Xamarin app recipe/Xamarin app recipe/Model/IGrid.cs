using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin_app_recipe.Model
{
    interface IGrid
    {
        int MyRow { get; set; }
        int MyColumn { get; set; }
        void OrderGrid();
    }
}
