using System;
using System.Collections.Generic;

namespace eStore.Models;

public partial class StatusList
{
    public long Id { get; set; }

    public string StatusName { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
