var policyName = "DemoCorsPolicy";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
	options.AddPolicy(name: policyName,
					  builder =>
					  {
						  // This url is based on front-end launchSettings.json file, under the configuration for 'ng serve'
						  builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();

						  // Additional origins would need to be added to handle other environments
					  }
	);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	// Automatically enables Swagger in dev environments
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(policyName);

app.UseAuthorization();

app.MapControllers();

app.Run();
