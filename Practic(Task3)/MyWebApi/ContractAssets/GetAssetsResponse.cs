namespace MyWebApi.ContractPortfolio
{
    public class GetAssetsResponse
    {
        public int AssetId { get; set; }
        public string AssetName { get; set; } = null!;
        public char Currency { get; set; }
        public string AssetType { get; set; } = null!;
        public DateTime TheDate { get; set; }
        
    }
}
