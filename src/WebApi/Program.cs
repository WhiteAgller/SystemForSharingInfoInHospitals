using Appointments;
using Common;
using HospitalManagement;
using Microsoft.OpenApi.Models;
using PatientManagement;
using SpecializedExaminations;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.SwaggerDoc("v1", new OpenApiInfo { Title = "Hospital API", Version = "v1" });
});

builder.Services.AddCommonServices();
builder.Services.AddAppointmentsServices(builder.Configuration);
builder.Services.AddHospitalManagementServices(builder.Configuration);
builder.Services.AddPatientManagementServices(builder.Configuration);
builder.Services.AddSpecializedExaminationServices(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    });
}

app.UseHttpsRedirection();
app.MapControllers();

// using var scope = ((IApplicationBuilder)app).ApplicationServices.CreateScope();
// using var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
// context?.Database.EnsureCreated();
// context?.Database.Migrate();

app.Run();

