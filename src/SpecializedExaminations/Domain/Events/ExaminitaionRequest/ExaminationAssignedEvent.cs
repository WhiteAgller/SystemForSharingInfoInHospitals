using Common.DomainCommon;
using SpecializedExaminations.Domain.Entities;

namespace SpecializedExaminations.Domain.Events.ExaminitaionRequest;

public class ExaminationAssignedEvent : BaseEvent
{
    public ExaminationRequest ExaminitaionRequest { get; set; }

    public ExaminationAssignedEvent(ExaminationRequest examinitaionRequest)
    {
        ExaminitaionRequest = examinitaionRequest;
    }
}
