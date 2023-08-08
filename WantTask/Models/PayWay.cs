using System;
using System.Collections.Generic;

namespace WantTask.Models;

public partial class PayWay
{
    public int PayWayId { get; set; }

    public string? PayWayName { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
