using System;
using System.Collections.Generic;

namespace MyWebApi.Models;

public partial class Asset
{
    public int AssetId { get; set; }

    public string AssetName { get; set; } = null!;

    public string Currency { get; set; } = null!;

    public string AssetType { get; set; } = null!;

    public DateTime TheDate { get; set; }

    public DateTime AddedTime { get; set; }

    public DateTime? EditTime { get; set; }

    public DateTime? DeletetTime { get; set; }

    public int AddedBy { get; set; }

    public int? EditBy { get; set; }

    public int? DeletetBy { get; set; }

    public virtual ICollection<Lot> Lots { get; set; } = new List<Lot>();

    public virtual ICollection<MarketDatum> MarketData { get; set; } = new List<MarketDatum>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
