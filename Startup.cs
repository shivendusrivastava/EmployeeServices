using Employee.DataAccessLayer.DBContexts;
using Employee.DataAccessLayer.Repositories;
using Employee.Provider;
using Employee.Provider.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

namespace EmployeeServices
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<EmployeeContext>(options =>
            //{
            //    var server = "rds connection endpoint";
            //    var port = "1433";
            //    var database = "EMSDb";
            //    var user = "";
            //    var password = "";

            //    options.UseSqlServer(
            //        $"Server={server},{port};Initial Catalog={database};User ID={user};Password={password}",
            //        sqlServer => sqlServer.MigrationsAssembly("EmployeeServices"));
            //});
            services.AddControllers();
            services.AddDbContextPool<EmployeeContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IEmployeeProvider, EmployeeProvider>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
