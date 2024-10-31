using ProgiChallenge.Server.Models;

namespace ProgiChallenge.Server.Utils
{
    public class FeeCalculator
    {
        public FeeBreakdown CalculateFees(Vehicle vehicle)
        {
            FeeBreakdown feeBreakdown = new FeeBreakdown();
            feeBreakdown.BasicFee = vehicle.CalculateBuyerFee();
            feeBreakdown.SpecialFee = vehicle.CalculateSellerFee();
            feeBreakdown.AssociationFee = vehicle.CalculateAssociationFee();
            feeBreakdown.StorageFee = vehicle.StorageFee;

            feeBreakdown.TotalCost = Math.Round(
                vehicle.BasePrice +
                feeBreakdown.BasicFee +
                feeBreakdown.SpecialFee +
                feeBreakdown.AssociationFee +
                feeBreakdown.StorageFee
                , 2);

            return feeBreakdown;
        }
    }
}
