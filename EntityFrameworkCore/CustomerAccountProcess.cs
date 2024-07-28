using System;
using System.Collections.Generic;

namespace EntityFrameworkCore;

public partial class CustomerAccountProcess
{
    public int CustomerAccountProcessId { get; set; }

    public int ProcessType { get; set; }

    public decimal Amount { get; set; }

    public DateTime ProcessDate { get; set; }
}
