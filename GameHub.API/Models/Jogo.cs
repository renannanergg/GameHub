namespace GameHub.API.Models
{
    public class Jogo
    {
        public int Id { get; init; } 
        public string Nome { get; set; }
        public string Gênero { get; set; }
        public string Plataforma { get; set; }
        public string Descricao { get; set; }
        public int Ano_Lancamento { get; set; }

        // Construtor vazio para ORM
        public Jogo()
        {
            
        }

        public Jogo(string nome, string genero, string plataforma, string descricao, int ano)
        {
            this.Nome = nome;
            this.Gênero = genero;
            this.Plataforma = plataforma;
            this.Descricao = descricao;
            this.Ano_Lancamento = ano;
        }

    }
}
