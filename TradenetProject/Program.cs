using Microsoft.EntityFrameworkCore;
using TradeNetProject.Data;
using TradeNetProject.Repositories;
using TradeNetProject.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Register DbContext with SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlServerOptionsAction: sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure(5);
        }));

// Register Repositories (Scoped - one per request, same as DbContext)
builder.Services.AddScoped<ITradeOfficerRepository, TradeOfficerRepository>();
builder.Services.AddScoped<ILicenseRepository, LicenseRepository>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<IDocumentRepository, DocumentRepository>();
builder.Services.AddScoped<IMarketRecordRepository, MarketRecordRepository>();
builder.Services.AddScoped<IComplianceRepository, ComplianceRepository>();

// Register Services
builder.Services.AddScoped<ITradeOfficerService, TradeOfficerService>();
builder.Services.AddScoped<ILicenseService, LicenseService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<IDocumentService, DocumentService>();
builder.Services.AddScoped<IMarketRecordService, MarketRecordService>();
builder.Services.AddScoped<IComplianceService, ComplianceService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=TradeOfficer}/{action=Dashboard}/{id?}");

app.MapRazorPages();

app.Run();
