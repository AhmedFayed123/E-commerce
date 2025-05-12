using System;
using System.Collections.Generic;

namespace eStore.Models;

public partial class OrderPayment
{
    public long Id { get; set; }

    public long? OrderId { get; set; }

    public long? PaymentMethodId { get; set; }

    public double? Commission { get; set; }

    public virtual Order Order { get; set; }

    public virtual PaymentMethodsList PaymentMethod { get; set; }
}
