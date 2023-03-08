using System.Reflection;
using CleanPoc.Application.Command.Leads;
using CleanPoc.Core.Repositories.Command.Base;
using CleanPoc.Core.Repositories.Command.Leads;
using CleanPoc.Core.Repositories.Query.Base;
using CleanPoc.Core.Repositories.Query.Leads;
using CleanPoc.Infrastructure.Data;
using CleanPoc.Infrastructure.Repositories.Command.Base;
using CleanPoc.Infrastructure.Repositories.Command.Leads;
using CleanPoc.Infrastructure.Repositories.Query.Base;
using CleanPoc.Infrastructure.Repositories.Query.Leads;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Add DbContextFactory
builder.Services.AddDbContextFactory<CleanContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c=>c.SwaggerDoc("v1", new() { Title = "CleanPoc", Version = "v1" }));
builder.Services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
builder.Services.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));
builder.Services.AddTransient<ILeadQueryRepository, LeadsQueryRepository>();
builder.Services.AddScoped(typeof(ICommandRepository<>), typeof(CommandRepository<>));
builder.Services.AddTransient<ILeadCommandRepository, LeadCommandRepository>();


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
