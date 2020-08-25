using GP.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GP.Business.Interfaces
{
    public interface IMarcaRepository : IRepository<Marca>
    {
        Task<Marca> ObterPatrimoniosPorMarca (Guid id);
    }
}
