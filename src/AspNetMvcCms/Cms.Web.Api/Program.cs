using Cms.Data.Context;
using Cms.Data.Models.Entities;
using Cms.Services.Abstract;
using Cms.Services.Concrete;
using Cms.Web.Api.MappingProfiles;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging(options => { 
	options.ClearProviders();
	options.AddConsole();
	options.AddEventLog();
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options => {
	var cs = builder.Configuration.GetConnectionString("Default");
	options.UseSqlServer(cs);
});
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
builder.Services.AddScoped<IDataRepository<CommentEntity>, DataRepository<CommentEntity>>();
builder.Services.AddScoped<IDataRepository<DoctorCategoryEntity>, DataRepository<DoctorCategoryEntity>>();
builder.Services.AddScoped<IDataRepository<PatientCommentEntity>, DataRepository<PatientCommentEntity>>();
builder.Services.AddScoped<IDataRepository<BlogCategoryEntity>, DataRepository<BlogCategoryEntity>>();
builder.Services.AddScoped<IDataRepository<ServiceBlogEntity>, DataRepository<ServiceBlogEntity>>();




builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IBlogService, BlogService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<INavbarService, NavbarService>();
builder.Services.AddScoped<IDoctorCommentService, DoctorCommentService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IDoctorCategoryService, DoctorCategoryService>();
builder.Services.AddScoped<IPatientCommentService, PatientCommentService>();
builder.Services.AddScoped<IBlogCategoriesService, BlogCategoriesService>();
builder.Services.AddScoped<IFileService, FileService>();



builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


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
	var loggerFactory = services.GetRequiredService<ILoggerFactory>();

	var logger = loggerFactory.CreateLogger<Program>();

	try
	{
        var context = services.GetRequiredService<AppDbContext>();
		logger.LogError("GOT DB CONTEXT");
        await context.Database.EnsureDeletedAsync();
        logger.LogError("DELETED DB");
        await context.Database.EnsureCreatedAsync();
        logger.LogError("CREATED DB");
    }
	catch (Exception ex)
	{
		logger.LogError(ex, "HATAAAAA!");
		return;
	}
}
app.Run();
