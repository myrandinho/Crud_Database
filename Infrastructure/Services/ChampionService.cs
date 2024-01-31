

using Infrastructure.Entities;
using Infrastructure.Repositories;
using System.Diagnostics;
using System.Text.RegularExpressions;

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
        try
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
            if (championEntity != null)
            {
                return championEntity;
            }

        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;


    }



    public ChampionEntity GetChampionById(int id)
    {
        try
        {
            var championEntity = _championRepository.Get(x => x.Id == id);
            if (championEntity != null)
            {
                return championEntity;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;

    }

    public IEnumerable<ChampionEntity> GetChampions()
    {
        try
        {
            var champion = _championRepository.GetAll();
            if (champion != null)
            {
                return champion;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;

    }

    public ChampionEntity UpdateChampion(ChampionEntity championEntity)
    {
        try
        {
            var updatedChampionEntity = _championRepository.Update(x => x.Id == championEntity.Id, championEntity);
            if (updatedChampionEntity != null)
            {
                return updatedChampionEntity;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;

    }

    public bool DeleteChampion(int id)
    {
        try
        {
            if (id != 0)
            {
                _championRepository.Delete(x => x.Id == id);
                return true;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return false;
    }
}
