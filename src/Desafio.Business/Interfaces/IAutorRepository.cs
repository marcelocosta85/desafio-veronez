using Desafio.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Business.Interfaces
{
    public interface IAutorRepository : IRepository<Autor>
    {
        Task<Autor> ObterAutor(Guid id);
        Task<IEnumerable<Autor>> ObterAutores();
    }
}
