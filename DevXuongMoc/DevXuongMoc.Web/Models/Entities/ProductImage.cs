using System;
using System.Collections.Generic;

namespace DevXuongMoc.Web.Models.Entities;

public partial class ProductImage
{
    public int Id { get; set; }

    public int? ProductId { get; set; }

    public string Path { get; set; } = null!;

    public string AltText { get; set; } = null!;

    public bool? IsPrimary { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Product? Product { get; set; }
}
