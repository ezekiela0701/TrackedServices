using Microsoft.EntityFrameworkCore ; 
using Api.Data ; 
using Api.Repositories ; 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//database
builder.Services.AddDbContext<ServiceContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("TrackedServices"))
) ; 

builder.Services.AddScoped<IClientRepository , SqlClientRepository>() ;


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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
