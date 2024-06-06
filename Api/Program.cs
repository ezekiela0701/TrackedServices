using Microsoft.EntityFrameworkCore ; 
using Api.Data ; 
using Api.Repositories ; 
using Api.Mapping ; 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

//database
builder.Services.AddDbContext<ServiceContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("TrackedServices"))
) ; 

//injecting repository
builder.Services.AddScoped<IClientRepository , SqlClientRepository>() ;
builder.Services.AddScoped<IUserRepository , SqlUserRepository>() ;
builder.Services.AddScoped<IServiceRepository , SqlServiceRepository>() ;

//injecting automapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile)) ;

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
