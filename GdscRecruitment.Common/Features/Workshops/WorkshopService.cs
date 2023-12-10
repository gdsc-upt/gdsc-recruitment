using AutoMapper;
using GdscRecruitment.Common.Features.Users.Models;
using GdscRecruitment.Common.Features.Workshops.Models;
using GdscRecruitment.Common.Features.Workshops.Views;
using GdscRecruitment.Common.Repository;
using Microsoft.AspNetCore.Http.HttpResults;

namespace GdscRecruitment.Common.Features.Workshops;

public class WorkshopService
{
    private readonly IRepository<WorkshopModel> _repository;

    private readonly IMapper _mapper;

    public WorkshopService(IRepository<WorkshopModel> repository,IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<WorkshopResponse>> Get()
    {
        return (await _repository.GetAsync())
            .Select(workshop => _mapper.Map<WorkshopResponse>(workshop))
            .ToList();
    }

    public async Task<WorkshopResponse> GetId(string Id)
    {
        var workshop = await _repository.GetAsync(Id);
        if (workshop is null)
        {
            return null;
        }

        return _mapper.Map<WorkshopResponse>(workshop);
    }

    public async Task<WorkshopModel> Add(WorkshopRequest request)
    {
        return await _repository.AddAsync(_mapper.Map<WorkshopModel>(request));
    }

    public async Task<WorkshopModel> Delete(string Id)
    {
        return await _repository.DeleteAsync(Id);
    }

    public async Task<WorkshopResponse> Update(string Id, WorkshopRequest request)
    {
        return _mapper.Map<WorkshopResponse>(await _repository.UpdateAsync(Id, request));
    }

    public async Task<WorkshopResponse> Subscribe(string Id,string userId)
    {
        var workshop = await _repository.GetAsync(Id);
        if (workshop is null)
        {
            return null;
        }

        if (workshop.ParticipantsNumber >= workshop.Capacity)
        {
            return null;//throw new Exception
        }
        workshop.ParticipantsNumber += 1;
        workshop.ParticipantsIds.Add(userId);
        
        await _repository.UpdateAsync(Id,workshop);

        return _mapper.Map<WorkshopResponse>(workshop);
    }

    public async Task<WorkshopResponse> Unsubscribe(string Id, string userId)
    {
        var workshop = await _repository.GetAsync(Id);
        if (workshop is null)
        {
            return null;
        }

        workshop.ParticipantsNumber -= 1;
        workshop.ParticipantsIds.Remove(userId);

        
        await _repository.UpdateAsync(Id, workshop);

        return _mapper.Map<WorkshopResponse>(workshop);
    }
}