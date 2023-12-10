using GdscRecruitment.Common.Features.Base;
using GdscRecruitment.Common.Features.Users.Models;
using Microsoft.AspNetCore.SignalR;

namespace GdscRecruitment.Common.Features.Workshops.Models;

public class WorkshopModel : Model
{
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Location { get; set; } = string.Empty;

    public int Capacity { get; set; }

    public int ParticipantsNumber { get; set; } = 0;

    public string Trainer { get; set; } = string.Empty;

    public List<string> ParticipantsIds { get; set; } = new List<string>();
}
