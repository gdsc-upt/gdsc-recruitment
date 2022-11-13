using GdscRecruitment.Data;
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

    public async Task<ExampleModel> Add(ExampleModel entity)
    {
        return await _repository.AddAsync(entity);
    }

    public async Task<ExampleModel> Delete([FromRoute] string id)
    {
        return await _repository.DeleteAsync(id);
    }
}
