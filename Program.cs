using Dashboard.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Dashboard.Areas.Identity.Data;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });

        builder.Services.AddDbContext<DashboardDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });


        builder.Services.AddDefaultIdentity<DashboardUser>(options=> options.SignIn.RequireConfirmedAccount = true)
        .AddEntityFrameworkStores<DashboardDbContext>();
        builder.Services.AddRazorPages();
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();
        
        
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Shopping}/{action=Index}/{id?}");
        app.MapRazorPages();
        app.UseDeveloperExceptionPage();
        app.Run();
    }

    private static void AddEntityFrameworkStores<T>()
    {
        throw new NotImplementedException();
    }
}

