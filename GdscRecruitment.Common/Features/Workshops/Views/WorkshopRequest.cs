using GdscRecruitment.Common.Features.Users.Models;

namespace GdscRecruitment.Common.Features.Workshops.Views;

using System.ComponentModel.DataAnnotations;
using MudBlazor;

public class WorkshopRequest
{
    [Label("Title")][Required] public string Title { get; set; }
    
    [Label("Description")][Required] public string Description { get; set; }
    
    [Label("Location")][Required] public string Location { get; set; }
    
    [Label("Capacity")][Required] public int Capacity { get; set; }
    
    [Label("Trainer")][Required] public string Trainer { get; set; }
    
    [Label("Participants")][Required] public string ParticipantsIds { get; set; } 
}