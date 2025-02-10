using System;
using System.Linq;
using GameHub.API.Infra;
using GameHub.API.Models;

namespace GameHub.API.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private readonly ApplicationDbContext _context;
        public JogoRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Adicionar(Jogo jogo)
        {
            _context.Jogos.Add(jogo);
            _context.SaveChanges();
        }

        public void Atualizar(Jogo jogo)
        {
            var jogoExistente = _context.Jogos.Find(jogo.Id); // Busca a entidade existente

            if (jogoExistente == null)
            {
                throw new Exception("Jogo não encontrado"); // 
            }

            _context.Entry(jogoExistente).CurrentValues.SetValues(jogo); // Atualiza as propriedades

            _context.SaveChanges();
            //_context.Jogos.Update(jogo);  
            //_context.SaveChanges();
        }

        public void Deletar(int id)
        {
            var jogo = _context.Jogos.Find(id);
            if (jogo is not null)
            {
                _context.Jogos.Remove(jogo);
                _context.SaveChanges();
            }
        }

        public Jogo? GetJogo(Func<Jogo, bool> condicao)
        {
            return _context.Set<Jogo>().FirstOrDefault(condicao);
        }

        public IEnumerable<Jogo> GetJogos()
        {
            return _context.Jogos.ToList();
        }

        public IEnumerable<Jogo> ListarPor(Func<Jogo, bool> condicao)
        {
            return _context.Set<Jogo>().Where(condicao);
        }
    }
}
