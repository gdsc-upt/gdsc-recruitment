using AutoMapper;
using GdscRecruitment.Common.Features.Workshops.Models;
using GdscRecruitment.Common.Features.Workshops.Views;
using GdscRecruitment.Common.Repository;
using GdscRecruitment.Common.Utilities;
using Microsoft.AspNetCore.Authorization;
namespace GdscRecruitment.Common.Features.Workshops;

public class WorkshopsService
{
    private readonly IMapper _mapper;
    private readonly IRepository<WorkshopModel> _repository;

    public WorkshopsService(IRepository<WorkshopModel> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<WorkshopResponseView>> Get()
    {
        var list = new List<WorkshopResponseView>();
        var workshops = (await _repository.GetAsync()).ToList();
        foreach (var workshop in workshops) list.Add(_mapper.Map<WorkshopResponseView>(workshop));

        return list;
    }

    public async Task<WorkshopModel> Get(string id)
    {
        var workshop = await _repository.GetAsync(id);
        if (workshop is null)
        {
            return null;
        }

        return workshop;
    }

    [Authorize(Roles = Roles.Admin)]
    public async Task<WorkshopModel> Add(WorkshopRequestView workshopRequest)
    {
        var newEntity = _mapper.Map<WorkshopModel>(workshopRequest);
        return await _repository.AddAsync(newEntity);
    }

    [Authorize(Roles = Roles.Admin)]
    public async Task<WorkshopModel?> Delete(string id)
    {
        return await _repository.DeleteAsync(id);
    }

    [Authorize(Roles = Roles.Admin)]
    public async Task<WorkshopResponseView> Update(string id, WorkshopRequestView workshopRequest)
    {
        return _mapper.Map<WorkshopResponseView>(await _repository.UpdateAsync(id, workshopRequest));
    }

}