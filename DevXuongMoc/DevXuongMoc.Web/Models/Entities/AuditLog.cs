using System;
using System.Collections.Generic;

namespace DevXuongMoc.Web.Models.Entities;

public partial class AuditLog
{
    public long Id { get; set; }

    public string? UserId { get; set; }

    public string? Action { get; set; }

    public string? EntityName { get; set; }

    public string? Summary { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual User? User { get; set; }
}
