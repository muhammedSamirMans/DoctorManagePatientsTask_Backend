using DoctorManagePatientsTask_App.Extensions;
using DoctorManagePatientsTask_App.MapperProfiles;
using DoctorManagePatientsTask_DAL.Context;
using DoctorManagePatientsTask_DAL.Repositories.Impelementations;
using DoctorManagePatientsTask_DAL.Repositories.Interfaces;
using DoctorManagePatientsTask_Services_BLL.Impelementations.Patients;
using DoctorManagePatientsTask_Services_BLL.Interfaces.Patients;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;
using System.Reflection;


#region Registering Services

var builder = WebApplication.CreateBuilder(args);
//Register All My Dependancy in the extention method RegisterDependancy().
builder.Services.RegisterDependancy();

//AutoMapper Configration
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Inject DBContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region CORs Setting
//Setting for make my angular app can access the apis with no cors issues.
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

#endregion

#endregion

#region App Building

//builder.Services.AddScoped<>
var app = builder.Build();
//dataContext.Database.Migrate();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

#endregion