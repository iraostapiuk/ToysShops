using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL;

[Table("tbProduct")]
public partial class TbProduct
{
    [Key]
    [Column("ProductID")]
    public int ProductId { get; set; }

    [StringLength(50)]
    public string ProductName { get; set; } = null!;

    public int Quantity { get; set; }

    public double Price { get; set; }

    [StringLength(50)]
    public string? ProviderName { get; set; }

    [Column(TypeName = "date")]
    public DateTime DateOfUpdating { get; set; }

    [StringLength(50)]
    public string ProductType { get; set; } = null!;

    [ForeignKey("ProviderName")]
    [InverseProperty("TbProducts")]
    public virtual TbProvider? ProviderNameNavigation { get; set; }

    [InverseProperty("Product")]
    public virtual ICollection<TbOrderProduct> TbOrderProducts { get; set; } = new List<TbOrderProduct>();
}
