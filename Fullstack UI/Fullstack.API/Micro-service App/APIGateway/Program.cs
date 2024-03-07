using Ocelot.Middleware;

namespace APIGateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);



            //builder.Services => {
            //    Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(WebBuilder => { WebBuilder.UseStartup<Startup>(); }).ConfigureAppConfiguration((ctx,Config)=> { Config.AddJsonFile("package.json")};
            //};

            // Add services to the container.
            builder.Services.AddRazorPages();

            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();
            app.UseOcelot();
            app.Run();
        }
    }
}