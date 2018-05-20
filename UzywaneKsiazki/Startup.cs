using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using UzywaneKsiazki.Helpers;

namespace UzywaneKsiazki
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using UzywaneKsiazki.Models.Mapper;
    using UzywaneKsiazki.Models.Repository;
    using UzywaneKsiazki.Models.Services;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            // appconfig.json
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlite(this.Configuration["Data:KsiazkiPosts:ConnectionString"]));

            // IoC IRepository -> EFRepository
            services.AddTransient<IPostRepository, EfPostsRepository>();
            services.AddTransient<IUserRepository, EfUserRepository>();

            // IoC IPostService -> PostService
            services.AddTransient<IPostService, PostService>();
            services.AddTransient<IAuthService, AuthService>();


            // AutoMapper
            services.AddAutoMapper();

            services.AddMvc().AddJsonOptions(x => x.SerializerSettings.Formatting = Formatting.Indented);

            //jwt

            var appSettingsSection = Configuration.GetSection("Auth");
            services.Configure<AppSettingsSecret>(appSettingsSection);


            var appSettings = appSettingsSection.Get<AppSettingsSecret>();
            var key = Encoding.ASCII.GetBytes(appSettings.SecretCode);

            services.AddTransient<Auth>(service => new Auth(appSettings));

            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            // tutaj mozemy dodac nasze wlasne wymogi dot. zawartości tokena
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
                options.AddPolicy("CustomClaim", policy=> policy.RequireClaim("CustomClaim", "moge tutaj wpisac co chce :)"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseDeveloperExceptionPage();
            app.UseCors(x =>
            {
                x.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
            });
            // jwt
            app.UseAuthentication();
            app.UseMvc();
            if (env.IsDevelopment())
            {
                DataSeed.Populate(app);
            }
        }
    }
}