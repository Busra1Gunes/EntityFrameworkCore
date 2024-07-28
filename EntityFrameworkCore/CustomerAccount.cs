using System;
using System.Collections.Generic;

namespace EntityFrameworkCore;

public partial class CustomerAccount
{
    public int CustomerAccountId { get; set; }

    public string CustomerAccountNumber { get; set; } = null!;

    public string CustomerAccountCurrency { get; set; } = null!;

    public string CustomerAccountBalance { get; set; } = null!;

    public string BankBranch { get; set; } = null!;

    public int AppUserId { get; set; }

    public virtual AspNetUser AppUser { get; set; } = null!;
}
