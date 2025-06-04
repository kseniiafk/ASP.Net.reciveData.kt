var builder = WebApplication.CreateBuilder(args);

// ��������� ������� MVC
builder.Services.AddControllersWithViews(); // ����� ��� ������ MVC

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // ��� ������ ������� ��������
app.UseRouting();
app.UseAuthorization();

// ����������� �������� MVC
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// �������������� �������� ��� EchoController
app.MapControllerRoute(
    name: "echo",
    pattern: "echo/{action}",
    defaults: new { controller = "Echo" });

app.Run();