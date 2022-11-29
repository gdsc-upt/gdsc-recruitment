using GdscRecruitment.Common.Repository;
using GdscRecruitment.Common.Utilities;

namespace GdscRecruitment.Common;

public static class Common
{
    public static IServiceCollection AddGdscRecruitmentCommon(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped(typeof(ViewModelHelper<>));

        return services;
    }
}
