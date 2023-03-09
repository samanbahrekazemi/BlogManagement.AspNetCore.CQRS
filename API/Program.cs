using Infrastructure;
using Application;
using Serilog;
using Infrastructure.Seed;
using Infrastructure.Context;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

IConfiguration config = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();
//.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true).Build();


// Register services
ConfigureServices(builder.Services);

//Add Serilog https://github.com/serilog/serilog
builder.Host.UseSerilog((context, config) => { 
    config.ReadFrom.Configuration(context.Configuration);
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    await ApplicationDbContextSeed.SeedSampleDataAsync(context);
}



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


void ConfigureServices(IServiceCollection services)
{
    // Add services to the container.
    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    // Add other services here
    builder.Services
        .AddApplicationLayer()
        .AddInfrastructureLayer(config);
}