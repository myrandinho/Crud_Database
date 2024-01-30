using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Entities;

public partial class Size
{
    [Key]
    public int Id { get; set; }

    public int Quantity { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string Unit { get; set; } = null!;

    [InverseProperty("Size")]
    public virtual ICollection<SoftwareProduct> SoftwareProducts { get; set; } = new List<SoftwareProduct>();
}
