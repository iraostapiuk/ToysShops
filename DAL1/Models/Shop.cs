using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL1;

[Table("Shop")]
public partial class Shop
{
    [Key]
    [Column("ShopID")]
    public int ShopId { get; set; }

    [StringLength(50)]
    public string? ShopName { get; set; }

    [Column("StorageID")]
    public int? StorageId { get; set; }

    [ForeignKey("StorageId")]
    [InverseProperty("Shops")]
    public virtual Storage? Storage { get; set; }
}
