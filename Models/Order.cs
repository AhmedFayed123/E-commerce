using System;
using System.Collections.Generic;

namespace eStore.Models;

public partial class Order
{
    public long Id { get; set; }

    public DateTime Date { get; set; }

    public long? CustomerId { get; set; }

    public long? OrderStatusId { get; set; }

    public string ReferenceNumber { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public long? CreatedBy { get; set; }

    public long? ModifiedBy { get; set; }

    public bool? IsNotActive { get; set; }

    public virtual Customer Customer { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<OrderPayment> OrderPayments { get; set; } = new List<OrderPayment>();

    public virtual StatusList OrderStatus { get; set; }
}
