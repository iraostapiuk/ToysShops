using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL;

[Table("tbOrder")]
public partial class TbOrder
{
    [Key]
    [Column("OrderID")]
    public int OrderId { get; set; }

    [Column(TypeName = "date")]
    public DateTime OrderDate { get; set; }

    [Column("PersonID")]
    public int PersonId { get; set; }

    [ForeignKey("PersonId")]
    [InverseProperty("TbOrders")]
    public virtual TbPerson Person { get; set; } = null!;

    [InverseProperty("Order")]
    public virtual ICollection<TbOrderProduct> TbOrderProducts { get; set; } = new List<TbOrderProduct>();

    [InverseProperty("Order")]
    public virtual ICollection<TbProductHistory> TbProductHistories { get; set; } = new List<TbProductHistory>();
}
