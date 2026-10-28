using System;
using System.Collections.Generic;

namespace DevXuongMoc.Web.Models.Entities;

public partial class ContentBlock
{
    public int Id { get; set; }

    public byte? Group { get; set; }

    public string Key { get; set; } = null!;

    public string? ContentHtml { get; set; }

    public int? SortOrder { get; set; }
}
