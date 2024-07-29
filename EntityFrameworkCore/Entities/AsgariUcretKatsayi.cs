using System;
using System.Collections.Generic;

namespace EntityFrameworkCore;

public partial class AsgariUcretKatsayi
{
    public int Id { get; set; }

    public string? Yil { get; set; }

    public string? Katsayi { get; set; }

    public bool? Indirim { get; set; }
}
