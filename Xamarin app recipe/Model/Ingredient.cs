using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin_app_recipe.Model
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsADemandItem { get; set; }
        public string Color
        {
            get
            {
                if (this.IsADemandItem)
                    return "#00FA9A";
                return "#fa2600";
            }
        }
        public char Prefix 
        { 
            get
            {
                if (this.IsADemandItem)
                    return '+';
                return '-';
            } 
        }
        public string ItemName
        {
            get
            {
                return this.Prefix + " " + this.Name;
            }
        }
    }
}
