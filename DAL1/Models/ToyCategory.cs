using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL1;

public partial class ToyCategory
{
    [Key]
    [Column("CategoryID")]
    public int CategoryId { get; set; }

    [StringLength(50)]
    public string CategoryName { get; set; } = null!;

    [Column("ToyID")]
    public int ToyId { get; set; }

    [InverseProperty("Supplier")]
    public virtual ICollection<Toy> Toys { get; set; } = new List<Toy>();
}
