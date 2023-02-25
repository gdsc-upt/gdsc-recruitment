using System.ComponentModel.DataAnnotations;
using MudBlazor;

namespace GdscRecruitment.Features.Teams.Views;

public class TeamRequest
{
    [Label("Name")][Required] public string Name { get; set; }
    
    [Label("Team Lead")][Required] public string TeamLeadId { get; set; }
    
    [Label("Description")][Required] public string Description { get; set; }
}