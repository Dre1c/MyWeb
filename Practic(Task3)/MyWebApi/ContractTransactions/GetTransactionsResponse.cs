namespace MyWebApi.ContractTransactions
{
    public class GetTransactionsResponse
    {
        public int TransactionsId { get; set; }
        public int PortfolioId { get; set; }
        public int UsersId { get; set; }
        public int AssetId { get; set; }
        public int Price { get; set; }
        public DateTime TheDate { get; set; }
    }
}
