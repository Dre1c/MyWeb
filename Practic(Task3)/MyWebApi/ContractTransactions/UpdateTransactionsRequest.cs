namespace MyWebApi.ContractTransactions
{
    public class UpdateTransactionsRequest
    {
        public int PortfolioId { get; set; }
        public int UsersId { get; set; }
        public int AssetId { get; set; }
        public int Price { get; set; }
        public DateTime TheDate { get; set; }
        public DateTime AddedTime { get; set; }
        public int AddedBy { get; set; }
    }
}
