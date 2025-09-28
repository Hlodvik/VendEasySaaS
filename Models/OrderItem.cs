using System;
using System.Collections.Generic;

namespace Vend.Models;

public partial class OrderItem
{
    public int OrderItemId { get; set; }

    public int OrderId { get; set; }

    public int ArtworkId { get; set; }

    public int Quantity { get; set; }

    public decimal PriceAtPurchase { get; set; }

    public virtual Artwork Artwork { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
