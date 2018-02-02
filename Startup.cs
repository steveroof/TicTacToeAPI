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
            services.AddCors();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseCors(builder =>
               builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod());
            app.UseMvc();
        }
    }
}