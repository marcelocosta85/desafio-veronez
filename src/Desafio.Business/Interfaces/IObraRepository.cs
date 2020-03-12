using Desafio.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Business.Interfaces
{
    public interface IObraRepository : IRepository<Obra>
    {
        Task<IEnumerable<Obra>> ObterObrasPorAutor(Guid autorId);
        Task<IEnumerable<Obra>> ObterObrasAutores();
        Task<Obra> ObterObraAutor(Guid id);
    }
}
