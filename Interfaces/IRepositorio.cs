using System.Collections.Generic;

namespace videos.catalog.Interfaces
{
    public interface IRepositorio<T>
    {
         List<T> listar();
         T retornarPorId(int id);
         void inserir (T video);
         void excluir(int id);
         void atualizar(int id, T video);
         int proximoId();
         bool verificaId(int id);
    }
}