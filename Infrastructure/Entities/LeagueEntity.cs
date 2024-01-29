

using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities;

public class LeagueEntity
{
    [Key]
    public int Id { get; set; }
    public string LeagueName { get; set; } = null!;
    public string Nation { get; set; } = null!;

    
}
