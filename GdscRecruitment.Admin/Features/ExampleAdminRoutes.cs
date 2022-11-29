namespace GdscRecruitment.Admin.Features;

public readonly struct ExampleAdminRoutes
{
    public const string Examples = "/examples";
    public const string AddExample = "/examples/add";
    public const string EditExample = "/examples/{id}";

    public static string GetEditPath(string id)
    {
        return $"{Examples}/{id}";
    }
}
