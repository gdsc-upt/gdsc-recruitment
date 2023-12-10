using System.ComponentModel.DataAnnotations;
using GdscRecruitment.Common.Features.Users.Models;
using MudBlazor;

namespace GdscRecruitment.Common.Features.Workshops.Views;

public class WorkshopResponse
{
    public string Id { get; set; }

    [Label("Title")][Required] public string Title { get; set; } = string.Empty;

    [Label("Description")][Required] public string Description { get; set; } = string.Empty;

    [Label("Location")][Required] public string Location { get; set; } = string.Empty;
    
    [Label("Capacity")][Required] public int Capacity { get; set; }
    
    [Label("ParticipantsNumber")][Required] public int ParticipantsNumber { get; set; }

    [Label("Trainer")] [Required] public string Trainer { get; set; } = string.Empty;
    
    [Label("Participants")][Required] public List<string> ParticipantsIds { get; set; }
}