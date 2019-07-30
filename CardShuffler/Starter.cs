using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace CardShuffler
{
    /// <summary>
    /// Starting class that maps the configuration file and indicates what special 
    /// services are being used.
    /// </summary>
    public class Starter
    {
        public Starter(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            _ = services.AddSingleton<IDeckInterface, PlayingCardTarotDeck>().AddMvc();

            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new Info
            {
                Title = "Tarot API",
                Description = "API to supply a single session to track an entire bowling game for one user.",
                Version = "v1"
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tarot API V1");
            });

            app.UseMvc();
        }
    }
}
