using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.DbContexts;
using PlatformService.Repository;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<PlatformDbContext>(opt=>opt.UseInMemoryDatabase("InMemory"));
builder.Services.AddControllers();
builder.Services.AddScoped<IPlatformRepository, PlatformRepository>();
builder.Services.AddAutoMapper(cfg=>cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
PrepDb.Prepopulation(app);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

