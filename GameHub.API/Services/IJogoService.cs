using GameHub.API.Models;

namespace GameHub.API.Services
{
    public interface IJogoService
    {
        void Adicionar(Jogo jogo);
        Jogo? GetJogo(Func<Jogo, bool> condicao);
        IEnumerable<Jogo> ListarJogos();
        public IEnumerable<Jogo> ListarPor(Func<Jogo, bool> condicao);
        void Atualizar(Jogo jogo);
        void Deletar(int id);
    }
}
