namespace MyWebApi.ContractPortfolio
{
    public class GetLotResponse
    {
        public int LotId { get; set; }
        public int UsersId { get; set; }
        public int PortfolioId { get; set; }
        public int AssetId { get; set; }
        public int Quantity { get; set; }
        public int PurchasePrice { get; set; }
        public DateTime PurchaseDate { get; set; }
        
    }
}
