using System;
using System.Collections.Generic;

namespace DevXuongMoc.Web.Models.Entities;

public partial class Banner
{
    public int Id { get; set; }

    public byte? Placement { get; set; }

    public string? LinkUrl { get; set; }

    public DateTime? StartsAt { get; set; }

    public DateTime? EndsAt { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }
}
