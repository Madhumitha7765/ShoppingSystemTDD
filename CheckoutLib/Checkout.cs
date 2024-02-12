using System;
using System.Collections.Generic;
using SpecialOfferLib;
using ShoppingCartLib;


namespace CheckoutLib
{
   

    public class Checkout
    {
        private Dictionary<char, Tuple<int, SpecialOffer>> itemPrices;

        public Checkout(Dictionary<char, Tuple<int, SpecialOffer>> prices)
        {
            itemPrices = prices;
        }

        public int GetTotal(string checkoutItems)
        {
            ShoppingCart shoppingCart = new ShoppingCart();

            foreach (char itemName in checkoutItems)
            {
                if (itemPrices.ContainsKey(itemName))
                {
                    int price = itemPrices[itemName].Item1;
                    SpecialOffer specialOffer = itemPrices[itemName].Item2;
                    shoppingCart.Add(itemName, price, specialOffer);
                }
            }

            return shoppingCart.CalculateTotal();
        }
    }

}
