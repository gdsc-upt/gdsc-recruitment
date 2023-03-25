using System.ComponentModel.DataAnnotations;
using MudBlazor;

namespace GdscRecruitment.Common.Features.Workshops.Views;

public class WorkshopResponseView
{
    [Label("Title")][Required] public string Title { get; set; }
    
    [Label("Description")][Required] public string Description { get; set; }
    
    [Label("Location")][Required] public string Location { get; set; }
    
    [Label("Capacity")][Required] public int Capacity { get; set; }
    
    [Label("ParticipantsNumber")][Required] public int ParticipantsNumber { get; set; }
    
    [Label("Trainer")][Required] public string Trainer { get; set; }
}