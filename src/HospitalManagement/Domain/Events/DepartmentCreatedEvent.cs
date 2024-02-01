using Common.DomainCommon;
using HospitalManagement.Domain.Entities;

namespace HospitalManagement.Domain.Events;
public class DepartmentCreatedEvent : BaseEvent
{
    public DepartmentCreatedEvent(Department department)
    {
        Department = department;
    }
    public Department Department { get; set;}
}
