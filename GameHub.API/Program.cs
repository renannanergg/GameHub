using GameHub.API.Endpoints;
using GameHub.API.Infra;
using GameHub.API.Infra.Modelos;
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
            builder.Services.AddTransient<IJogoRepository, JogoRepository>();
            builder.Services.AddTransient<IJogoService, JogoService>();

            builder.Services
                .AddIdentityApiEndpoints<PessoaComAcesso>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddAuthorization();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseAuthorization();

            app.AddJogoEndpoints();
            app.MapGroup("auth").MapIdentityApi<PessoaComAcesso>().WithTags("Autorização");

            app.UseSwagger();
            app.UseSwaggerUI();
            app.Run();
        }
    }
}
