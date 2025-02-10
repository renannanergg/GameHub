using GameHub.API.Endpoints;
using GameHub.API.Infra;
using GameHub.API.Repositories;
using GameHub.API.Services;

namespace GameHub.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ApplicationDbContext>();
            builder.Services.AddScoped<IJogoRepository, JogoRepository>();
            builder.Services.AddScoped<IJogoService, JogoService>();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();


            app.AddJogoEndpoints();
            app.UseSwagger();
            app.UseSwaggerUI();
            app.Run();
        }
    }
}
