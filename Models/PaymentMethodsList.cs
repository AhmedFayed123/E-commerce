using System;
using System.Collections.Generic;

namespace eStore.Models;

public partial class PaymentMethodsList
{
    public long Id { get; set; }

    public string Name { get; set; }

    public double? Commission { get; set; }

    public virtual ICollection<OrderPayment> OrderPayments { get; set; } = new List<OrderPayment>();
}
