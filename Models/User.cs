using System;
using System.Collections.Generic;

namespace Vend.Models;

public partial class User
{
    public int UserId { get; set; }

    public int TenantId { get; set; }

    public string Role { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual Tenant Tenant { get; set; } = null!;

    public virtual ICollection<Vendor> Vendors { get; set; } = new List<Vendor>();
}
