using GP.Business.Interfaces;
using GP.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Business.Services
{
    public class MarcaService : IMarcaService
    {

        private readonly IMarcaRepository _marcaRepository;

        public MarcaService (IMarcaRepository marcaRepository)
        {
            _marcaRepository = marcaRepository;
        }

        public async Task Adicionar (Marca marca)
        {
            if (_marcaRepository.Buscar( m => m.Nome == marca.Nome ).Result.Any())
            {
                return;
            }

            await _marcaRepository.Adicionar( marca );
        }

        public async Task Atualizar (Marca marca)
        {

            if (_marcaRepository.Buscar( m => m.Nome == marca.Nome && m.Id != marca.Id ).Result.Any())
            {
                return;
            }

            await _marcaRepository.Atualizar( marca );
        }

        public void Dispose ()
        {
            _marcaRepository?.Dispose();
        }
    }
}

