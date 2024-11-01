using ProgiChallenge.Server.Models;
using Xunit;

namespace ProgiChallenge.Tests;

public class CommonVehicleTest
{
    [Theory]
    [InlineData(398.00, 39.80)]
    [InlineData(501.00, 50.00)]
    [InlineData(57.00, 10.00)]
    //[InlineData(1800.00, 180.00)]
    [InlineData(1100.00, 50.00)]
    //[InlineData(1000000.00, 200.00)]
    public void Should_CalculateBuyerFee(double vehiclePrice, double feeOutput)
    {
        // Arrange
        Vehicle testVehicle = new CommonVehicle(vehiclePrice);

        // Act
        double buyerFee = testVehicle.CalculateBuyerFee();

        //Assert
        Assert.Equal(buyerFee, feeOutput);
    }

    [Theory]
    [InlineData(398.00, 7.96)]
    [InlineData(501.00, 10.02)]
    [InlineData(57.00, 1.14)]
    //[InlineData(1800Luxury", 72.00)]
    [InlineData(1100.00, 22.00)]
    //[InlineData(1000000Luxury", 40000.00)]
    public void Should_CalculateSellerFee(double vehiclePrice, double feeOutput)
    {
        // Arrange
        Vehicle testVehicle = new CommonVehicle(vehiclePrice);

        // Act
        double sellerFee = testVehicle.CalculateSellerFee();

        //Assert
        Assert.Equal(sellerFee, feeOutput);
    }

    [Theory]
    [InlineData(398.00, 5.00)]
    [InlineData(501.00, 10.00)]
    [InlineData(57.00, 5.00)]
    //[InlineData(1800.00, 15.00)]
    [InlineData(1100.00, 15.00)]
    //[InlineData(1000000.00, 20.00)]
    public void Should_CalculateAssociationFee(double vehiclePrice, double feeOutput)
    {
        // Arrange
        Vehicle testVehicle = new CommonVehicle(vehiclePrice);

        // Act
        double associationFee = testVehicle.CalculateAssociationFee();

        //Assert
        Assert.Equal(associationFee, feeOutput);
    }
}