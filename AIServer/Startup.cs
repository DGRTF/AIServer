using AIServer.Models.DBModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.IO;
using System.Text;

namespace AIServer
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
            services.AddControllers();

            // �������� ������ ����������� �� ����� ������������
            string connection = Configuration.GetConnectionString("DefaultConnection");
            // ��������� �������� MobileContext � �������� ������� � ����������
            services.AddDbContext<ApplicationDBContext>(options =>
                options.UseSqlServer(connection));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            // ��������, ����� �� �������������� �������� ��� ��������� ������
                            ValidateIssuer = true,
                            // ������, �������������� ��������
                            ValidIssuer = "MyAuthServer",

                            // ����� �� �������������� ����������� ������
                            ValidateAudience = true,
                            // ��������� ����������� ������
                            ValidAudience = "MyAuthClient",
                            // ����� �� �������������� ����� �������������
                            ValidateLifetime = true,

                            // ��������� ����� ������������
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("mysupersecret_secretkey!123")),
                            // ��������� ����� ������������
                            ValidateIssuerSigningKey = true,
                        };
                    });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/personal")
                {
                    var filePath = "./number-ml-paint/public/index.html";
                    var stremReader = new StreamReader(filePath);
                    var result = await stremReader.ReadToEndAsync();
                    await context.Response.WriteAsync(result);
                }
                else
                    await next();
            });

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseWebSockets();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
