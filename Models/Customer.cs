using System;
using System.Collections.Generic;

namespace eStore.Models;

public partial class Customer
{
    public long Id { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public string Mobile { get; set; }

    public string Pwd { get; set; }

    public long? Country { get; set; }

    public string City { get; set; }

    public string Street { get; set; }

    public string BuildingNo { get; set; }

    public string Floor { get; set; }

    public string AppartNo { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public long? CreatedBy { get; set; }

    public long? ModifiedBy { get; set; }

    public bool IsNotActive { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
