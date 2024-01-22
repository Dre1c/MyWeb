using System.Globalization;

namespace MyWebApi.ContractPortfolio
{
    public class CreateLotRequest
    {
        public int UsersId { get; set; }
        public int PortfolioId { get; set; }
        public int AssetId { get; set; }
        public int Quantity { get; set; }
        public int PurchasePrice { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime AddedTime { get; set; }
        public int AddedBy { get; set; }

    }
}
