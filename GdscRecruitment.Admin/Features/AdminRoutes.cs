namespace GdscRecruitment.Admin.Features;

public readonly struct AdminRoutes
{
   public const string Fields = "/fields";
   public const string AddField = "/fields/add";
   public const string EditField = "/fields/{id}";

   public static string GetEditPath(string id)
   {
      return $"{Fields}/{id}";
   }
}