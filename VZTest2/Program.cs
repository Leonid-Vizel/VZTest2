using AspNetCore.ReCaptcha;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using VZTest2;
using VZTest2.Data;
using VZTest2.Data.UnitOfWorks;

#region Culture settings
CultureInfo cultureInfo = new CultureInfo("ru-RU");
cultureInfo.NumberFormat.NumberDecimalSeparator = ".";
cultureInfo.NumberFormat.CurrencyDecimalSeparator = ".";
cultureInfo.NumberFormat.PercentDecimalSeparator = ".";
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
#endregion

var builder = WebApplication.CreateBuilder(args);
if (!builder.Environment.IsDevelopment())
{
    builder.WebHost.UseKestrel().UseContentRoot(Directory.GetCurrentDirectory()).UseUrls("http://*:5000");
}
// Add services to the container.
builder.Services.AddControllersWithViews();
//Activating Postgres Timestamps
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
// Add ReCaptcha V2
builder.Services.AddReCaptcha(builder.Configuration.GetSection("ReCaptcha"));
builder.Services.AddDistributedMemoryCache();
builder.Services.AddAutoMapper(typeof(AppMappingProfile));
builder.Services.AddRazorPages().AddMvcOptions(options =>
{
    options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(
        _ => "Укажите значение поля!");
    options.ModelBindingMessageProvider.SetValueMustBeANumberAccessor(
        _ => "Укажите численное значение!");
    options.ModelBindingMessageProvider.SetValueIsInvalidAccessor(
        _ => "Укажите значение поля!");
    options.ModelBindingMessageProvider.SetUnknownValueIsInvalidAccessor(
        _ => "Укажите значение поля!");
});
builder.Services.AddResponseCompression(options =>
{
    options.EnableForHttps = true;
    options.Providers.Add<BrotliCompressionProvider>();
    options.Providers.Add<GzipCompressionProvider>();
});
//session settings
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(6);
});
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
}
else
{
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DeployConnection")));
}
builder.Services.AddScoped<IAuthUnitOfWork, AuthUnitOfWork>();
// Add services to the container.
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseResponseCompression();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
