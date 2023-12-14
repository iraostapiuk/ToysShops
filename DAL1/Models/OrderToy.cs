using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL1;

public partial class OrderToy
{
    [Key]
    [Column("OrderToyID")]
    public int OrderToyId { get; set; }

    [Column("OrderID")]
    public int? OrderId { get; set; }

    [Column("ToyID")]
    public int? ToyId { get; set; }

    public int? Quantity { get; set; }

    [ForeignKey("OrderId")]
    [InverseProperty("OrderToys")]
    public virtual Order? Order { get; set; }
}
