using System;

namespace videos.catalog
{
    public class Filme : AudioVisual
    {
        private string direcao { get; set; }
        private int duracao { get; set; }
        private int ano { get; set; }

        public Filme(int id, Genero genero, string titulo, string sinopse, string direcao, int duracao, int ano)
        {
            this.id = id;
            this.genero = genero;
            this.titulo = titulo;
            this.sinopse = sinopse;
            this.direcao = direcao;
            this.duracao = duracao;
            this.ano = ano;
            this.excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";

            retorno += "Título: " + this.titulo + Environment.NewLine;
            retorno += "Sinopse: " + this.sinopse + Environment.NewLine;
            retorno += "Gênero: " + this.genero + Environment.NewLine;
            retorno += "Direção: " + this.direcao + Environment.NewLine;
            retorno += "Duração: " + this.duracao + Environment.NewLine;
            retorno += "Ano: " + this.ano + Environment.NewLine;

            var excluido = this.excluido ? "Sim" : "Não";
            retorno += "Registro Excluído: " + excluido;

            return retorno;
        }
        public int retornarId()
        {
            return this.id;
        }
        
        public string retornarTitulo()
        {
            return this.titulo;
        }

        public bool retornarExclusao()
        {
            return this.excluido;
        }

        public void excluir()
        {
            this.excluido = true;
        }
    }
}