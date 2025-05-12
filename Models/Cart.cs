using System;
using System.Collections.Generic;

namespace eStore.Models;

public partial class Cart
{
    public long Id { get; set; }

    public string UserId { get; set; }

    public long? ProductId { get; set; }

    public int? Quantity { get; set; }

    public virtual Product Product { get; set; }
}
