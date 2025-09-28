using System;
using System.Collections.Generic;

namespace Vend.Models;

public partial class MarketplaceIntegration
{
    public int IntegrationId { get; set; }

    public int TenantId { get; set; }

    public int? VendorId { get; set; }

    public string Platform { get; set; } = null!;

    public string? ApiKeys { get; set; }

    public string? SyncStatus { get; set; }

    public virtual ICollection<Listing> Listings { get; set; } = new List<Listing>();

    public virtual Tenant Tenant { get; set; } = null!;

    public virtual Vendor? Vendor { get; set; }
}
