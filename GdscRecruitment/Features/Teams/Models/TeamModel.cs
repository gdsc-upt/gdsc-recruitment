using GdscRecruitment.Common.Features.Base;

namespace GdscRecruitment.Features.Teams.Models;

public class TeamModel : Model
{
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public string TeamLeadId { get; set; }
}