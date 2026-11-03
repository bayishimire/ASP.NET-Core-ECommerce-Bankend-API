using Microsoft.EntityFrameworkCore;
using ASP.NET_Core_ECommerce_API.Data;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//difine databases
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
//add controller
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(Open_endpoint=>Open_endpoint.SerializeAsV2=true);
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapControllers();



app.Run();