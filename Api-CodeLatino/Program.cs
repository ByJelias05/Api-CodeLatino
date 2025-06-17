using Api_CodeLatino.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


//Extraigo la cadena de conexion desde el archivo de configuracion
var conncetionString = builder.Configuration.GetConnectionString("");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuro el DbContext para usar SQL Server con la cadena de conexion extraida
builder.Services.AddDbContext<CodeLatinoContext>(options => options.UseSqlServer(conncetionString));

// Configuro CORS para permitir peticiones desde cualquier origen
builder.Services.AddCors(options =>
    options.AddPolicy("AllowWeb", policy =>
       policy.WithOrigins("https://codelatino.onrender.com")
       .AllowAnyHeader()
       .AllowAnyMethod()
    ));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowWeb");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
