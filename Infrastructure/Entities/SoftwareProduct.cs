using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Entities;

public partial class SoftwareProduct
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string Title { get; set; } = null!;

    public int SizeId { get; set; }

    [ForeignKey("SizeId")]
    [InverseProperty("SoftwareProducts")]
    public virtual Size Size { get; set; } = null!;
}
