using Cms.Data.Context;
using Cms.Data.Models.Entities;
using Cms.Services.Abstract;
using Cms.Services.Concrete;
using Cms.Web.Api.MappingProfiles;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddScoped<DbContext, AppDbContext>();

builder.Services.AddScoped<IDataRepository<DoctorEntity>, DataRepository<DoctorEntity>>();
builder.Services.AddScoped<IDataRepository<AdminEntity>, DataRepository<AdminEntity>>();
builder.Services.AddScoped<IDataRepository<PatientEntity>, DataRepository<PatientEntity>>();
builder.Services.AddScoped<IDataRepository<NavbarEntity>, DataRepository<NavbarEntity>>();
builder.Services.AddScoped<IDataRepository<BlogEntity>, DataRepository<BlogEntity>>();
builder.Services.AddScoped<IDataRepository<AppointmentEntity>, DataRepository<AppointmentEntity>>();
builder.Services.AddScoped<IDataRepository<ContactEntity>, DataRepository<ContactEntity>>();
builder.Services.AddScoped<IDataRepository<DepartmentEntity>, DataRepository<DepartmentEntity>>();
builder.Services.AddScoped<IDataRepository<DoctorCommentEntity>, DataRepository<DoctorCommentEntity>>();


builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IBlogService, BlogService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<INavbarService, NavbarService>();
builder.Services.AddScoped<IDoctorCommentService, DoctorCommentService>();




builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    await context.Database.EnsureDeletedAsync();
    await context.Database.EnsureCreatedAsync();
}
app.Run();
