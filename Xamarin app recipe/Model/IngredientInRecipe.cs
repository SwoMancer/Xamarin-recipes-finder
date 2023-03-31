using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin_app_recipe.Model
{
    public class IngredientInRecipe : IGrid
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MyRow { get; set; }
        public int MyColumn { get; set; }

        public IngredientInRecipe() { }
        public IngredientInRecipe(Ingredient ingredient) 
        {
            this.Id = ingredient.Id;
            this.Name = ingredient.Name;
            OrderGrid();
        }

        public void OrderGrid()
        {
            int itemsPerColumn = 6;
            int orderNumnber = this.Id + 1;

            
            if (orderNumnber <= itemsPerColumn - 1)
            {
                this.MyRow = 0;
                this.MyColumn = orderNumnber - 1;

            }
            else
            {
                int x = 0, y = 0, 
                    tempOrderNumnber = orderNumnber;
                
                while (tempOrderNumnber > itemsPerColumn)
                {
                    tempOrderNumnber = tempOrderNumnber - itemsPerColumn;
                    y++;
                }

                x = tempOrderNumnber;

                this.MyRow = y;
                this.MyColumn = x - 1;
            }
        }
    }
}
