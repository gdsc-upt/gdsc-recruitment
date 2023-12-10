using GdscRecruitment.Common.Features.Base;

namespace GdscRecruitment.Common.Features.InterviewSlot.Models;

public class InterviewSlotModel : Model
{
    public string TeamId { get; set; }
    
    public DateTime Date { get; set; }
    
    public string MeetingLink { get; set; }

    public string CandidateId { get; set; } = "null";
}