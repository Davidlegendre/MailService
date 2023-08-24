using System.Net;
using MailServices.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//public static IHostBuilder CreateHostBuilder(string[] args) =>
//    Host.CreateDefaultBuilder(args)
//        .ConfigureWebHostDefaults(webBuilder =>
//        {
//            webBuilder.UseStartup<Startup>();
//            var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
//            webBuilder.UseUrls($"http://*:{port}/");
//        });
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<MailHelpers>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseCors(x => x.AllowAnyHeader()
      .AllowAnyMethod()
      .WithOrigins("https://mailservice-496g-dev.fl0.io/"));
}
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
