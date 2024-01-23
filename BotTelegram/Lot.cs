using System;
using System.Collections.Generic;

namespace MyWebApi.Models;

public partial class Lot
{
    public int LotId { get; set; }

    public int UsersId { get; set; }

    public int PortfolioId { get; set; }

    public int AssetId { get; set; }

    public int Quantity { get; set; }

    public int PurchasePrice { get; set; }

    public DateTime PurchaseDate { get; set; }

    public DateTime AddedTime { get; set; }

    public DateTime? EditTime { get; set; }

    public DateTime? DeletetTime { get; set; }

    public int AddedBy { get; set; }

    public int? EditBy { get; set; }

    public int? DeletetBy { get; set; }

    public virtual Asset Asset { get; set; } = null!;

    public virtual Portfolio Portfolio { get; set; } = null!;

    public virtual User Users { get; set; } = null!;
}
