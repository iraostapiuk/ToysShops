using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL;

[Table("tbPerson")]
public partial class TbPerson
{
    [Key]
    [Column("PersonID")]
    public int PersonId { get; set; }

    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [StringLength(50)]
    public string LastName { get; set; } = null!;

    [StringLength(50)]
    public string Login { get; set; } = null!;

    [StringLength(50)]
    public string Password { get; set; } = null!;

    [InverseProperty("Person")]
    public virtual ICollection<TbOrder> TbOrders { get; set; } = new List<TbOrder>();
}
