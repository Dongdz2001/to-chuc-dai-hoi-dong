using Microsoft.EntityFrameworkCore;
using To_chuc_dai_hoi.Data;
using To_chuc_dai_hoi.Repositories.CategoriesRepo;
using To_chuc_dai_hoi.Repositories.CategoryRePo;
using To_chuc_dai_hoi.Repositories.DaiBieuRePo;
using To_chuc_dai_hoi.Repositories.PeopleChooseProductRepo;
using To_chuc_dai_hoi.Repositories.PeopleChooseProductRePo;
using To_chuc_dai_hoi.Repositories.ProductRepo;
using To_chuc_dai_hoi.Repositories.ProductRePo;
using To_chuc_dai_hoi.Repositories.TinTucRePo;
using To_chuc_dai_hoi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Khởi tạo truy cập cho API
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});


// Map Database từ ConnectionString tới SQL Database Server
builder.Services.AddDbContext<ToChucDaiHoiContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("ToChucDaiHoi2023"));
});
// Đăng ký sử dụng AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

// Life cycle DI: AddSingleton(),  AddTransient(), AddScope()
builder.Services.AddScoped<iDaiBieuService, DaiBieuService>();
builder.Services.AddScoped<iTinTucService, TintucService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IPeopleChooseProductService, PeopleChooseProductService>();

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

app.UseCors(); // Thêm dòng này để kích hoạt CORS

app.Run();
