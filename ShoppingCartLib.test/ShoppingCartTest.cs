using System.Collections.Generic;
using Xunit;
using SpecialOfferLib;


namespace ShoppingCartLib.test
{


    public class ShoppingCartTests
    {
        [Fact]
        public void CalculateTotal_NoSpecialOffer_ShouldReturnCorrectTotal()
        {
            // Arrange
            ShoppingCart shoppingCart = new ShoppingCart();
            shoppingCart.Add('A', 50);
            shoppingCart.Add('B', 30);

            // Act
            int result = shoppingCart.CalculateTotal();

            // Assert
            Assert.Equal(80, result);
        }

        [Fact]
        public void CalculateTotal_WithSpecialOffer_ShouldReturnCorrectTotal()
        {
            // Arrange
            ShoppingCart shoppingCart = new ShoppingCart();
            shoppingCart.Add('A', 50, new SpecialOffer { Quantity = 3, OfferPrice = 130 });
            shoppingCart.Add('A', 50);
            shoppingCart.Add('B', 30);

            // Act
            int result = shoppingCart.CalculateTotal();

            // Assert
            Assert.Equal(180, result);
        }

        [Fact]
        public void CalculateTotal_NoItems_ShouldReturnZero()
        {
            // Arrange
            ShoppingCart shoppingCart = new ShoppingCart();

            // Act
            int result = shoppingCart.CalculateTotal();

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void CalculateTotal_MultipleItemsWithSpecialOffers_ShouldReturnCorrectTotal()
        {
            // Arrange
            ShoppingCart shoppingCart = new ShoppingCart();
            shoppingCart.Add('A', 50, new SpecialOffer { Quantity = 3, OfferPrice = 130 });
            shoppingCart.Add('A', 50, new SpecialOffer { Quantity = 3, OfferPrice = 130 });
            shoppingCart.Add('B', 30, new SpecialOffer { Quantity = 2, OfferPrice = 45 });
            shoppingCart.Add('B', 30, new SpecialOffer { Quantity = 2, OfferPrice = 45 });

            // Act
            int result = shoppingCart.CalculateTotal();

            // Assert
            Assert.Equal(290, result);
        }

        [Fact]
        public void CalculateTotal_ItemsWithDifferentSpecialOffers_ShouldReturnCorrectTotal()
        {
            // Arrange
            ShoppingCart shoppingCart = new ShoppingCart();
            shoppingCart.Add('A', 50, new SpecialOffer { Quantity = 3, OfferPrice = 130 });
            shoppingCart.Add('A', 50, new SpecialOffer { Quantity = 2, OfferPrice = 90 });
            shoppingCart.Add('B', 30, new SpecialOffer { Quantity = 2, OfferPrice = 45 });
            shoppingCart.Add('B', 30);

            // Act
            int result = shoppingCart.CalculateTotal();

            // Assert
            Assert.Equal(265, result);
        }

    }

}


