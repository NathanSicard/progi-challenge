using ProgiChallenge.Server.Models;
using Xunit;

namespace ProgiChallenge.Tests;

public class LuxuryVehicleTest
{
    [Theory]
    [InlineData(1800.00, 180.00)]
    [InlineData(1000000.00, 200.00)]
    public void Should_CalculateBuyerFee(double vehiclePrice, double feeOutput)
    {
        // Arrange
        Vehicle testVehicle = new LuxuryVehicle(vehiclePrice);

        // Act
        double buyerFee = testVehicle.CalculateBuyerFee();

        //Assert
        Assert.Equal(buyerFee, feeOutput);
    }

    [Theory]
    [InlineData(1800.00, 72.00)]
    [InlineData(1000000.00, 40000.00)]
    public void Should_CalculateSellerFee(double vehiclePrice, double feeOutput)
    {
        // Arrange
        Vehicle testVehicle = new LuxuryVehicle(vehiclePrice);

        // Act
        double sellerFee = testVehicle.CalculateSellerFee();

        //Assert
        Assert.Equal(sellerFee, feeOutput);
    }

    [Theory]
    [InlineData(1800.00, 15.00)]
    [InlineData(1000000.00, 20.00)]
    public void Should_CalculateAssociationFee(double vehiclePrice, double feeOutput)
    {
        // Arrange
        Vehicle testVehicle = new LuxuryVehicle(vehiclePrice);

        // Act
        double associationFee = testVehicle.CalculateAssociationFee();

        //Assert
        Assert.Equal(associationFee, feeOutput);
    }
}