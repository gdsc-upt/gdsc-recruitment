namespace GdscRecruitment.Base.Models;

public interface IModel
{
    string Id { get; }

    DateTime Created { get; set; }

    DateTime Updated { get; set; }
}
