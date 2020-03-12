using Desafio.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Business.Interfaces
{
    public interface IObraService : IDisposable
    {
        Task Adicionar(Obra obra);
        Task Atualizar(Obra obra);
        Task Remover(Guid id);
    }
}
