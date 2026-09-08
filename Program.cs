using CURDUSingAPIEFCore.Models;
using CURDUSingAPIEFCore.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContextPool<CompanyContext>(
     opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("scon"))
    );
builder.Services.AddScoped<IProduct, ProductRepo>();
builder.Services.AddCors(opt => {
    opt.AddDefaultPolicy(policy => {
        //policy.WithHeaders("Accept", "Content-Type");
        policy.AllowAnyHeader();
        //policy.WithMethods("Get","Post");
        policy.AllowAnyMethod();
        //policy.WithOrigins("https://www.ritechpune.com", "https://www.revolutioninfosystems.com");
        policy.AllowAnyOrigin();
    });
});
var app = builder.Build();
app.UseCors();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();
