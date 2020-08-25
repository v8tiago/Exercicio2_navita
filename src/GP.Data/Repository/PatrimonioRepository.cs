using GP.Business.Interfaces;
using GP.Business.Models;
using GP.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GP.Data.Repository
{
    public class PatrimonioRepository : Repository<Patrimonio>, IPatrimonioRepository
    {
        public PatrimonioRepository (MeuContext context) : base( context )
        {
        }

        public async Task<IEnumerable> ObterMarcaDoPatrimonio ()
        {
            return await Db.Patrimonios.AsNoTracking()
                        .Include( p => p.Marca )
                        .ToListAsync();
        }
    }
}
