using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL;

[PrimaryKey("OrderId", "ProductId")]
[Table("tbOrder_product")]
public partial class TbOrderProduct
{
    [Key]
    [Column("OrderID")]
    public int OrderId { get; set; }

    [Key]
    [Column("ProductID")]
    public int ProductId { get; set; }

    public int? Count { get; set; }

    [ForeignKey("OrderId")]
    [InverseProperty("TbOrderProducts")]
    public virtual TbOrder Order { get; set; } = null!;

    [ForeignKey("ProductId")]
    [InverseProperty("TbOrderProducts")]
    public virtual TbProduct Product { get; set; } = null!;
}
