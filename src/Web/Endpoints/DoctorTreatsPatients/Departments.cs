
using SystemForSharingInfoInHospitals.Application.DoctorTreatsPatients.Commands.CreateDepartment;
using SystemForSharingInfoInHospitals.Application.DoctorTreatsPatients.Commands.UpdateDepartment;

namespace SystemForSharingInfoInHospitals.Web.Endpoints.DoctorTreatsPatients;

public class Departments : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapPost(CreateDepartment)
            .MapPut(UpdateDepartment, "{id}");
    }

    public async Task<int> CreateDepartment(ISender sender, CreateDepartmentCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<IResult> UpdateDepartment(ISender sender, int id, UpdateDepartmentCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }
}
