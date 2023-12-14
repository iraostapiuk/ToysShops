using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL;

[Table("tbProductHistory")]
public partial class TbProductHistory
{
    [Key]
    [Column("HistoryID")]
    public int HistoryId { get; set; }

    [Column("OrderID")]
    public int OrderId { get; set; }

    [Column(TypeName = "date")]
    public DateTime OperationDate { get; set; }

    public int ProductQuantity { get; set; }

    [ForeignKey("OrderId")]
    [InverseProperty("TbProductHistories")]
    public virtual TbOrder Order { get; set; } = null!;
}
