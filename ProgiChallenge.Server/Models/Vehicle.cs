namespace ProgiChallenge.Server.Models
{
    public abstract class Vehicle
    {
        public double BasePrice;
        private double BuyerFeePercent { get; set; } = 10;
        private double MinBuyerFee { get; set; }
        private double MaxBuyerFee { get; set; }

        private double SellerFeePercent { get; set; }
        public double StorageFee { get; set; } = 100.00;

        public Vehicle(double basePrice, double minBuyerFee, double maxBuyerFee, double sellerFeePercent)
        {
            this.BasePrice = basePrice;
            this.MinBuyerFee = minBuyerFee;
            this.MaxBuyerFee = maxBuyerFee;
            this.SellerFeePercent = sellerFeePercent;
        }

        public double CalculateBuyerFee()
        {
            double buyerFee = (BuyerFeePercent/100) * this.BasePrice;

            return Math.Round(double.Max(MinBuyerFee, double.Min(buyerFee, MaxBuyerFee)), 2);
        }

        public double CalculateSellerFee()
        {
            return Math.Round((SellerFeePercent/100) * this.BasePrice, 2);
        }

        public double CalculateAssociationFee()
        {
            if (this.BasePrice > 3000) { return 20.00; }
            if (this.BasePrice > 1000) { return 15.00; }
            if (this.BasePrice > 500) { return 10.00; }
            if (this.BasePrice > 1) { return 5.00; }
            return 0.00;
        }
    }
}
