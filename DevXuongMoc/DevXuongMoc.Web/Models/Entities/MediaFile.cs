using System;
using System.Collections.Generic;

namespace DevXuongMoc.Web.Models.Entities;

public partial class MediaFile
{
    public int Id { get; set; }

    public string Path { get; set; } = null!;

    public DateTime? OrphanedAt { get; set; }

    public DateTime? CreatedAt { get; set; }
}
