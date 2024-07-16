using Microsoft.EntityFrameworkCore;
using MyWebAPI.Data.MyDbContext;
using MyWebAPI.Exceptions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddControllers(options =>
{
    // Register the global exception handler
    options.Filters.Add<ErrorHandler>();
});

//////////////////////////////////////////////////////////////////////////////////////////
//Try injections of dependencies of the caseuse
try
{
    builder.Services.AddScoped<MyWebAPI.Domain.CaseUse.CreatePersonCaseUse>();
    builder.Services.AddScoped<MyWebAPI.Domain.CaseUse.GetAllPersonCaseUse>();
    builder.Services.AddScoped<MyWebAPI.Domain.CaseUse.UpdatePersonCaseUse>();
    builder.Services.AddScoped<MyWebAPI.Domain.CaseUse.GetByIdPersonCaseUse>();
    builder.Services.AddScoped<MyWebAPI.Domain.CaseUse.DeletePersonByIdCaseUse>();
    builder.Services.AddScoped<MyWebAPI.Domain.Mappers.PersonMapperDomain>();
    builder.Services.AddScoped<MyWebAPI.Presentter.Mappers.PersonMapperPresenter>();
    builder.Services.AddScoped<MyWebAPI.Data.MyDbContext.AppDbContext>();
} catch (Exception e) {
    Console.WriteLine(e.Message);
}

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
//////////////////////////////////////////////////////////////////////////////////////////

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
