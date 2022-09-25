using Microsoft.EntityFrameworkCore;
using PharmacyManagement_WebAPI.Models;
using PharmacyManagement_WebAPI.Repository;
using PharmacyManagement_WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<PharmacyDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyConStr"));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDoctorRepository, DoctorDAL>();
builder.Services.AddScoped<DoctorServices, DoctorServices>();
builder.Services.AddScoped<IMedicineRepository, MedicineDAL>();
builder.Services.AddScoped<MedicineServices,MedicineServices>();
builder.Services.AddScoped<IOrderRepository,OrderDAL>(); 
builder.Services.AddScoped<OrderServices,OrderServices>();
builder.Services.AddScoped<ISupplierRepository,SupplierDAL>();
builder.Services.AddScoped<SupplierServices,SupplierServices>();

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
