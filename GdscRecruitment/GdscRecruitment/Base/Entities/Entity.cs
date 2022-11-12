using System;

namespace GdscRecruitment.Base.Entities;

public class Entity : IEntity
{
    public string Id { get; set; }

    public DateTime Created { get; set; }

    public DateTime Updated { get; set; }
}
