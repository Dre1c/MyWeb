using System;
using System.Collections.Generic;

namespace MyWebApi.Models;

public partial class User
{
    public int UsersId { get; set; }

    public string UsersName { get; set; } = null!;

    public string Pasword { get; set; } = null!;

    public DateTime AddedTime { get; set; }

    public DateTime? EditTime { get; set; }

    public DateTime? DeletetTime { get; set; }

    public int AddedBy { get; set; }

    public int? EditBy { get; set; }

    public int? DeletetBy { get; set; }

    public virtual ICollection<Lot> Lots { get; set; } = new List<Lot>();

    public virtual ICollection<Portfolio> Portfolios { get; set; } = new List<Portfolio>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
