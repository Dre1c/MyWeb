namespace MyWebApi.Contracts
{
    public class GetMarketDataResponse
    {
        public int MarketId { get; set; }
        public int AssetId { get; set; }
        public int Price { get; set; }
        public DateTime AssetCreationDate { get; set; }
    }
}
