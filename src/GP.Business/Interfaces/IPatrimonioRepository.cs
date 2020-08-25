using GP.Business.Models;
using System.Collections;
using System.Threading.Tasks;

namespace GP.Business.Interfaces
{
    public interface IPatrimonioRepository : IRepository<Patrimonio>
    {
        Task<IEnumerable> ObterMarcaDoPatrimonio ();
    }
}
