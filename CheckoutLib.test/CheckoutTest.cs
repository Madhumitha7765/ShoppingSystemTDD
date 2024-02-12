using CheckoutLib;
using SpecialOfferLib;
using System.Collections.Generic;
using Xunit;

public class CheckoutTests
{
    [Fact]
    public void GetTotal_ShouldReturnCorrectTotal()
    {
        // Arrange
        var itemPrices = new Dictionary<char, Tuple<int, SpecialOffer>>
        {
            { 'A', new Tuple<int, SpecialOffer>(50, new SpecialOffer { Quantity = 3, OfferPrice = 130 }) },
            { 'B', new Tuple<int, SpecialOffer>(30, new SpecialOffer { Quantity = 2, OfferPrice = 45 }) },
            { 'C', new Tuple<int, SpecialOffer>(20, null) },
            { 'D', new Tuple<int, SpecialOffer>(15, null) }
        };

        var checkout = new Checkout(itemPrices);

        // Act
        int result = checkout.GetTotal("CDBA");

        // Assert
        Assert.Equal(115, result);
    }
}
