using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Desafio.App.ViewModels;
using Desafio.Business.Interfaces;
using AutoMapper;
using Desafio.Business.Models;

namespace Desafio.App.Controllers
{
    public class ObrasController : BaseController
    {
        private readonly IObraRepository _obraRepository;
        private readonly IAutorRepository _autorRepository;
        private readonly IObraService _obraService;
        private readonly IMapper _mapper;

        public ObrasController(IObraRepository obraRepository,
                               IAutorRepository autorRepository,
                               IObraService obraService,
                               IMapper mapper,
                               INotificador notificador) :base(notificador)
        {
            _obraRepository = obraRepository;
            _autorRepository = autorRepository;
            _obraService = obraService;
            _mapper = mapper;
        }

        // GET: Obras
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ObraViewModel>>(await _obraRepository.ObterObrasAutores()));
        }

        // GET: Obras/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var obraViewModel = await ObterObra(id);
            if (obraViewModel == null)
            {
                return NotFound();
            }

            return View(obraViewModel);
        }

        // GET: Obras/Create
        public async Task<IActionResult> Create()
        {
            var obraViewModel = await PopularAutores(new ObraViewModel());
            return View(obraViewModel);
        }

        // POST: Obras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ObraViewModel obraViewModel)
        {
            obraViewModel = await PopularAutores(obraViewModel);
            if (!ModelState.IsValid) return View(obraViewModel);

            await _obraService.Adicionar(_mapper.Map<Obra>(obraViewModel));

            if (!OperacaoValida()) return View(obraViewModel);

            return View(obraViewModel);
        }

        // GET: Obras/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var obraViewModel = await ObterObra(id);
            if (obraViewModel == null)
            {
                return NotFound();
            }
            return View(obraViewModel);
        }

        // POST: Obras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,AutorId,Nome,Descricao")] ObraViewModel obraViewModel)
        {
            if (id != obraViewModel.Id) return NotFound();

            var obraAtualizacao = await ObterObra(id);
            obraViewModel.Autor = obraAtualizacao.Autor;
            if (!ModelState.IsValid) return View(obraViewModel);

            obraAtualizacao.Nome = obraViewModel.Nome;
            obraAtualizacao.Descricao = obraViewModel.Descricao;
            obraAtualizacao.DataPublicacao = obraViewModel.DataPublicacao;
            obraAtualizacao.DataExposicao = obraViewModel.DataExposicao;

            await _obraService.Atualizar(_mapper.Map<Obra>(obraViewModel));

            if (!OperacaoValida()) return View(obraViewModel);

            return RedirectToAction(nameof(Index));

        }

        // GET: Obras/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var obra = await ObterObra(id);

            if (obra == null) return NotFound();

            return View(obra);
        }

        // POST: Obras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var obra = await ObterObra(id);

            if (obra == null) return NotFound();

            await _obraService.Remover(id);

            if (!OperacaoValida()) return View(obra);

            return RedirectToAction(nameof(Index));
        }

        private async Task<ObraViewModel> ObterObra(Guid id)
        {
            var obra = _mapper.Map<ObraViewModel>(await _obraRepository.ObterObraAutor(id));
            obra.Autores = _mapper.Map<IEnumerable<AutorViewModel>>(await _autorRepository.ObterTodos());
            return obra;
        }

        private async Task<ObraViewModel> PopularAutores(ObraViewModel obra)
        {
            obra.Autores = _mapper.Map<IEnumerable<AutorViewModel>>(await _autorRepository.ObterTodos());
            return obra;
        }

    }
}
