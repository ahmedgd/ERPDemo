using ERPDemo.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// إضافة Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ إضافة خدمة CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()  // ❗ للسماح بأي دومين (مثال: لو HTML خارجي أو من file://)
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// تسجيل DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

var app = builder.Build();

// تفعيل Swagger في بيئة التطوير
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ✅ تفعيل CORS
app.UseCors("AllowAll"); // لازم يكون قبل أي Middleware بيستخدم HTTP مثل controllers

app.UseAuthorization();

app.MapControllers();

// ✅ رسالة ترحيب بسيطة
app.MapGet("/", () => "✅ ERP Demo API is running. Welcome!");

app.Run();
