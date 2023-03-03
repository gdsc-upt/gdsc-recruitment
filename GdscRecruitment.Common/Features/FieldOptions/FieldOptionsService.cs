using GdscRecruitment.Common.Features.FieldOptions.Model;
using GdscRecruitment.Common.Repository;
using GdscRecruitment.Common.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace GdscRecruitment.Common.Features.FieldOptions;

public class FieldOptionsService
{
    private readonly IRepository<FieldOptionsModel> _repository;

    public FieldOptionsService(IRepository<FieldOptionsModel> repository)
    {
        _repository = repository;
    }

    public async Task<List<FieldOptionsModel>> Get()
    {
        var list = new List<FieldOptionsModel>();
        var fOptions = (await _repository.GetAsync()).ToList();

        foreach (var fOption in fOptions)
        {
            list.Add(fOption);
        }

        return list;
    }

    public async Task<FieldOptionsModel> Get(string id)
    {
        var option = await _repository.DbSet.FirstOrDefaultAsync(entity => entity.Id == id);
        if (option is null)
        {
            return null;
        }

        return option;
    }

    [Authorize(Roles = Roles.Admin)]
    public async Task<FieldOptionsModel> Add(FieldOptionsModel fOption)
    {
        return await _repository.AddAsync(fOption);
    }

    [Authorize(Roles = Roles.Admin)]
    public async Task<FieldOptionsModel> Delete(string id)
    {
        var option = await _repository.DeleteAsync(id);
        if (option is null)
        {
            return null;
        }

        return option;
    }

    [Authorize(Roles = Roles.Admin)]
    public async Task<FieldOptionsModel?> Update(string id, FieldOptionsModel newOptions)
    {
        return await _repository.UpdateAsync(id, newOptions);
    }
}