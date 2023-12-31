using Microsoft.EntityFrameworkCore;
using QimiaLibrary.Business.DependencyInjection;
using QimiaLibrary.DataAccess;
using QimiaLibrary.DataAccess.Repositories.Abstractions;
using QimiaLibrary.DataAccess.Repositories.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<QimiaLibraryDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), options => options.CommandTimeout(120)));

builder.Services.AddScoped<IWorkerRepository, WorkerRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();

builder.Services.AddBusinessLayer();

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
