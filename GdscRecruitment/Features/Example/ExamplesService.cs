using GdscRecruitment.Data;
using GdscRecruitment.Features.Example.Models;
using GdscRecruitment.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GdscRecruitment.Features.Example;

public class ExamplesService
{
    private readonly IRepository<ExampleModel> _repository;

    public ExamplesService(IRepository<ExampleModel> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ExampleModel>> Get()
    {
        return (await _repository.GetAsync()).ToList();
    }

    public async Task<ExampleModel?> Get([FromRoute] string id)
    {
        return await _repository.GetAsync(id);
    }

    [Authorize(Roles = Roles.Admin)]
    public async Task<ExampleModel> Add(ExampleModel entity)
    {
        return await _repository.AddAsync(entity);
    }

    [Authorize(Roles = Roles.Admin)]
    public async Task<ExampleModel?> Delete([FromRoute] string id)
    {
        return await _repository.DeleteAsync(id);
    }
}
