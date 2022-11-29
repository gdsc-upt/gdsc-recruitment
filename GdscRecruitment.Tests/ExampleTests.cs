using Bogus;
using GdscRecruitment.Common.Features.Examples;
using GdscRecruitment.Common.Features.Examples.Models;
using GdscRecruitment.Common.Repository;
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
        var controller = new ExamplesService(repository);
        var example1 = DataGenerator.Generate();
        var example2 = DataGenerator.Generate();

        // Act
        var entity1 = await controller.Add(example1);
        var entity2 = await controller.Add(example2);

        Assert.NotNull(entity1);
        Assert.NotNull(entity1.Id);
        Assert.Equal(example1, entity1);

        Assert.NotNull(entity1);
        Assert.NotNull(entity1.Id);
        Assert.Equal(example2, entity2);
    }

    [Fact]
    public async void Get_ReturnsAllExamples()
    {
        // Arrange
        var repostitory = new Repository<ExampleModel>(new TestDbContext<ExampleModel>(TestData).Object);
        var controller = new ExamplesService(repostitory);

        // Act
        var items = await controller.Get();

        // Assert
        Assert.NotNull(items);
        WriteLine(items); // This will print items to console as a json object
        Assert.Equal(TestData, items);
    }
}
