using Microsoft.EntityFrameworkCore;
using SchoolFinder.Data;
using SchoolFinder.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IExcelService, ExcelService>();
builder.Services.AddScoped<ISchoolEntitiesService, SchoolEntitiesService>();
builder.Services.AddScoped<ISubjectService, SubjectService>();

builder.Services.AddDbContext<SchoolfinderContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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

app.Run();
