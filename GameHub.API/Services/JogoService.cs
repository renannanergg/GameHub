using GameHub.API.Models;
using GameHub.API.Repositories;

namespace GameHub.API.Services
{
    public class JogoService: IJogoService
    {
        private readonly IJogoRepository _jogoRepository;

        public JogoService(IJogoRepository jogoRepository)
        {
            _jogoRepository = jogoRepository;
        }

        public void Adicionar(Jogo jogo)
        {
            _jogoRepository.Adicionar(jogo);
        }

        public Jogo? GetJogo(Func<Jogo, bool> condicao)
        {
            return _jogoRepository.GetJogo(condicao);
        }

        public IEnumerable<Jogo> ListarJogos()
        {
            return _jogoRepository.GetJogos();
        }

        public void Atualizar(Jogo jogo)
        {
            _jogoRepository.Atualizar(jogo);
        }
        public void Deletar(int id)
        {
            _jogoRepository.Deletar(id);
        }

        public IEnumerable<Jogo> ListarPor(Func<Jogo, bool> condicao)
        {
            return _jogoRepository.ListarPor(condicao);
        }
    }
}
