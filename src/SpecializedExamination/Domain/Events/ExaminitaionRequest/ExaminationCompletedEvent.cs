using Common.DomainCommon;
using SpecializedExaminations.Domain.Entities;

namespace SpecializedExaminations.Domain.Events.ExaminitaionRequest;

public class ExaminationCompletedEvent : BaseEvent
{
    public ExaminationRequest ExaminitaionRequest { get; set; }

    public ExaminationCompletedEvent(ExaminationRequest examinitaionRequest)
    {
        ExaminitaionRequest = examinitaionRequest;
    }
}
