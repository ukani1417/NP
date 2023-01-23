using Microsoft.EntityFrameworkCore;
using NP.Data;
using NP.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddDbContext<DataContext>(options =>{
    options.UseSqlServer(builder.Configuration.GetConnectionString("App2"));
}
);
#region Services_Register
    builder.Services.AddScoped<IStudentServices,StudentServices>();
    builder.Services.AddScoped<IClassServices,ClassServices>();
#endregion


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
