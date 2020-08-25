using GP.Business.Models;
using System;
using System.Threading.Tasks;

namespace GP.Business.Interfaces
{
    public interface IMarcaService : IDisposable
    {
        Task Adicionar (Marca marca);
        Task Atualizar (Marca marca);
    }
}
