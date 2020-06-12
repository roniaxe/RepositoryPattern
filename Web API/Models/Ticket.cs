namespace Web_API.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string MovieName { get; set; }
        public decimal SalePrice { get; set; }
        public decimal StudioCutPercentage { get; set; }
        public int Quantity { get; set; }
        public decimal Profit => Quantity * SalePrice - StudioCutPercentage * Quantity * SalePrice;

        public decimal ProfitPerItem => SalePrice - StudioCutPercentage * SalePrice;
    }
}
