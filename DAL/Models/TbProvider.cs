using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL;

[Table("tbProvider")]
public partial class TbProvider
{
    [Key]
    [StringLength(50)]
    public string ProviderName { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string ProviderPhone { get; set; } = null!;

    [InverseProperty("ProviderNameNavigation")]
    public virtual ICollection<TbProduct> TbProducts { get; set; } = new List<TbProduct>();
}
