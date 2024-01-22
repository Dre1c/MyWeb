namespace MyWebApi.ContractPortfolio
{
    public class UpdatePortfolioRequest
    {
        public int UsersId { get; set; }
        public string PortfolioName { get; set; } = null!;
        public int Balance { get; set; }
        public DateTime AddedTime { get; set; }
        public int AddedBy { get; set; }
    }
}
