using System.Net;
using MailServices.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(x => x.AddPolicy("EnableCors", builder => {
    builder.SetIsOriginAllowedToAllowWildcardSubdomains()
    .AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();

}));
builder.Services.AddSingleton<MailHelpers>();
builder.Services.AddSingleton<EnvHelper>();
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();
app.UseCors("EnableCors");

app.UseAuthorization();



app.MapControllers();

app.Run();
