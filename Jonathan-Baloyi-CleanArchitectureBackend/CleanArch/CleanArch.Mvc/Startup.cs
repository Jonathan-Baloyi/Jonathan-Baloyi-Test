using AutoMapper;
using CleanArch.Infrastructure.Data.Context;
using CleanArch.Infrastructure.IoC;
using CleanArch.Mvc.Data;
using CleanArch.Mvc.Mapping;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;

namespace CleanArch.Mvc
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
            services.AddSwaggerGen();

            services.AddCors();

            services.AddControllers();

            // Application Db Context will be more valuable when we introduce authentication and authorization to the app
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("StudentIdentityDbConnection")));

            services.AddDbContext<SchoolDBContext>(options =>
            {
                options.UseSqlServer(
                    Configuration.GetConnectionString("StudentDbConnection"));
            });

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            // Auto Mapper Configurations
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();



            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseSwagger(c =>
            {
                c.RouteTemplate = "swagger/{documentName}/swagger.json";
            });

            app.UseRouting();

            UpdateSchoolDatabase(app);
            UpdateIdentityDatabase(app);
            SeedSchoolStudentsData(app);

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }

        public static void RegisterServices(IServiceCollection services)
        {
            DependencyContainer.RegisterServices(services);
        }

        // This will perform migration of the school db autocally when the app starts up
        private static void UpdateSchoolDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<SchoolDBContext>())
                {
                    context.Database.Migrate();
                }
            }
        }

        // This will perform the migration of the identity db automatically when the app starts up
        private static void UpdateIdentityDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>())
                {
                    context.Database.Migrate();
                }
            }
        }

        private static void SeedSchoolStudentsData(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<SchoolDBContext>())
                {
                    context.Database.EnsureCreated();

                    if (context.Students.Any())
                    {
                        return;
                    }

                    context.Students.Add(new Domain.Models.Student
                    {
                        Name = "Malamba",
                        Surname = "Nemavhadwe",
                        DateOfBirth = "1997-04-31",
                        Gender = "Male",
                        Grade = "GR11",
                        SchoolCode = "SKH",
                        SchoolName = "Skye High"
                    });

                    context.Students.Add(new Domain.Models.Student
                    {
                        Name = "Talenta",
                        Surname = "Matiane",
                        DateOfBirth = "1998-01-26",
                        Gender = "Female",
                        Grade = "GR10",
                        SchoolCode = "SKH",
                        SchoolName = "Skye High"
                    });

                    context.Students.Add(new Domain.Models.Student
                    {
                        Name = "Nyandano",
                        Surname = "Madiba",
                        DateOfBirth = "1998-07-15",
                        Gender = "Male",
                        Grade = "GR10",
                        SchoolCode = "SKH",
                        SchoolName = "Skye High"
                    });

                    context.Students.Add(new Domain.Models.Student
                    {
                        Name = "Tovhowani",
                        Surname = "Mulovhedzi",
                        DateOfBirth = "1998-02-22",
                        Gender = "Male",
                        Grade = "GR10",
                        SchoolCode = "SKH",
                        SchoolName = "Skye High"
                    });

                    context.Students.Add(new Domain.Models.Student
                    {
                        Name = "Siphokazi",
                        Surname = "Hlalukana",
                        DateOfBirth = "1996-01-21",
                        Gender = "Female",
                        Grade = "GR12",
                        SchoolCode = "SKH",
                        SchoolName = "Skye High"
                    });

                    context.Students.Add(new Domain.Models.Student
                    {
                        Name = "Duncan",
                        Surname = "Smith",
                        DateOfBirth = "1997-11-27",
                        Gender = "Male",
                        Grade = "GR11",
                        SchoolCode = "PH",
                        SchoolName = "Park High"
                    });

                    context.Students.Add(new Domain.Models.Student
                    {
                        Name = "Mpho ",
                        Surname = "Ramagoma",
                        DateOfBirth = "1967-04-31",
                        Gender = "Female",
                        Grade = "GR11",
                        SchoolCode = "PH",
                        SchoolName = "Park High"
                    });

                    context.Students.Add(new Domain.Models.Student
                    {
                        Name = "Eunice",
                        Surname = "Bosch",
                        DateOfBirth = "1997-05-25",
                        Gender = "Female",
                        Grade = "GR11",
                        SchoolCode = "PH",
                        SchoolName = "Park High"
                    });

                    context.Students.Add(new Domain.Models.Student
                    {
                        Name = "Thendo Yeolaine ",
                        Surname = "Masutha",
                        DateOfBirth = "1996-07-18",
                        Gender = "Not Given",
                        Grade = "GR12",
                        SchoolCode = "PH",
                        SchoolName = "Park High"
                    });

                    context.Students.Add(new Domain.Models.Student
                    {
                        Name = "Nomaan",
                        Surname = "Mulla",
                        DateOfBirth = "1996-08-09",
                        Gender = "Male",
                        Grade = "GR12",
                        SchoolCode = "PH",
                        SchoolName = "Park High"
                    });

                    context.SaveChanges();
                }
            }
        }
    }
}
