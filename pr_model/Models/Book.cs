using System;
using System.Collections.Generic;

namespace pr_model.Models;

public partial class Book
{
    public long Id { get; set; }

    public string Title { get; set; } = null!;

    public int? Type { get; set; }

    public string Image { get; set; } = null!;

    public string BigImage { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal Price { get; set; }

    public string Language { get; set; } = null!;

    public string Material { get; set; } = null!;

    public string Packing { get; set; } = null!;

    public string DeliveryRemarks { get; set; } = null!;
}
