using Groce.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Models.Functions
{
    public class Functions
    {
        private static List<object> shoppingList;

        public static List<object> ShoppingList
        {
            get
            {
                if (shoppingList == null)
                {
                    shoppingList = new List<Object>();
                }
                return shoppingList;
            }
            private set {; }
        }

        public static void AddItems(List<Object> obj) => ShoppingList.Add(obj);

        public List<GroceryType> GroceriesList(GroceryContext _groceryContext)
        {
            
            var groceries = new List<GroceryType>();

            for (int i = 1; i < 14; i++)
            {
                var pricing = new List<Pricing>();
                for (int j = i * 3; j >= i * 3 - 2; j--)
                {
                    pricing.Add(new Pricing()
                    {
                        GroceryID = _groceryContext.Pricing.Find(j).GroceryID,
                        StoreID = _groceryContext.Pricing.Find(j).StoreID,
                        GroceryPrice = _groceryContext.Pricing.Find(j).GroceryPrice
                    });
                }

                groceries.Add(new GroceryType()
                {
                    GroceryName = _groceryContext.Groceries.Find(i).GroceryName.ToString(),
                    GroceryID = _groceryContext.Groceries.Find(i).GroceryID,
                    GroceryDescription = _groceryContext.Groceries.Find(i).GroceryDescription.ToString(),
                    pricing = pricing
                });

            }
            return groceries;
        }

        public List<string> Search(GroceryContext _groceryContext)
        {
            List<string> searchable = new List<string>();
            for (int i = 1; i < 14; i++)
            {
                searchable.Add(_groceryContext.Groceries.Find(i).GroceryName.ToString());
            }

            return searchable;
        } 


        public decimal Minimum(decimal p1, decimal p2, decimal p3)
        { 
            return new List<decimal> { p1, p2, p3}.Min();
        }

        public decimal Maximum(decimal p1, decimal p2, decimal p3)
        {
            return new List<decimal> { p1, p2, p3 }.Max();
        }
    }

}