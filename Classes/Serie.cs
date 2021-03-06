using System;

namespace videos.catalog
{
    public class Serie : AudioVisual
    {
        private Canal canal { get; set; }
        private SerieStatus status { get; set; }
        private int anoInicio { get; set; }
        private int anoFim { get; set; }

        public Serie(int id, Genero genero, Canal canal, SerieStatus status, string titulo, string sinopse, int anoInicio, int anoFim)
        {
            this.id = id;
            this.genero = genero;
            this.canal = canal;
            this.status = status;
            this.titulo = titulo;
            this.sinopse = sinopse;
            this.anoInicio = anoInicio;
            this.anoFim = anoFim;
            this.excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";

            retorno += "Título: " + this.titulo + Environment.NewLine;
            retorno += "Sinopse: " + this.sinopse + Environment.NewLine;
            retorno += "Gênero: " + this.genero + Environment.NewLine;
            retorno += "Canal: " + this.canal + Environment.NewLine;
            retorno += "Status: " + this.status + Environment.NewLine;
            retorno += "Ano Início: " + this.anoInicio + Environment.NewLine;

            var fim = (this.anoFim == 0)? "-" : Convert.ToString(this.anoFim);
            retorno += "Ano Término: " + fim + Environment.NewLine;

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