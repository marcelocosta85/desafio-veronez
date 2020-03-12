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
    public class ObraRepository : Repository<Obra>, IObraRepository
    {
        public ObraRepository(DesafioDbContext context) : base(context)
        {

        }
        public async Task<Obra> ObterObraAutor(Guid id)
        {
            return await Db.Obras.AsNoTracking().Include(a => a.Autor)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<IEnumerable<Obra>> ObterObrasAutores()
        {
            return await Db.Obras.AsNoTracking().Include(a => a.Autor)
                .OrderBy(o => o.Nome).ToListAsync();
        }

        public async Task<IEnumerable<Obra>> ObterObrasPorAutor(Guid autorId)
        {
            return await Buscar(o => o.AutorId == autorId);
        }
    }
}
