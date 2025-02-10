namespace GameHub.API.Models.DTOs
{
    public record JogoRequest(string nome, string genero, string plataforma, string descricao, int ano);

}
