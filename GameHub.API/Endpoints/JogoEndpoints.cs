using GameHub.API.Models;
using GameHub.API.Models.DTOs;
using GameHub.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameHub.API.Endpoints
{
    public static class JogoEndpoints
    {
        public static void AddJogoEndpoints(this WebApplication app)
        {
            app.MapGet("/Jogos", ([FromServices] IJogoService jogoService) =>
            {
                return Results.Ok(jogoService.ListarJogos());
            });
            app.MapGet("/Jogos/{nome}", ([FromServices] IJogoService jogoService, string nome) =>
            {
                var jogo = jogoService.GetJogo(j => j.Nome.ToUpper().Equals(nome.ToUpper()));
                if (jogo is null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(jogo);
            });
            app.MapPost("/Jogos", ([FromServices] IJogoService jogoService, [FromBody] JogoRequest jogoRequest) =>
            {
                var novoJogo = new Jogo
                {
                    Nome = jogoRequest.nome,
                    Gênero = jogoRequest.genero,
                    Plataforma = jogoRequest.plataforma,
                    Descricao = jogoRequest.descricao,
                    Ano_Lancamento = jogoRequest.ano
                };
                jogoService.Adicionar(novoJogo);
                return Results.Created();
            });
            app.MapPut("/Jogos/{id}", ([FromServices] IJogoService jogoService, [FromBody] Jogo jogo) =>
            {
                var jogoExistente = jogoService.GetJogo(j => j.Id == jogo.Id);
                if (jogoExistente is null)
                {
                    return Results.NotFound();
                }

                jogoService.Atualizar(jogo);
                return Results.Ok(jogo);
            });
            app.MapDelete("/Jogos/{id}", ([FromServices] IJogoService jogoService, int id) =>
            {
                var jogo = jogoService.GetJogo(j => j.Id == id);
                if (jogo == null)
                {
                    return Results.NotFound();
                }
                jogoService.Deletar(id);
                return Results.NoContent();
            });

            app.MapGet("/Jogos/Plataforma/{plataforma}", ([FromServices] IJogoService jogoService, string plataforma) =>
            {
                var jogos = jogoService.ListarPor(j => j.Plataforma.ToUpper().Equals(plataforma.ToUpper()));
                if (jogos is null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(jogos);
            });

            app.MapGet("/Jogos/Genero/{genero}", ([FromServices] IJogoService jogoService, string genero) =>
            {
                var jogos = jogoService.ListarPor(j => j.Gênero.ToUpper().Equals(genero.ToUpper()));
                if (jogos is null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(jogos);
            });

            app.MapGet("/Jogos/Ano/{ano}", ([FromServices] IJogoService jogoService, int ano) =>
            {
                var jogos = jogoService.ListarPor(j => j.Ano_Lancamento == ano);
                if (jogos is null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(jogos);
            });
        }
    }
}
