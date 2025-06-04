var builder = WebApplication.CreateBuilder(args);

// Добавляем сервисы MVC
builder.Services.AddControllersWithViews(); // Важно для работы MVC

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Для работы главной страницы
app.UseRouting();
app.UseAuthorization();

// Настраиваем маршруты MVC
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Дополнительные маршруты для EchoController
app.MapControllerRoute(
    name: "echo",
    pattern: "echo/{action}",
    defaults: new { controller = "Echo" });

app.Run();