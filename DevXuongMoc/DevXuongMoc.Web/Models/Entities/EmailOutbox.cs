using System;
using System.Collections.Generic;

namespace DevXuongMoc.Web.Models.Entities;

public partial class EmailOutbox
{
    public int Id { get; set; }

    public string? To { get; set; }

    public string? Subject { get; set; }

    public string? Body { get; set; }

    public byte? Status { get; set; }

    public int? Attempts { get; set; }

    public DateTime? CreatedAt { get; set; }
}
