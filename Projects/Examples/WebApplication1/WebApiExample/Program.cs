
using Microsoft.EntityFrameworkCore;
using BAL.Interfaces;
using BAL.Models;
using BAL.Services;
using DAL;
using DAL.Generators;
using Microsoft.Extensions.Hosting;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
	options.AddPolicy("myPolicy", policy =>
	{
		policy.AllowAnyOrigin()
			.AllowAnyHeader()
			.AllowAnyMethod();
	});
}
);

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddDbContext<DatabaseContext>(option => option.UseInMemoryDatabase("MyDatabase"));

builder.Services.AddTransient<IPersonService, PersonService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
	// Get the instance of DatabaseContext in our services layer
	var services = scope.ServiceProvider;
	var context = services.GetRequiredService<DatabaseContext>();

	// Call the DataGenerator to create sample data
	DataGenerator.Initialize(services);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseCors("myPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
