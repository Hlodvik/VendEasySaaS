using System;
using System.Collections.Generic;

namespace Vend.Models;

public partial class Vendor
{
    public int VendorId { get; set; }

    public int TenantId { get; set; }

    public int UserId { get; set; }

    public string DisplayName { get; set; } = null!;

    public string? Bio { get; set; }

    public string? PaymentInfo { get; set; }

    public bool IsPrimary { get; set; }

    public virtual ICollection<Artwork> Artworks { get; set; } = new List<Artwork>();

    public virtual ICollection<MarketplaceIntegration> MarketplaceIntegrations { get; set; } = new List<MarketplaceIntegration>();

    public virtual Tenant Tenant { get; set; } = null!;

    public virtual ICollection<Tenant> Tenants { get; set; } = new List<Tenant>();

    public virtual User User { get; set; } = null!;
}
