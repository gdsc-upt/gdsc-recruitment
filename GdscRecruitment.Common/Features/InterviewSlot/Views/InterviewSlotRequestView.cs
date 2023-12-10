using System.ComponentModel.DataAnnotations;
using MudBlazor;

namespace GdscRecruitment.Common.Features.InterviewSlot.Views;

public class InterviewSlotRequestView
{
    [Label("TeamId")] [Required] public string TeamId { get; set; } = string.Empty;
    
    [Label("Date")][Required] public DateTime Date { get; set; }

    [Label("MeetingLink")] [Required] public string MeetingLink { get; set; } = string.Empty;
    
    [Label("CandidateId")] public string? CandidateId { get; set; }
}