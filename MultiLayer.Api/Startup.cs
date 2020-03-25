using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MultiLayer.Core;
using MultiLayer.Core.Services;
using MultiLayer.Services;
using MUltiLayer.Data;


namespace MultiLayer.Api
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
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IMusicService, MusicService>();
            services.AddTransient<IArtistService, ArtistService>();
//            services.AddDbContext<MyMusicDbContext>(options =>
//            options.UseSqlServer( @"Data Source=DESKTOP-7RUDNLS\SQLE0XPRESS;Initial Catalog=SampleMusicAnishDB;Integrated Security =True"
//));
            services.AddDbContext<MyMusicDbContext>(options =>
            {
                options.UseSqlServer(
                    @"Server=DESKTOP-7RUDNLS\SQLEXPRESS;Database=SampleMusicAnishDB;Trusted_Connection=True;");
            });
            services.AddAutoMapper(typeof(Startup));
            //services.AddSwaggerGen(c => { //<-- NOTE 'Add' instead of 'Configure'
            //    c.SwaggerDoc("v3", new OpenApiInfo
            //    {
            //        Title = "GTrackAPI",
            //        Version = "v3"
            //    });
            //});

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            //app.UseSwagger();
            //app.UseSwaggerUI(c =>
            //{
            //    c.RoutePrefix = "";
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Music V1");
            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
