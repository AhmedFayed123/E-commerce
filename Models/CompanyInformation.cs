using System;
using System.Collections.Generic;

namespace eStore.Models;

public partial class CompanyInformation
{
    public long Id { get; set; }

    public string Name { get; set; }

    public string WebSite { get; set; }

    public string Email { get; set; }

    public string Mobile { get; set; }

    public long? DefaultCurrencyId { get; set; }

    public string Logo { get; set; }

    public string TimeZone { get; set; }

    public virtual Currency DefaultCurrency { get; set; }
}
