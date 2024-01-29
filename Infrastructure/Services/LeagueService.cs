

using Infrastructure.Entities;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class LeagueService
{
    private readonly LeagueRepository _leagueRepository;

    public LeagueService(LeagueRepository leagueRepository)
    {
        _leagueRepository = leagueRepository;
    }

    public LeagueEntity CreateLeague(string leagueName, string nation)
    {
        var leagueEntity = _leagueRepository.Get(x => x.LeagueName == leagueName && x.Nation == nation);
        leagueEntity ??= _leagueRepository.Create(new LeagueEntity { LeagueName = leagueName, Nation = nation });

        return leagueEntity;

    }

    public LeagueEntity GetLeague(string leagueName, string nation)
    {
        var leagueEntity = _leagueRepository.Get(x => x.LeagueName == leagueName && x.Nation == nation);
        return leagueEntity;
    }



    public LeagueEntity GetLeagueById(int id)
    {
        var leagueEntity = _leagueRepository.Get(x => x.Id == id);
        return leagueEntity;
    }

    public IEnumerable<LeagueEntity> GetLeagues()
    {
        var leagues = _leagueRepository.GetAll();
        return leagues;
    }

    public LeagueEntity UpdateLeague(LeagueEntity leagueEntity)
    {
        var updatedLeagueEntity = _leagueRepository.Update(x => x.Id == leagueEntity.Id, leagueEntity);
        return updatedLeagueEntity;
    }

    public void DeleteLeague(int id)
    {
        _leagueRepository.Delete(x => x.Id == id);
    }
}
