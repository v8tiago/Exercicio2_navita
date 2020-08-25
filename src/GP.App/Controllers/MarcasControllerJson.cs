using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GP.App.ViewModels;
using AutoMapper;
using GP.Business.Interfaces;
using GP.Business.Models;
using GP.App.Extensions;

namespace GP.App.Controllers
{
    public class MarcasControllerJson : Controller
    {
        private readonly IMarcaRepository _marcaRepository;
        private readonly IMapper _mapper;
        private readonly IMarcaService _marcaService;

        public MarcasControllerJson (IMarcaRepository marcaRepository, IMapper mapper, IMarcaService marcaService)
        {
            _marcaRepository = marcaRepository;
            _mapper = mapper;
            _marcaService = marcaService;
        }

        // GET: Marcas
        [Route( "listademarcas" )]
        public async Task<IEnumerable<Marca>> Index ()
        {
            return await _marcaRepository.ObterTodos() ;
        }

        [Route( "dadodamarca/{id:guid}" )]
        public async Task<Marca> Detalhes (Guid id)
        {
            var marca = await _marcaRepository.ObterPorId( id ) ;

            if (marca == null)
            {
                //return NotFound();
            }

            return marca;
        }

        [Route( "dadodamarca/{id:guid}/patrimonios" )]
        public async Task<Marca> Patrimonios (Guid id)
        {
            var marca = await _marcaRepository.ObterPatrimoniosPorMarca( id );

            return marca;
        }

        // POST: Marcas/Create
        [HttpPost]
        [Route( "novamarca" )]
        public async void Create (Marca marca)
        {
            _marcaService.Adicionar( marca );

        }

        // POST: Marcas/Edit/5
        [HttpPut]
        [Route( "editarmarca/{id:guid}" )]
        public async Task<Marca> Edit (Guid id, Marca marca)
        {
            await _marcaService.Atualizar( marca );

            return await _marcaRepository.ObterPorId( id ) ;

        }

        // POST: Marcas/Delete/5
        [HttpPost, ActionName( "Delete" )]
        [Route( "deletemarca/{id:guid}" )]   
        public async void Delete (Guid id)
        {
            await _marcaRepository.Remover( id );

        }
    }
}
