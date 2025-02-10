using GameHub.API.Models;

namespace GameHub.API.Repositories
{
    public interface IJogoRepository
    {
        IEnumerable<Jogo> GetJogos();
        IEnumerable<Jogo> ListarPor(Func<Jogo, bool> condicao);
        Jogo? GetJogo(Func<Jogo, bool> condicao);
        void Adicionar(Jogo jogo);
        void Atualizar(Jogo jogo);
        void Deletar(int id);
        
    }
}
