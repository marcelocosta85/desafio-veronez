using Desafio.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Business.Interfaces
{
    public interface IAutorService : IDisposable
    {
        Task Adicionar(Autor autor);
        Task Atualizar(Autor autor);
        Task Remover(Guid id);

    }
}
