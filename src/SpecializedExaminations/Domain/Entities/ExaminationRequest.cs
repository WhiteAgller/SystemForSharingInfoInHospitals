using Common.DomainCommon;

namespace SpecializedExaminations.Domain.Entities;

public class ExaminationRequest : BaseAuditableEntity
{
    public int PatientId { get; set; }
    
    public int? DoctorId { get; set; }
    
    public int ToDepartmentId { get; set; }

    public string ToSpecializedWorkplace { get; set; } = null!;
    
    public bool IsFinished { get; set; }

    public string Result { get; set; } = null!;
}
