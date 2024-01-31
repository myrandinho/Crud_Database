

using Infrastructure.Entities;
using Infrastructure.Repositories;
using System.Diagnostics;

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
        try
        {
            var leagueEntity = _leagueRepository.Get(x => x.LeagueName == leagueName && x.Nation == nation);
            leagueEntity ??= _leagueRepository.Create(new LeagueEntity { LeagueName = leagueName, Nation = nation });
            if (leagueEntity != null)
            {
                return leagueEntity;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;


    }

    public LeagueEntity GetLeague(string leagueName, string nation)
    {
        try
        {
            var leagueEntity = _leagueRepository.Get(x => x.LeagueName == leagueName && x.Nation == nation);
            if (leagueEntity != null)
            {
                return leagueEntity;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;
    }



    public LeagueEntity GetLeagueById(int id)
    {
        try
        {
            var leagueEntity = _leagueRepository.Get(x => x.Id == id);
            if (leagueEntity != null)
            {
                return leagueEntity;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;

    }

    public IEnumerable<LeagueEntity> GetLeagues()
    {
        try
        {
            var leagues = _leagueRepository.GetAll();
            if (leagues != null)
            {
                return leagues;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;
    }

    public LeagueEntity UpdateLeague(LeagueEntity leagueEntity)
    {
        try
        {
            var updatedLeagueEntity = _leagueRepository.Update(x => x.Id == leagueEntity.Id, leagueEntity);
            if (updatedLeagueEntity != null)
            {
                return updatedLeagueEntity;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;
    }

    public bool DeleteLeague(int id)
    {
        try
        {
            if (id != 0)
            {
                _leagueRepository.Delete(x => x.Id == id);
                return true;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return false;
    }
}
