using mxm_webDiet.Controllers;
using mxm_webDiet.Infra.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddHttpClient<DietController>();
builder.Services.AddScoped<DietService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
