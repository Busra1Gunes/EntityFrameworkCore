using System;
using System.Collections.Generic;

namespace StoredProcedure.Models;

public partial class OrtakPayDurum
{
    public int Id { get; set; }

    public int? OrtakId { get; set; }

    public int? TakipId { get; set; }

    public string? Payorani { get; set; }

    public string? Sorumluluk { get; set; }

    public int? YetkiliId { get; set; }

    public bool? Silindi { get; set; }

    public bool? Prim { get; set; }

    public string? DevredenPay { get; set; }

    public decimal? DevredenTutar { get; set; }

    public string? Yerine { get; set; }

    public virtual Takip? Takip { get; set; }
}
