using System;
using System.Collections.Generic;

namespace Vend.Models;

public partial class Tenant
{
    public int TenantId { get; set; }

    public string Name { get; set; } = null!;

    public string? Domain { get; set; }

    public bool IsMultiVendor { get; set; }

    public int? PrimaryVendorId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Artwork> Artworks { get; set; } = new List<Artwork>();

    public virtual ICollection<BillingTransaction> BillingTransactions { get; set; } = new List<BillingTransaction>();

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<MarketplaceIntegration> MarketplaceIntegrations { get; set; } = new List<MarketplaceIntegration>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Vendor? PrimaryVendor { get; set; }

    public virtual ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();

    public virtual ICollection<Vendor> Vendors { get; set; } = new List<Vendor>();
}
