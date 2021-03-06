using System;
using System.Collections.Generic;
using videos.catalog.Interfaces;

namespace videos.catalog
{
    public class RepositorioSeries : IRepositorio<Serie>
    {
        private List<Serie> listaSeries = new List<Serie>();

        public void atualizar(int id, Serie video)
        {
            listaSeries[id] = video;
        }

        public void excluir(int id)
        {
            listaSeries[id].excluir();
        }

        public void inserir(Serie video)
        {
            listaSeries.Add(video);
        }

        public List<Serie> listar()
        {
            return listaSeries;
        }

        public int proximoId()
        {
            return listaSeries.Count;
        }

        public Serie retornarPorId(int id)
        {
            return listaSeries[id];
        }

        public bool verificaId(int id)
        {
            if(listaSeries.Exists(x => x.id == id))
                return true;

            return false;
        }
    }
}