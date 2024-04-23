using mxm_webDiet.Controllers;
using mxm_webDiet.Infra.Services;
using Microsoft.EntityFrameworkCore;
using mxm_webDiet.Domains.dbContext;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddHttpClient<DietController>();
builder.Services.AddScoped<DietService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

 var defaultConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    builder.Services.AddDbContext<DietDbContext>(options => {
    options.UseSqlite(defaultConnectionString);
    });


builder.Services.AddCors(options =>
{
   options.AddDefaultPolicy(
     policy =>
     {
       policy.AllowAnyOrigin()
           .AllowAnyHeader()
           .AllowAnyMethod();
     });
});

var app = builder.Build();
app.UseCors();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
