using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL1;

public partial class Supplier
{
    [Key]
    [Column("SupplierID")]
    public int SupplierId { get; set; }

    [StringLength(50)]
    public string CompanyName { get; set; } = null!;

    [StringLength(50)]
    public string SupplierCity { get; set; } = null!;

    [StringLength(50)]
    public string ContactName { get; set; } = null!;

    [StringLength(20)]
    public string SupplierPhone { get; set; } = null!;

    [InverseProperty("SupplierNavigation")]
    public virtual ICollection<Toy> Toys { get; set; } = new List<Toy>();
}
