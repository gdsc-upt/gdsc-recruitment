using AutoMapper;
using GdscRecruitment.Common.Features.InterviewSlot.Models;
using GdscRecruitment.Common.Features.InterviewSlot.Views;
using GdscRecruitment.Common.Repository;

namespace GdscRecruitment.Common.Features.InterviewSlot;

public class InterviewSlotService
{
    private readonly IMapper _mapper;
    private readonly IRepository<InterviewSlotModel> _repository;

    public InterviewSlotService(IRepository<InterviewSlotModel> repository, IMapper mapper)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<List<InterviewSlotResponseView>> Get()
    {
        return (await _repository.GetAsync())
            .Select(i => _mapper
                .Map<InterviewSlotResponseView>(i)
            )
            .ToList();
    }

    public async Task<InterviewSlotResponseView> Get(string Id)
    {
        return _mapper.Map<InterviewSlotResponseView>(await _repository.GetAsync(Id));
    }

    public async Task<InterviewSlotResponseView> Add(InterviewSlotRequestView requestView)
    {
        return _mapper.Map<InterviewSlotResponseView>(await _repository
            .AddAsync(_mapper
                .Map<InterviewSlotModel>(requestView)));
    }

    public async Task<InterviewSlotResponseView> Delete(string Id)
    {
        var result = await _repository.DeleteAsync(Id);
        if (result is null)
        {
            return null;
        }

        return _mapper.Map<InterviewSlotResponseView>(result);
    }

    public async Task<InterviewSlotResponseView> Update(string Id, InterviewSlotRequestView requestView)
    {
        return _mapper.Map<InterviewSlotResponseView>(await _repository.UpdateAsync(Id, requestView));
    }

    public async Task<InterviewSlotResponseView> Join(string InterviewId, string CurrentUserId)
    {
        var interviewSlot = await _repository.GetAsync(InterviewId);

        if (interviewSlot is null)
        {
            return null;
        }
        
        interviewSlot.CandidateId = CurrentUserId;
        
        await _repository.UpdateAsync(InterviewId, interviewSlot);
        return _mapper.Map<InterviewSlotResponseView>(interviewSlot);
    }
    
    public async Task<InterviewSlotResponseView> Unjoin(string Id)
    {
        var interviewSlot = await _repository.GetAsync(Id);

        if (interviewSlot is null)
        {
            return null;
        }
        
        if(interviewSlot.CandidateId is not "null")
            interviewSlot.CandidateId = "null";

        await _repository.UpdateAsync(Id, interviewSlot);
        return _mapper.Map<InterviewSlotResponseView>(interviewSlot);
    }
    
}