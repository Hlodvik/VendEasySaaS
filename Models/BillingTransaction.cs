using System;
using System.Collections.Generic;

namespace Vend.Models;

public partial class BillingTransaction
{
    public int BillingTransactionId { get; set; }

    public int TenantId { get; set; }

    public decimal Amount { get; set; }

    public string? Currency { get; set; }

    public string? Type { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Tenant Tenant { get; set; } = null!;
}
