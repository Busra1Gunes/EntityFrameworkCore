using System;
using System.Collections.Generic;

namespace EntityFrameworkCore;

public partial class AsgariUcretler
{
    public int Id { get; set; }

    public string? Donem { get; set; }

    public string? Tur { get; set; }

    public string? Sure { get; set; }

    public decimal? Burut { get; set; }

    public decimal? Net { get; set; }

    public bool? Silindi { get; set; }
}
