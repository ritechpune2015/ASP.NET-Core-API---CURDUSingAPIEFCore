using CURDUSingAPIEFCore.Models;
using CURDUSingAPIEFCore.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContextPool<CompanyContext>(
     opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("scon"))
    );
builder.Services.AddScoped<IProduct, ProductRepo>();    
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();
