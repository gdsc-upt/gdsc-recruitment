using AutoMapper;
using GdscRecruitment.Common.Features.Fields.Models;
using GdscRecruitment.Common.Features.Fields.Views;
using GdscRecruitment.Common.Repository;
using GdscRecruitment.Common.Utilities;
using Microsoft.AspNetCore.Authorization;

namespace GdscRecruitment.Common.Features.Fields;

public class FieldsService
{
    private readonly IMapper _mapper;
    private readonly IRepository<FieldModel> _repository;

    public FieldsService(IRepository<FieldModel> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<FieldResponseView>> Get()
    {
        var list = new List<FieldResponseView>();
        var fields = (await _repository.GetAsync()).ToList();
        foreach (var field in fields) list.Add(_mapper.Map<FieldResponseView>(field));

        return list;
    }

    public async Task<FieldModel> Get(string id)
    {
        var field = await _repository.GetAsync(id);
        if (field is null)
        {
            return null;
        }

        return field;
    }

    // [Authorize(Roles = Roles.Admin)]
    public async Task<FieldModel> Add(FieldRequestView fieldRequest)
    {
        var newEntity = _mapper.Map<FieldModel>(fieldRequest);
        return await _repository.AddAsync(newEntity);
    }

    // [Authorize(Roles = Roles.Admin)]
    public async Task<FieldModel?> Delete(string id)
    {
        return await _repository.DeleteAsync(id);
    }

    // [Authorize(Roles = Roles.Admin)]
    public async Task<FieldResponseView> Update(string id, FieldRequestView fieldRequestView)
    {
        return _mapper.Map<FieldResponseView>(await _repository.UpdateAsync(id, fieldRequestView));
    }
}
