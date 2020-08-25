using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GP.App.ViewModels;
using AutoMapper;
using GP.Business.Interfaces;
using GP.Business.Models;
using GP.App.Extensions;

namespace GP.App.Controllers
{
    public class MarcasController : Controller
    {
        private readonly IMarcaRepository _marcaRepository;
        private readonly IMapper _mapper;
        private readonly IMarcaService _marcaService;

        public MarcasController(IMarcaRepository marcaRepository, IMapper mapper, IMarcaService marcaService)
        {
            _marcaRepository = marcaRepository;
            _mapper = mapper;
            _marcaService = marcaService;
        }

        // GET: Marcas
        [Route( "lista-de-marcas" )]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<MarcaViewModel>>( await _marcaRepository.ObterTodos()));
        }

        // GET: Marcas/Details/5
        [Route( "dados-da-marca/{id:guid}" )]
        public async Task<IActionResult> Details(Guid id)
        {
            var marcaViewModel =  _mapper.Map<MarcaViewModel>( await _marcaRepository.ObterPorId( id ));

            if (marcaViewModel == null)
            {
                return NotFound();
            }

            return View(marcaViewModel);
        }
        [Route( "dado-do-marca/{id:guid}" )]
        [Produces( "application/json" )]
        public async Task<MarcaViewModel> Detalhes (Guid id)
        {
            var marcaViewModel = _mapper.Map<MarcaViewModel>( await _marcaRepository.ObterPorId( id ) );

            if (marcaViewModel == null)
            {
                //return NotFound();
            }

            return marcaViewModel;
        }

        [Route( "dados-do-marca/{id:guid}/patrimonios" )]
        public async Task<IActionResult> Patrimonios (Guid id)
        {
            var marcaViewModel = _mapper.Map<MarcaViewModel>( await _marcaRepository.ObterPatrimoniosPorMarca( id ) );

            if (marcaViewModel == null)
            {
                return NotFound();
            }

            return View( marcaViewModel );
        }

        // GET: Marcas/Create
        [Route( "nova-marca" )]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Marcas/Create
        [HttpPost]
        [Route( "nova-marca" )]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( MarcaViewModel marcaViewModel)
        {
            if (!ModelState.IsValid) return View( marcaViewModel );

            var marca = _mapper.Map<Marca>( marcaViewModel );
            await _marcaService.Adicionar( marca );

            return RedirectToAction( nameof( Index ) );
        }

        // GET: Marcas/Edit/5
        [Route( "editar-marca/{id:guid}" )]
        public async Task<IActionResult> Edit(Guid id)
        {
            var marcaViewModel = _mapper.Map<MarcaViewModel>(await _marcaRepository.ObterPorId(id));

            if (marcaViewModel == null)
            {
                return NotFound();
            }
            return View(marcaViewModel);
        }

        // POST: Marcas/Edit/5
        [HttpPost]
        
        [Route( "editar-marca/{id:guid}" )]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, MarcaViewModel marcaViewModel)
        {
            if (id != marcaViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(marcaViewModel);

            var marca = _mapper.Map<Marca>( marcaViewModel );
            await _marcaService.Atualizar( marca );

            return View( _mapper.Map<MarcaViewModel>( await _marcaRepository.ObterPorId( id ) ) );

        }

        //GET: Marcas/Delete/5
        public async Task<IActionResult> Delete (Guid id)
        {
            var marcaViewModel = _mapper.Map<MarcaViewModel>(await _marcaRepository.ObterPorId(id));

            if (marcaViewModel == null)
            {
                return NotFound();
            }

            return View( marcaViewModel );
        }

        // POST: Marcas/Delete/5
        [HttpPost, ActionName( "Delete" )]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed (Guid id)
        {
            var marcaViewModel = _mapper.Map<MarcaViewModel>( await _marcaRepository.ObterPorId( id ));

            if (marcaViewModel == null) return NotFound();

            await _marcaRepository.Remover( id );

            return RedirectToAction( nameof( Index ) );
        }
    }
}
