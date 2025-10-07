using GraphPersona.Api.Data;
using GraphPersona.Api.Extensions;
using GraphPersona.Api.GraphQL.Enums;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<GraphPersonaDbContext>(options =>
{
    options
        .UseNpgsql(builder.Configuration.GetConnectionString("Default"),
            o => o.MapEnum<ContactTypeEnum>("contact_type"));
});

builder.Services.AddGraphPersonaGraphQL();
builder.Services.AddGraphPersonaServices();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

app.MapGraphQL();

app.Run();