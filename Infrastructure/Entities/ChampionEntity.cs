

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities;

public class ChampionEntity
{
    public int Id { get; set; }
    public int Year { get; set; }
    public string Throphy { get; set; } = null!;


    
    public int TeamId { get; set; }
    public TeamEntity Team { get; set; } = null!;

    public int LeagueId { get; set; }
    public LeagueEntity League { get; set; } = null!;
    
}
