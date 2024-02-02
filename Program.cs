using Microsoft.Extensions.FileProviders;
using MvcFriends.Data;

// var builder = WebApplication.CreateBuilder(args);
var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    ApplicationName = typeof(Program).Assembly.FullName,
    // EnvironmentName = Environments.Staging,
    ContentRootPath = Directory.GetCurrentDirectory(),
    // WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "StaticFileLibrary")
});

System.Console.WriteLine($"Application Name: {builder.Environment.ApplicationName}");
System.Console.WriteLine($"Environment Name: {builder.Environment.EnvironmentName}");
System.Console.WriteLine($"ContentRoot Name: {builder.Environment.ContentRootPath}");
System.Console.WriteLine($"WebRoot Name: {builder.Environment.WebRootPath}");


// Add services to the container.
builder.Services.AddSession();
builder.Services.AddControllersWithViews();

string connectionString = builder.Configuration.GetConnectionString("FriendContext");

builder.Services.Configure<DevelperOptions>(option =>
{
    builder.Configuration.GetSection("Developer").Bind(option);
});


builder.Services.AddDbContext<FriendContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Logging.AddConsole();


WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles (); // 使用預設 wwwroot 資料夾

app.UseStaticFiles(new StaticFileOptions{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "StaticFilesLibrary")),
    RequestPath = "/StaticFiles"
});

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.UseSession();
app.Run();