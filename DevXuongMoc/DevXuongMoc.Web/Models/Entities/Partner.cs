using System;
using System.Collections.Generic;

namespace DevXuongMoc.Web.Models.Entities;

public partial class Partner
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string LogoPath { get; set; } = null!;

    public bool? ShowOnHome { get; set; }

    public bool? IsVisible { get; set; }

    public DateTime? CreatedAt { get; set; }
}
