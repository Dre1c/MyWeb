using System;
using System.Collections.Generic;

namespace MyWebApi.Models;

public partial class MarketDatum
{
    public int MarketId { get; set; }

    public int AssetId { get; set; }

    public int Price { get; set; }

    public DateTime AssetCreationDate { get; set; }

    public DateTime AddedTime { get; set; }

    public DateTime? EditTime { get; set; }

    public DateTime? DeletetTime { get; set; }

    public int AddedBy { get; set; }

    public int? EditBy { get; set; }

    public int? DeletetBy { get; set; }

    public virtual Asset Asset { get; set; } = null!;
}
