using System;
using System.Collections.Generic;

namespace Vend.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int TenantId { get; set; }

    public int CustomerId { get; set; }

    public decimal TotalPrice { get; set; }

    public string? PaymentStatus { get; set; }

    public string? ShippingStatus { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual Tenant Tenant { get; set; } = null!;
}
