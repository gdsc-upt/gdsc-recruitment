using AutoMapper;
using GdscRecruitment.Common.Repository;
using GdscRecruitment.Common.Utilities;
using GdscRecruitment.Features.Teams.Models;
using GdscRecruitment.Features.Teams.Views;
using Microsoft.AspNetCore.Authorization;

namespace GdscRecruitment.Features.Teams;

public class TeamsService
{
    private readonly IRepository<TeamModel> _repository;

    private readonly IMapper _mapper;

    public TeamsService(IRepository<TeamModel> repository, IMapper mapper)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<List<TeamResponse>> Get()
    {
        return (await _repository.GetAsync()).ToList().Select(team => _mapper.Map<TeamResponse>(team)).ToList();
    }

    public async Task<TeamResponse> Get(string id)
    {
        var team = await _repository.GetAsync(id);
        if (team is null)
        {
            return null;
        }

        return _mapper.Map<TeamResponse>(team);
    }

    [Authorize(Roles = Roles.Admin)]
    public async Task<TeamModel> Add(TeamRequest request)
    {
        return await _repository.AddAsync(_mapper.Map<TeamModel>(request));
    }

    [Authorize(Roles = Roles.Admin)]
    public async Task<TeamModel?> Delete(string id)
    {
        return await _repository.DeleteAsync(id);
    }

    [Authorize(Roles = Roles.Admin)]
    public async Task<TeamResponse> Update(string id, TeamRequest newRequest)
    {
        return _mapper.Map<TeamResponse>(await _repository.UpdateAsync(id, newRequest));
    }
}