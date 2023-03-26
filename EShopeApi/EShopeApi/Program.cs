using EShopeApi.DBContext;
using EShopeApi.Repository.ProductRepo;
using EShopeApi.Repository.UserLoginRepo;
using EShopeApi.Repository.UserRegistraionRepo;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IProductHelper, ProductHelper>();
builder.Services.AddTransient<IUserLoginHelper,UserLoginHelper>();
builder.Services.AddTransient<IuserRegisterHelper, UserRegisterHelper>();

//AutoMapper Services
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// DataConnection Services
builder.Services.AddDbContext<DataContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection"));
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

app.Run();
