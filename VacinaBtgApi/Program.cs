using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VacinaBtgApi.Data;
using VacinaBtgApi.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<VacinaDbContext>(opt =>
    opt.UseInMemoryDatabase("VacinaDb"));

builder.Services.AddMediatR(typeof(Program).Assembly);

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<CriarVacinaValidator>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
