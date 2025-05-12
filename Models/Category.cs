using System;
using System.Collections.Generic;

namespace eStore.Models;

public partial class Category
{
    public long Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string ImageUrl { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
