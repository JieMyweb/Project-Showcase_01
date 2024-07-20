using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using pr_common;
using pr_model;
using pr_model.Models;
using pr_service;
using pr_service.Config;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PGDB_01Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//��쵦��
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("CorsPolicy", opt => opt.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().WithExposedHeaders("X-Pagination"));
//});

//���ULog4net
builder.Logging.AddLog4Net("Config/log4net.Config");

//���UJWT
builder.Services.Configure<JWTTokenOptions>(builder.Configuration.GetSection("JWTTokenOptions"));

//���UAutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperConfigs));

//���UService�h�A��
//builder.Services.AddTransient<IBookService, BookService>();
//builder.Services.AddTransient<IUserService, UserService>();
//builder.Services.AddTransient<ICustomJWTService, CustomJWTService>();

//Autofac�`�J
builder.Host
    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new AutoRegister());
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

app.MapControllers();
//app.UseCors("CorsPolicy");

app.Run();
