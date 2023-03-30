using ApplicationLayer.Mappers;
using InfrastructureLayer.InfrastructureOrMiddleWare;
using InfrrastructureLayer;
using System.Diagnostics;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Logging.ClearProviders(); // The app already has AddConsole, AddDebug, and AddEventSourceLogger()??
//builder.Logging.AddDebug(); // This appears in Visual Studio's Output window (in my visual studio it is below the text editor window, same tab area package manager console and error list)
//Debug.WriteLine("hi");

builder.Services.ConfigureDbStuff(builder.Configuration["TheConnection"]);

//builder.Services.ConfigureDbStuff(builder.Configuration.GetConnectionString("TheConnection"));
//builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

var handlerAssembly = AppDomain.CurrentDomain.Load("ApplicationLayer");
builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(handlerAssembly));
builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//TODO: Remove these comments for final commmit
//if (!app.Environment.IsDevelopment()) {
//app.UseExceptionHandler();
app.ConfigureCustomExceptionMiddleware();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
