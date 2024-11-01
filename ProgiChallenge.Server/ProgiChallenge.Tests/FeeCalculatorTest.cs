using ProgiChallenge.Server.Models;
using ProgiChallenge.Server.Utils;
using Xunit;

namespace ProgiChallenge.Tests;

public class FeeCalculatorTest
{
    [Theory]
    [MemberData(nameof(FeeCalculatorParameters))]
    public void Should_CalculateBuyerFee(Vehicle inputVehicle, FeeBreakdown expectedBreakdownResult)
    {
        // Arrange
        FeeCalculator feeCalculator = new FeeCalculator();

        // Act
        FeeBreakdown feeBreakdown = feeCalculator.CalculateFees(inputVehicle);

        //Assert
        Assert.Equal(feeBreakdown.BasicFee, expectedBreakdownResult.BasicFee);
        Assert.Equal(feeBreakdown.SpecialFee, expectedBreakdownResult.SpecialFee);
        Assert.Equal(feeBreakdown.AssociationFee, expectedBreakdownResult.AssociationFee);
        Assert.Equal(feeBreakdown.StorageFee, expectedBreakdownResult.StorageFee);
        Assert.Equal(feeBreakdown.TotalCost, expectedBreakdownResult.TotalCost);
    }

    public static IEnumerable<object[]> FeeCalculatorParameters()
    {
        yield return new object[]
        {
            new CommonVehicle(398.00),
            new FeeBreakdown
            {
                BasicFee = 39.80,
                SpecialFee = 7.96,
                AssociationFee = 5.00,
                StorageFee = 100,
                TotalCost = 550.76,
            }
        };
        yield return new object[]
        {
            new CommonVehicle(501.00),
            new FeeBreakdown
            {
                BasicFee = 50.00,
                SpecialFee = 10.02,
                AssociationFee = 10.00,
                StorageFee = 100,
                TotalCost = 671.02,
            }
        };
        yield return new object[]
        {
            new CommonVehicle(57.00),
            new FeeBreakdown
            {
                BasicFee = 10.00,
                SpecialFee = 1.14,
                AssociationFee = 5.00,
                StorageFee = 100,
                TotalCost = 173.14,
            }
        };
        yield return new object[]
        {
            new LuxuryVehicle(1800.00),
            new FeeBreakdown
            {
                BasicFee = 180.00,
                SpecialFee = 72.00,
                AssociationFee = 15.00,
                StorageFee = 100,
                TotalCost = 2167.00,
            }
        };
        yield return new object[]
        {
            new CommonVehicle(1100.00),
            new FeeBreakdown
            {
                BasicFee = 50.00,
                SpecialFee = 22.00,
                AssociationFee = 15.00,
                StorageFee = 100,
                TotalCost = 1287.00,
            }
        };
        yield return new object[]
        {
            new LuxuryVehicle(1000000.00),
            new FeeBreakdown
            {
                BasicFee = 200.00,
                SpecialFee = 40000.00,
                AssociationFee = 20.00,
                StorageFee = 100,
                TotalCost = 1040320.00,
            }
        };
    }
}