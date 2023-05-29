using DevEvents.API.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddSingleton<EventsDbContext>();

// builder.Services.AddDbContext<EventsDbContext>(
//     o => o.UseInMemoryDatabase("DevEventsDb")
// );

var connectionString = builder.Configuration.GetConnectionString("DevEvents");

builder.Services.AddDbContext<EventsDbContext>(
     o => o.UseSqlServer(connectionString)
);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o => {
    o.SwaggerDoc("v1", new OpenApiInfo{
        Title = "DevEvents.API",
        Version = "v1",
        Contact = new OpenApiContact{
            Name = "Cleilton",
            Email = "cleilton.brigido@gmail.com",
            Url = new Uri("https://www.linkedin.com/in/cleilton-brigido/"),
        }
    });

    const string xmlFile =  "DevEvents.API.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    o.IncludeXmlComments(xmlPath);
});

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
