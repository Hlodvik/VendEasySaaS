using System;
using System.Collections.Generic;

namespace Vend.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public int TenantId { get; set; }

    public int UserId { get; set; }

    public string? ShippingAddress { get; set; }

    public string? BillingInfo { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Tenant Tenant { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
