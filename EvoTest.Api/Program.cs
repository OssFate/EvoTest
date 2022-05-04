using EvoTest.Api.Calls;
using EvoTest.Api.Data;
using EvoTest.Api.Services.Implementation;
using EvoTest.Api.Services.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DB
builder.Services.AddDbContext<AirportContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AirportDb"));
});

// Add Services
builder.Services.AddScoped<IAirportService, AirportService>();
builder.Services.AddScoped<IAirlineService, AirlineService>();
builder.Services.AddScoped<IPassengerTypeService, PassengerTypeService>();
builder.Services.AddScoped<IReservationService, ReservationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Add Calls
AirportCalls.SetCalls(app);

app.Run();