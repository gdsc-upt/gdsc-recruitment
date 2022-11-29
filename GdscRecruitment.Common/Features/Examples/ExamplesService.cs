using GdscRecruitment.Common.Features.Examples.Models;
using GdscRecruitment.Common.Repository;
using GdscRecruitment.Common.Utilities;
using Microsoft.AspNetCore.Authorization;

namespace GdscRecruitment.Common.Features.Examples;

public class ExamplesService
{
    private readonly IRepository<ExampleModel> _repository;

    public ExamplesService(IRepository<ExampleModel> repository)
    {
        _repository = repository;
    }

    public async Task<IList<ExampleModel>> Get()
    {
        return (await _repository.GetAsync()).ToList();
    }

    public async Task<ExampleModel?> Get(string id)
    {
        return await _repository.GetAsync(id);
    }

    [Authorize(Roles = Roles.Admin)]
    public async Task<ExampleModel> Add(ExampleModel entity)
    {
        return await _repository.AddAsync(entity);
    }

    [Authorize(Roles = Roles.Admin)]
    public async Task<ExampleModel?> Delete(string id)
    {
        return await _repository.DeleteAsync(id);
    }

    [Authorize(Roles = Roles.Admin)]
    public async Task<ExampleModel?> Update(ExampleModel model)
    {
        return await _repository.UpdateAsync(model);
    }
}
