using GP.Business.Models;
using System;
using System.Threading.Tasks;

namespace GP.Business.Interfaces
{
    public interface IPatrimonioService : IDisposable
    {
        //Task Adicionar (Marca marca);
        Task Atualizar (Patrimonio patrimonio);
    }
}
