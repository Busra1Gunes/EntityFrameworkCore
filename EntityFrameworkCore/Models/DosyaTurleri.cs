using System;
using System.Collections.Generic;

namespace EntityFrameworkCore.Models;

public partial class DosyaTurleri
{
    public int Id { get; set; }

    public string? Ad { get; set; }

    public bool? Silindi { get; set; }

    public int? Sira { get; set; }
}
