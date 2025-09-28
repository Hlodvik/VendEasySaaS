using System;
using System.Collections.Generic;

namespace Vend.Models;

public partial class Artwork
{
    public int ArtworkId { get; set; }

    public int TenantId { get; set; }

    public int VendorId { get; set; }

    public string Title { get; set; } = null!;

    public string? Genre { get; set; }

    public decimal Price { get; set; }

    public int QuantityAvailable { get; set; }

    public string? ImageUrl { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Listing> Listings { get; set; } = new List<Listing>();

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual Tenant Tenant { get; set; } = null!;

    public virtual Vendor Vendor { get; set; } = null!;
}
