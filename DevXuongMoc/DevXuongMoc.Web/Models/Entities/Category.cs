using System;
using System.Collections.Generic;

namespace DevXuongMoc.Web.Models.Entities;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public string? IconPath { get; set; }

    public int? SortOrder { get; set; }

    public bool? IsVisible { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
