using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GP.App.ViewModels;
using GP.Business.Interfaces;
using AutoMapper;
using GP.Business.Models;

namespace GP.App.Controllers
{
    public class PatrimoniosController : Controller
    {
        private readonly IPatrimonioRepository _patrimonioRepository;
        private readonly IMapper _mapper;
        private readonly IPatrimonioService _patrimonioService;
        private readonly IMarcaRepository _marcaRepository;

        public PatrimoniosController (IPatrimonioRepository patrimonioRepository,
                                    IMapper mapper, IPatrimonioService patrimonioService, IMarcaRepository marcaRepository)
        {
            _patrimonioRepository = patrimonioRepository;
            _mapper = mapper;
            _patrimonioService = patrimonioService;
            _marcaRepository = marcaRepository;
        }

        // GET: Patrimonios
        [Route( "lista-de-patrimonios" )]
        public async Task<IActionResult> Index()
        {
            return View( _mapper.Map<IEnumerable<PatrimonioViewModel>>( await _patrimonioRepository.ObterMarcaDoPatrimonio() ) );
        }

        // GET: Patrimonios/Details/5
        [Route( "dados-do-patrimonio/{id:guid}" )]
        public async Task<IActionResult> Details(Guid id)
        {
            var patrimonioViewModel = _mapper.Map<PatrimonioViewModel>( await _patrimonioRepository.ObterPorId(id) );

            if (patrimonioViewModel == null)
            {
                return NotFound();
            }

            return View( patrimonioViewModel );
        }

        // GET: Patrimonios/Create
        [Route( "novo-patrimonio" )]
        public async Task<IActionResult> Create()
        {
            var patrimonioViewModel = await PopularMarcas( new PatrimonioViewModel() );

            return View( patrimonioViewModel );
        }

        // POST: Patrimonios/Create
        [HttpPost]
        [Route( "novo-patrimonio" )]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PatrimonioViewModel patrimonioViewModel)
        {
            patrimonioViewModel = await PopularMarcas( patrimonioViewModel );
            if (!ModelState.IsValid) return View( patrimonioViewModel );

            var patrimonio = _mapper.Map<Patrimonio>( patrimonioViewModel );
            await _patrimonioRepository.Adicionar( patrimonio );

            return RedirectToAction( nameof( Index ) );
        }

        // GET: Patrimonios/Edit/5
        [Route( "editar-patrimonio/{id:guid}" )]
        public async Task<IActionResult> Edit(Guid id)
        {
            var patrimonioViewModel = _mapper.Map<PatrimonioViewModel>( await _patrimonioRepository.ObterPorId( id ) );

            if (patrimonioViewModel == null)
            {
                return NotFound();
            }
            return View( patrimonioViewModel );
        }

        // POST: Patrimonios/Edit/5
        [HttpPost]
        [Route( "editar-patrimonio/{id:guid}" )]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, PatrimonioViewModel patrimonioViewModel)
        {
            if (id != patrimonioViewModel.Id) return NotFound();

            var patrimonioAtualizacao = _mapper.Map<PatrimonioViewModel>( await _patrimonioRepository.ObterPorId( id ) );
            patrimonioViewModel.Marca = patrimonioAtualizacao.Marca;

            if (!ModelState.IsValid) return View( patrimonioViewModel );

            var patrimonio = _mapper.Map<Patrimonio>( patrimonioViewModel );

            patrimonioAtualizacao.Nome = patrimonioViewModel.Nome;
            patrimonioAtualizacao.Descricao = patrimonioViewModel.Descricao;

           await _patrimonioService.Atualizar( _mapper.Map<Patrimonio>(patrimonioAtualizacao ) );

            return View( _mapper.Map<PatrimonioViewModel>( await _patrimonioRepository.ObterPorId( id ) ) );
        }

        // GET: Patrimonios/Delete/5
        [Route( "excluir-patrimonio/{id:guid}" )]
        public async Task<IActionResult> Delete(Guid id)
        {
            var patrimonioViewModel = _mapper.Map<PatrimonioViewModel>( await _patrimonioRepository.ObterPorId( id ) );

            if (patrimonioViewModel == null)
            {
                return NotFound();
            }

            return View( patrimonioViewModel );
        }

        // POST: Patrimonios/Delete/5
        [HttpPost, ActionName("Delete")]
        [Route( "excluir-patrimonio/{id:guid}" )]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var patrimonioViewModel = _mapper.Map<PatrimonioViewModel>( await _patrimonioRepository.ObterPorId( id ) );

            if (patrimonioViewModel == null) return NotFound();

            await _patrimonioRepository.Remover( id );

            return RedirectToAction( nameof( Index ) );
        }


        private async Task<PatrimonioViewModel> PopularMarcas (PatrimonioViewModel patrimonio)
        {
            patrimonio.Marcas = _mapper.Map<IEnumerable<MarcaViewModel>>( await _marcaRepository.ObterTodos() );
            return patrimonio;
        }
    }
}
