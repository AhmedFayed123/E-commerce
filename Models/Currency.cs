using System;
using System.Collections.Generic;

namespace eStore.Models;

public partial class Currency
{
    public long Id { get; set; }

    public string CurrencyName { get; set; }

    public string ArabicName { get; set; }

    public string Symbol { get; set; }

    public virtual ICollection<CompanyInformation> CompanyInformations { get; set; } = new List<CompanyInformation>();
}
