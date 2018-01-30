using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Cors;
using TicTacToeAPI.Models;

namespace TicTacToeAPI
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TicTacToeContext>(opt => opt.UseInMemoryDatabase("TicTacToeList"));
            services.AddMvc();
            services.AddCors(options => //https://docs.microsoft.com/en-us/aspnet/core/security/cors
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder.AllowAnyOrigin();
                    });
            });
        }

        public void Configure(IApplicationBuilder app)
        {
            // Shows UseCors with named policy.
            app.UseCors("AllowAllOrigins");
            app.UseMvc();
        }
    }
}