using ApnaDukaan_v1.BLL.Middlewares;
using ApnaDukaan_v1.BLL.Services;
using ApnaDukaan_v1.BLL.Services.Impl;
using ApnaDukaan_v1.DAL.DBContext;
using ApnaDukaan_v1.DAL.Repositories.Impl;
using ApnaDukaan_v1.DAL.Repositories.Interface;
using AuthenticationAndAuthorizationPOC.BLL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
builder.Services.AddScoped<IServiceManager, ServiceManager>();

builder.Services.AddAutoMapper(typeof(Program).Assembly);


builder.Services.AddAndConfigureAuthentication(builder.Configuration);

builder.Services.AddDbContext<ApnaDukaanContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConStr"));
    opt.EnableServiceProviderCaching(true);
    opt.EnableThreadSafetyChecks();
    opt.EnableSensitiveDataLogging();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//app.UseExceptionHandlerMiddleware();

app.UseMyExceptionHandlerMiddleware();
app.MapControllers();

app.Run();
