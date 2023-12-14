using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL1;

[Table("Storage")]
public partial class Storage
{
    [Key]
    [Column("StorageID")]
    public int StorageId { get; set; }

    [Column("ToyID")]
    public int? ToyId { get; set; }

    public int? QuantityOfGoods { get; set; }

    [InverseProperty("Storage")]
    public virtual ICollection<Shop> Shops { get; set; } = new List<Shop>();

    [ForeignKey("ToyId")]
    [InverseProperty("Storages")]
    public virtual Toy? Toy { get; set; }
}
