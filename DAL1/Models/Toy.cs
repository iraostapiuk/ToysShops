using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL1;

[Table("Toy")]
public partial class Toy
{
    [Key]
    [Column("ToyID")]
    public int ToyId { get; set; }

    [StringLength(50)]
    public string? Name { get; set; }

    public double? Price { get; set; }

    [Column("CategoryID")]
    public int? CategoryId { get; set; }

    [Column("SupplierID")]
    public int? SupplierId { get; set; }

    [Column("ShopID")]
    public int? ShopId { get; set; }

    [InverseProperty("Toy")]
    public virtual ICollection<Storage> Storages { get; set; } = new List<Storage>();

    [ForeignKey("SupplierId")]
    [InverseProperty("Toys")]
    public virtual ToyCategory? Supplier { get; set; }

    [ForeignKey("SupplierId")]
    [InverseProperty("Toys")]
    public virtual Supplier? SupplierNavigation { get; set; }
}
