using Desafio.Business.Interfaces;
using Desafio.Business.Models;
using Desafio.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Data.Repository
{
    public class AutorRepository : Repository<Autor>, IAutorRepository
    {
        public AutorRepository(DesafioDbContext context) : base(context)
        {

        }
        public async Task<Autor> ObterAutor(Guid id)
        {
            return await Db.Autores.AsNoTracking().Include(a => a.Id)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async  Task<IEnumerable<Autor>> ObterAutores()
        {
            return await Db.Autores.AsNoTracking().Include(a => a.Id)
                .OrderBy(a => a.Nome).ToListAsync();
        }
    }
}
