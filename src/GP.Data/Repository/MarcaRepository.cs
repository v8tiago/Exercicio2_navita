using GP.Business.Interfaces;
using GP.Business.Models;
using GP.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace GP.Data.Repository
{
    public  class MarcaRepository : Repository<Marca>, IMarcaRepository
    {
        public MarcaRepository (MeuContext context) : base( context )
        {
        }

        public async Task<Marca> ObterPatrimoniosPorMarca (Guid id)
        {
            return await Db.Marcas.AsNoTracking()
                .Include( c => c.Patrimonios )
                .FirstOrDefaultAsync( c => c.Id == id );
        }
    }
}
