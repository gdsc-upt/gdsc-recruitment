namespace GdscRecruitment.Features.Example;

public readonly struct ExampleRoutes
{
    public const string Examples = "/examples";
    public const string AddExample = "/examples/add";
    public const string EditExample = "/examples/{id}";

    public static string GetEditPath(string id)
    {
        return $"/examples/{id}";
    }
}
