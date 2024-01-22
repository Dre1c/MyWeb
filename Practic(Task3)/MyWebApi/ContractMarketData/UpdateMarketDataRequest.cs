namespace MyWebApi.Contracts
{
    public class UpdateMarketDataRequest
    {
        public int AssetId { get; set; }
        public int Price { get; set; }
        public DateTime AssetCreationDate { get; set; }
        public DateTime AddedTime { get; set; }
        public int AddedBy { get; set; }
    }
}
