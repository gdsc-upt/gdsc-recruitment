using AutoMapper;
using GdscRecruitment.Data;
using GdscRecruitment.Features.Responses.Models;
using GdscRecruitment.Features.Responses.Views;

namespace GdscRecruitment.Features.Responses;

public class ResponsesService
{
    private readonly IRepository<ResponseModel> _repository;
    private readonly IMapper _mapper;

    public ResponsesService(IRepository<ResponseModel> repository, IMapper mapper)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<List<ResponseResponseView>> Get()
    {
        var list = new List<ResponseResponseView>();
        var all = await _repository.GetAsync();
        foreach (var response in all)
        {
            list.Add(_mapper.Map<ResponseResponseView>(response));
        }

        return list;
    }

    public async Task<ResponseResponseView> Get(string id)
    {
        return _mapper.Map<ResponseResponseView>(await _repository.GetAsync(id));
    }

    public async Task<ResponseResponseView> Add(ResponseRequestView requestView)
    {
        var newResponse = await _repository.AddAsync(_mapper.Map<ResponseModel>(requestView));

        return _mapper.Map<ResponseResponseView>(newResponse);
    }

    public async Task<ResponseResponseView> Delete(string id)
    {
        var result = await _repository.DeleteAsync(id);
        if (result is null)
        {
            return null;
        }

        return _mapper.Map<ResponseResponseView>(result);
    }

    public async Task<ResponseResponseView> Update(string id, ResponseRequestView requestView)
    {
        return _mapper.Map<ResponseResponseView>(await _repository.UpdateAsync(id, requestView));
    }
}