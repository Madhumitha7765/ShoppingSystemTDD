using System;
using System.Collections.Generic;
using System.Linq;
using ItemLib;
using SpecialOfferLib;

namespace ShoppingCartLib
{
   

    public class ShoppingCart
    {
        private List<Item> items = new List<Item>();

        public void Add(char itemName, int price, SpecialOffer? specialOffer = null)
        {
            Item item = new Item { Name = itemName, Price = price, SpecialOffer = specialOffer };
            items.Add(item);
        }

        public int CalculateTotal()
        {
            int total = 0;

            foreach (var item in items)
            {
                if (item.SpecialOffer != null)
                {
                    total += ApplySpecialOffer(item);
                }
                else
                {
                    total += item.Price;
                }
            }

            return total;
        }

        private int ApplySpecialOffer(Item item)
        {
            int quantity = items.Count(x => x.Name == item.Name);
            int offerQuantity = item.SpecialOffer.Quantity;
            int offerPrice = item.SpecialOffer.OfferPrice;

            if (quantity >= offerQuantity)
            {
                int total = (quantity / offerQuantity) * offerPrice;
                total += (quantity % offerQuantity) * item.Price;
                return total;
            }
            else
            {
                return quantity * item.Price;
            }
        }
    }

}
