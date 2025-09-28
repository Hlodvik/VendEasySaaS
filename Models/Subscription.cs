using System;
using System.Collections.Generic;

namespace Vend.Models;

public partial class Subscription
{
    public int SubscriptionId { get; set; }

    public int TenantId { get; set; }

    public string SubPlan { get; set; } = null!;

    public string? Status { get; set; }

    public DateTime? RenewalDate { get; set; }

    public virtual Tenant Tenant { get; set; } = null!;
}
