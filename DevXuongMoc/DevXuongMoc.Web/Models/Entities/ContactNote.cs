using System;
using System.Collections.Generic;

namespace DevXuongMoc.Web.Models.Entities;

public partial class ContactNote
{
    public int Id { get; set; }

    public int? ContactRequestId { get; set; }

    public string? Content { get; set; }

    public bool? IsSystem { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ContactRequest? ContactRequest { get; set; }
}
