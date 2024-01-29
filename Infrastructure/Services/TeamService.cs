

using Infrastructure.Entities;
using Infrastructure.Repositories;

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
        var teamEntity = _teamRepository.Get(x => x.TeamName == teamName);
        teamEntity ??= _teamRepository.Create(new TeamEntity { TeamName = teamName });

        return teamEntity;

    }

    public TeamEntity GetTeamByTeamName(string teamName)
    {
        var teamEntity = _teamRepository.Get(x => x.TeamName == teamName);
        return teamEntity;
    }

    public TeamEntity GetTeamById(int id)
    {
        var teamEntity = _teamRepository.Get(x => x.Id == id);
        return teamEntity;
    }

    public IEnumerable<TeamEntity> GetTeams()
    {
        var teams = _teamRepository.GetAll();
        return teams;
    }

    public TeamEntity UpdateTeam(TeamEntity teamEntity)
    {
        var updatedTeamEntity = _teamRepository.Update(x => x.Id == teamEntity.Id, teamEntity);
        return updatedTeamEntity;
    }

    public void DeleteTeam(int id)
    {
        _teamRepository.Delete(x => x.Id == id);
    }
}
