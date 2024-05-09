using LXP.Common;
using LXP.Core.IServices;
using LXP.Core.Services;
using LXP.Data.IRepository;
using LXP.Data.Repository;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


// Add services to the container.
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<IForgetRepository, ForgetRepository>();
builder.Services.AddScoped<IForgetService,ForgetService>();
builder.Services.AddScoped<IUpdatePasswordService, UpdatePasswordService>();
builder.Services.AddScoped<IUpdatePasswordRepository, UpdatePasswordRepository>();

builder.Services.AddSingleton<LXPDbContext>();



Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration).CreateLogger();


builder.Host.UseSerilog();



builder.Services.AddControllers();
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
