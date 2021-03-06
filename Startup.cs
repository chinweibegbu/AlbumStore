using AlbumStore.Data;
using AlbumStore.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using System;

namespace AlbumStore
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
            // Context + Connection string
            services.AddDbContext<AlbumStoreContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("AlbumStoreConnection")));

            // Add Newtonsoft
            services.AddControllers().AddNewtonsoftJson(s =>
            {
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                s.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            // Automapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Repository interface mappings
            services.AddScoped<IAlbumRepository, SqlAlbumRepository>();
            services.AddScoped<IArtistRepository, SqlArtistRepository>();
            services.AddScoped<IArtistDescriptionRepository, SqlArtistDescriptionRepository>();
            services.AddScoped<IAlbumGenreRepository, SqlAlbumGenreRepository>();
            
            // Service interface mappings
            services.AddScoped<IAlbumService, AlbumService>();
            services.AddScoped<IArtistService, ArtistService>();
            services.AddScoped<IArtistDescriptionService, ArtistDescriptionService>();
            services.AddScoped<IAlbumGenreService, AlbumGenreService>();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
