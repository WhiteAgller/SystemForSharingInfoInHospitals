using Common.DomainCommon;
using SpecializedExaminations.Domain.Entities;

namespace SpecializedExaminations.Domain.Events.ExaminitaionRequest;

public class ExaminationRequestedEvent : BaseEvent
{
    public ExaminationRequest ExaminitaionRequest { get; set; }

    public ExaminationRequestedEvent(ExaminationRequest examinitaionRequest)
    {
        ExaminitaionRequest = examinitaionRequest;
    }
}
