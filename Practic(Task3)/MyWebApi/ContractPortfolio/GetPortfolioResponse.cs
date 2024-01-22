namespace MyWebApi.ContractPortfolio
{
    public class GetPortfolioResponse
    {
        public int PortfolioId { get; set; }
        public int UserId { get; set; }
        public string PorfolioName { get; set; } = null!;
        public int Balance { get; set; }
    }
}
