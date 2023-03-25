using System.ComponentModel.DataAnnotations;
using MudBlazor;

namespace GdscRecruitment.Common.Features.Workshops.Views;

public class WorkshopRequestView
{
    [Label("Title")][Required] public string Title { get; set; }

    [Label("Description")][Required] public string Description { get; set; }
    
    [Label("Location")][Required] public string Location { get; set; }
    
    [Label("Capacity")] public int Capacity { get; set; }
    
    [Label("Trainer")] public string Trainer { get; set; }
}