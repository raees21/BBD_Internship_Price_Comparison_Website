using Groce.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Models.Functions
{
    public class Functions
    {

        public List<GroceryType> GroceriesList(GroceryContext _groceryContext)
        {
            var groceries = new List<GroceryType>();
            //var pricing = new List<Pricing>();

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
                //Console.WriteLine($"{pricing[0].ToString()}");
                //Console.WriteLine($"{pricing[0].ToString()}");


                groceries.Add(new GroceryType()
                    {
                        GroceryName = _groceryContext.Groceries.Find(i).GroceryName.ToString(),
                        GroceryID = _groceryContext.Groceries.Find(i).GroceryID,
                        GroceryDescription = _groceryContext.Groceries.Find(i).GroceryDescription.ToString(),
                        pricing = pricing
                    });
                    Console.WriteLine($"{groceries.Count()}");
                
            }
            return groceries;
        }

        public List<string> Search(GroceryContext _groceryContext)
        {
            List<string> searchable = new List<string>();
            for (int i = 1; i < 14; i++)
            {
                searchable.Add(_groceryContext.Groceries.Find(i).ToString());


            }

            return searchable;
            

        }




    }
}
