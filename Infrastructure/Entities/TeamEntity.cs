

using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities;

public class TeamEntity
{
    [Key]
    public int Id { get; set; }
    public string TeamName { get; set; } = null!;
}
