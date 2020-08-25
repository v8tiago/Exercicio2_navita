using GP.Business.Interfaces;
using GP.Business.Models;
using System.Linq;
using System.Threading.Tasks;

namespace GP.Business.Services
{
    public class PatrimonioService : IPatrimonioService
    {

        private readonly IPatrimonioRepository _patrimonioRepository;

        public PatrimonioService (IPatrimonioRepository patrimonioRepository)
        {
            _patrimonioRepository = patrimonioRepository;
        }

        //public async Task Adicionar (Marca marca)
        //{
        //    if (_patrimonioRepository.Buscar( f => f.Nome == marca.Nome ).Result.Any())
        //    {
        //        return;
        //    }

        //    await _patrimonioRepository.Adicionar( marca );
        //}

        public async Task Atualizar (Patrimonio patrimonio)
        {
            await _patrimonioRepository.Atualizar( patrimonio );
        }

        public void Dispose ()
        {
            _patrimonioRepository?.Dispose();
        }
    }
}

