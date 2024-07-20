using System;
using System.Collections.Generic;

namespace pr_model.Models;

public partial class Order
{
    public long Id { get; set; }

    public string OrderNumber { get; set; } = null!;

    public decimal Price { get; set; }

    public DateTime OrderDate { get; set; }

    public long FlowerId { get; set; }

    public long UserId { get; set; }
}
