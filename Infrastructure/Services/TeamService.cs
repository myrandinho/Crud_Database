

using Infrastructure.Entities;
using Infrastructure.Repositories;
using System.Diagnostics;

namespace Infrastructure.Services;

public class TeamService
{
    private readonly TeamRepository _teamRepository;

    public TeamService(TeamRepository teamRepository)
    {
        _teamRepository = teamRepository;
    }

    public TeamEntity CreateTeam(string teamName)
    {
        try
        {
            var teamEntity = _teamRepository.Get(x => x.TeamName == teamName);
            teamEntity ??= _teamRepository.Create(new TeamEntity { TeamName = teamName });
            if (teamEntity != null)
            {
                return teamEntity;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;

    }

    public TeamEntity GetTeamByTeamName(string teamName)
    {
        try
        {
            var teamEntity = _teamRepository.Get(x => x.TeamName == teamName);
            if (teamEntity != null)
            {
                return teamEntity;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;
    }

    public TeamEntity GetTeamById(int id)
    {
        try
        {
            var teamEntity = _teamRepository.Get(x => x.Id == id);
            if (teamEntity != null)
            {
                return teamEntity;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;
    }

    public IEnumerable<TeamEntity> GetTeams()
    {
        try
        {
            var teams = _teamRepository.GetAll();
            if (teams != null)
            {
                return teams;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;
    }

    public TeamEntity UpdateTeam(TeamEntity teamEntity)
    {
        try
        {
            var updatedTeamEntity = _teamRepository.Update(x => x.Id == teamEntity.Id, teamEntity);
            if (updatedTeamEntity != null)
            {
                return updatedTeamEntity;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;
    }

    public bool DeleteTeam(int id)
    {
        try
        {
            if (id != 0)
            {
                _teamRepository.Delete(x => x.Id == id);
                return true;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return false;
    }
}
