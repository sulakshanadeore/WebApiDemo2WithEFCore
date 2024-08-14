using WebApiDemo2.Models;
using Microsoft.EntityFrameworkCore;
using WebApiDemo2.Areas.Suppliers.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.


        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddDbContext<NorthwindDataContext>
            (options => options.UseSqlServer(builder.Configuration.GetConnectionString("nwCnString")));

        builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
        builder.Services.AddScoped<ISuppRepo, SuppRepo>();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowOrigins",
                                  policy =>
                                  {
                                      policy.WithOrigins("http://127.0.0.1:5500");
                                      policy.AllowAnyHeader();
                                      policy.AllowAnyMethod();
                                  });
        });
        var app = builder.Build();

        // Configure the HTTP request pipeline.
       

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
              name: "areas",
              pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
            );
        });

        app.UseCors("AllowOrigins");
        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}