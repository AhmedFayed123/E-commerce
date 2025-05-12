using System;
using System.Collections.Generic;

namespace eStore.Models;

public partial class OrderDetail
{
    public long Id { get; set; }

    public long? OrderId { get; set; }

    public long? ProductId { get; set; }

    public decimal? ItemPrice { get; set; }

    public decimal? ItemPriceAfterDiscount { get; set; }

    public int? Quantity { get; set; }

    public virtual Order Order { get; set; }

    public virtual Product Product { get; set; }
}
