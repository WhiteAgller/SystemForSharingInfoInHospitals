using Common.DomainCommon;
using SpecializedExaminations.Domain.Entities;

namespace SpecializedExaminations.Domain.Events.ExaminitaionRequest;

public class ExaminationStartedEvent : BaseEvent
{
    public ExaminationRequest ExaminitaionRequest { get; set; }

    public ExaminationStartedEvent(ExaminationRequest examinitaionRequest)
    {
        ExaminitaionRequest = examinitaionRequest;
    }
}
