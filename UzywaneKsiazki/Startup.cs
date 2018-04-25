using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

            // IoC IPostService -> PostService
            services.AddTransient<IPostService, PostService>();

            // AutoMapper
            services.AddAutoMapper();

            services.AddMvc().AddJsonOptions(x => x.SerializerSettings.Formatting = Formatting.Indented);
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
            app.UseMvc();
            if (env.IsDevelopment())
            {
                DataSeed.Populate(app);
            }
        }
    }
}