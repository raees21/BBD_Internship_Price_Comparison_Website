using Groce.Models;
using System;
using System.Collections.Generic;
namespace Functions
{
    class Functions
    {
        public static List<GroceryType> GroceriesList(GroceryContext _groceryContext)
        {
            var groceries = new List<GroceryType>();



            for (int i = 1; i < 14; i++)
            {
                var Pricing = new Pricing();
                groceries.Add(new GroceryType()
                {
                    GroceryName = _groceryContext.Groceries.Find(i).GroceryName.ToString(),
                    GroceryID = _groceryContext.Groceries.Find(i).GroceryID,
                    GroceryDescription = _groceryContext.Groceries.Find(i).GroceryDescription.ToString(),
                });
                //for (int x = 1; x < 4; x++)
                //{
                //    groceries.Add(new Pr)
                //}
            }





            return groceries;
        }
    }




}