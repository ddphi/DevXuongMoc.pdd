using System;
using System.Collections.Generic;

namespace DevXuongMoc.Web.Models.Entities;

public partial class User
{
    public string Id { get; set; } = null!;

    public string Email { get; set; } = null!;

    public bool? IsActive { get; set; }

    public virtual ICollection<Article> Articles { get; set; } = new List<Article>();

    public virtual ICollection<AuditLog> AuditLogs { get; set; } = new List<AuditLog>();

    public virtual ICollection<ContactRequest> ContactRequests { get; set; } = new List<ContactRequest>();
}
