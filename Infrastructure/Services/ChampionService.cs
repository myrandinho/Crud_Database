

using Infrastructure.Entities;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class ChampionService
{
    private readonly ChampionRepository _championRepository;
    private readonly TeamService _teamService;
    private readonly LeagueService _leagueService;

    public ChampionService(ChampionRepository championRepository, TeamService teamService, LeagueService leagueService)
    {
        _championRepository = championRepository;
        _teamService = teamService;
        _leagueService = leagueService;
    }



    public ChampionEntity CreateChampion(int year, string throphy, string teamName, string leagueName, string nation)
    {
        
        
            var teamEntity = _teamService.CreateTeam(teamName);
            var leagueEntity = _leagueService.CreateLeague(leagueName, nation);

            var championEntity = new ChampionEntity
            {
                
                Year = year,
                Throphy = throphy,
                TeamId = teamEntity.Id,
                LeagueId = leagueEntity.Id
            };

            championEntity = _championRepository.Create(championEntity);
            return championEntity;
        
    }





    public ChampionEntity GetChampionById(int id)
    {
        var championEntity = _championRepository.Get(x => x.Id == id);
        return championEntity;
    }

    public IEnumerable<ChampionEntity> GetChampions()
    {
        var champion = _championRepository.GetAll();
        return champion;
    }

    public ChampionEntity UpdateChampion(ChampionEntity championEntity)
    {
        var updatedChampionEntity = _championRepository.Update(x => x.Id == championEntity.Id, championEntity);
        return updatedChampionEntity;
    }

    public void DeleteChampion(int id)
    {
        _championRepository.Delete(x => x.Id == id);
    }
}
