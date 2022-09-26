//Este es el archivo que se está ejecutando

using Bootcamp.Queries.DocumentType;
using Bootcamp.Queries.Person;
using Bootcamp.Repositorio;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});



builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

//Se ejecutan los queries de Document Type
builder.Services.AddTransient<iDocumentTypeQueries, DocumentTypeQueries>();
//Se ejecutan los queries de Person Repository
builder.Services.AddTransient<iPersonRepository, PersonRepository>();
//Se ejecutan los queries de Person Queries
//builder.Services.AddTransient<iPersonQueries, PersonQueries>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");


app.UseAuthorization();

app.MapControllers();

app.Run();
