using System;
using System.Collections.Generic;
using videos.catalog.Interfaces;

namespace videos.catalog
{
    public class RepositorioFilmes : IRepositorio<Filme>
    {
        private List<Filme> listaFilmes = new List<Filme>();

        public void atualizar(int id, Filme video)
        {
            listaFilmes[id] = video;
        }

        public void excluir(int id)
        {
            listaFilmes[id].excluir();
        }

        public void inserir(Filme video)
        {
            listaFilmes.Add(video);
        }

        public List<Filme> listar()
        {
            return listaFilmes;
        }

        public int proximoId()
        {
            return listaFilmes.Count;
        }

        public Filme retornarPorId(int id)
        {
            return listaFilmes[id];
        }

        public bool verificaId(int id)
        {
            if(listaFilmes.Exists(x => x.id == id))
                return true;

            return false;
        }
    }
}