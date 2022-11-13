using Bogus;
using GdscBackend.Models.Enums;
using GdscRecruitment.Data;
using GdscRecruitment.Features.Example;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Xunit.Abstractions;

namespace GdscRecruitment.Tests;

public class ExampleTests : TestingBase
{
    private static readonly Faker<ExampleModel> DataGenerator = new Faker<ExampleModel>()
       .RuleFor(m => m.Id, f => f.Random.Guid().ToString())
       .RuleFor(m => m.Title, f => f.Lorem.Words().ToString())
       .RuleFor(m => m.Number, f => f.Random.Number())
       .RuleFor(m => m.Type, f => f.PickRandom<ExampleTypeEnum>())
       .RuleFor(m => m.Created, f => f.Date.Past())
       .RuleFor(m => m.Updated, f => f.Date.Past());

    private static readonly IEnumerable<ExampleModel> TestData = DataGenerator.Generate(10);

    public ExampleTests(ITestOutputHelper outputHelper) : base(outputHelper)
    {
    }

    [Fact]
    public async void Post_ReturnsCreatedObject()
    {
        // Arrange
        var repository = new Repository<ExampleModel>(new TestDbContext<ExampleModel>().Object);
        var controller = new ExamplesController(repository);
        var example1 = DataGenerator.Generate();
        var example2 = DataGenerator.Generate();

        // Act
        var added1 = await controller.Post(example1);
        var added2 = await controller.Post(example2);

        var result1 = added1.Result as CreatedAtActionResult;
        var result2 = added2.Result as CreatedAtActionResult;

        // Assert
        Assert.NotNull(result1);
        Assert.NotNull(result2);
        var entity1 = result1.Value as ExampleModel;
        var entity2 = result2.Value as ExampleModel;

        Assert.NotNull(entity1);
        Assert.NotNull(entity1.Id);
        Assert.Equal(StatusCodes.Status201Created, result1.StatusCode);
        Assert.Equal(example1, entity1);

        Assert.NotNull(entity1);
        Assert.NotNull(entity1.Id);
        Assert.Equal(StatusCodes.Status201Created, result2.StatusCode);
        Assert.Equal(example2, entity2);
    }

    [Fact]
    public async void Get_ReturnsAllExamples()
    {
        // Arrange
        var repostitory = new Repository<ExampleModel>(new TestDbContext<ExampleModel>(TestData).Object);
        var controller = new ExamplesController(repostitory);

        // Act
        var actionResult = await controller.Get();
        var result = actionResult.Result as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        var items = Assert.IsAssignableFrom<IEnumerable<ExampleModel>>(result.Value);
        WriteLine(items); // This will print items to console as a json object
        Assert.Equal(TestData, items);
    }
}
