
using SystemForSharingInfoInHospitals.Application.DoctorTreatsPatients.Commands.RegisterDoctor;
using SystemForSharingInfoInHospitals.Application.DoctorTreatsPatients.Commands.UpdateDoctor;

namespace SystemForSharingInfoInHospitals.Web.Endpoints.DoctorTreatsPatients;

public class Doctors : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapPost(RegisterDoctor)
            .MapPut(UpdateDoctor, "{id}")
            .MapPut(SetOfficeHours, "SetOfficeHours/{id}");
    }

    public async Task<int> RegisterDoctor(ISender sender, RegisterDoctorCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<IResult> UpdateDoctor(ISender sender, int id, UpdateDoctorCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task <IResult> SetOfficeHours(ISender sender, int id, SetOfficeHoursCommand command)
    {
        if (id != command.DoctorId) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }
}
