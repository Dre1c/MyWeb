using System;
using System.Collections.Generic;

namespace MyWebApi.Models;

public partial class Portfolio
{
    public int PortfolioId { get; set; }

    public int UsersId { get; set; }

    public string PortfolioName { get; set; } = null!;

    public int Balance { get; set; }

    public DateTime AddedTime { get; set; }

    public DateTime? EditTime { get; set; }

    public DateTime? DeletetTime { get; set; }

    public int AddedBy { get; set; }

    public int? EditBy { get; set; }

    public int? DeletetBy { get; set; }

    public virtual ICollection<Lot> Lots { get; set; } = new List<Lot>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    public virtual User Users { get; set; } = null!;
}
