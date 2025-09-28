using System;
using System.Collections.Generic;

namespace Vend.Models;

public partial class Listing
{
    public int ListingId { get; set; }

    public int ArtworkId { get; set; }

    public int IntegrationId { get; set; }

    public string? ExternalListingId { get; set; }

    public string? Status { get; set; }

    public virtual Artwork Artwork { get; set; } = null!;

    public virtual MarketplaceIntegration Integration { get; set; } = null!;
}
