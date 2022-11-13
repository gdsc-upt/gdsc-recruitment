using AutoMapper;
using GdscRecruitment.Data;
using Microsoft.EntityFrameworkCore;

namespace GdscRecruitment.Features.Forms;

public class FieldsController 
{
    private readonly IRepository<FieldModel> _repository;

    private readonly IMapper _mapper;

    public FieldsController(IRepository<FieldModel> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<List<FieldResponseView>> Get()
    {
        var list = new List<FieldResponseView>();
        var fields = (await _repository.GetAsync()).ToList();
        foreach (var field in fields)
        {
            list.Add(_mapper.Map<FieldResponseView>(field));
        }

        return list;
    }
    
    public async Task<FieldResponseView> Get(string id)
    {
        var field = await _repository.DbSet.FirstOrDefaultAsync(entity => entity.Id == id);
        if (field is null)
        {
            return null;
        }

        return _mapper.Map<FieldResponseView>(field);
    }
    
    public async Task<FieldResponseView> Add(FieldRequestView fieldRequest)
    {
        var newField = await _repository.AddAsync(_mapper.Map<FieldModel>(fieldRequest));

        return _mapper.Map<FieldResponseView>(newField);
    }

    public async Task<FieldResponseView> Delete(string id)
    {
       var entity =  await _repository.DeleteAsync(id);
       if (entity is null)
       {
           return null;
       }
       return _mapper.Map<FieldResponseView>(entity);
    }

    public async Task<FieldResponseView> Update(string id, FieldRequestView fieldRequestView)
    {
        return _mapper.Map<FieldResponseView>(await _repository.UpdateAsync(id, _mapper.Map<FieldModel>(fieldRequestView)));
    }
}
