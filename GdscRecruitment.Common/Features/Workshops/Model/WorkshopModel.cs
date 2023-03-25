using GdscRecruitment.Common.Features.Base;

namespace GdscRecruitment.Common.Features.Workshops.Models;

public class WorkshopModel : Model
{
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public string Location { get; set; }
    
    public int Capacity { get; set; }
    
    public int ParticipantsNumber { get; set; }
    
    public string Trainer { get; set; }

    public List<string> Participants { get; set; }

}