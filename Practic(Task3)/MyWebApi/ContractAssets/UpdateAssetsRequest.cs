﻿namespace MyWebApi.ContractPortfolio
{
    public class UpdateAssetsRequest
    {
        public string AssetName { get; set; } = null!;
        public char Currency { get; set; }
        public string AssetType { get; set; } = null!;
        public DateTime TheDate { get; set; }
        public DateTime AddedTime { get; set; }
        public int AddedBy { get; set; }
    }
}
