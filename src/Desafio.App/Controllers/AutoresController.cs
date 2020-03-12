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
    public class AutoresController : BaseController
    {
        private readonly IAutorRepository _autorRepository;
        private readonly IAutorService _autorService;
        private readonly IMapper _mapper;
        public AutoresController(IAutorRepository autorRepository,
                                 IAutorService autorService,
                                 IMapper mapper,
                                 INotificador notificador) : base(notificador)
        {
            _autorRepository = autorRepository;
            _autorService = autorService;
            _mapper = mapper;
        }
        
        // GET: Autores
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<AutorViewModel>>(await _autorRepository.ObterTodos()));
        }

        // GET: Autores/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var autorViewModel = await ObterPorId(id);
            if (autorViewModel == null)
            {
                return NotFound();
            }

            return View(autorViewModel);
        }

        // GET: Autores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Autores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AutorViewModel autorViewModel)
        {
            if (!ModelState.IsValid) return View(autorViewModel);

            var autor = _mapper.Map<Autor>(autorViewModel);
            await _autorService.Adicionar(autor);

            if (!OperacaoValida()) return View(autorViewModel);
            
            return RedirectToAction(nameof(Index));
            
        }

        // GET: Autores/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var autorViewModel = _mapper.Map<AutorViewModel>(await _autorRepository.ObterPorId(id));
            if (autorViewModel == null)
            {
                return NotFound();
            }
            return View(autorViewModel);
        }

        // POST: Autores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, AutorViewModel autorViewModel)
        {
            if (id != autorViewModel.Id) return NotFound();
            

            if (!ModelState.IsValid) return View(await ObterPorId(id));

            var autor = _mapper.Map<Autor>(autorViewModel);
            await _autorService.Atualizar(autor);


            return RedirectToAction(nameof(Index));
            
        }

        // GET: Autores/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var autorViewModel = await ObterPorId(id);
            if (autorViewModel == null)
            {
                return NotFound();
            }

            return View(autorViewModel);
        }

        // POST: Autores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var autor = await ObterPorId(id);
            
            if (autor == null) return NotFound();

            await _autorService.Remover(id);

            if (!OperacaoValida()) return View(autor);

            return RedirectToAction(nameof(Index));
        }

        private async Task<AutorViewModel> ObterPorId(Guid id)
        {
            return _mapper.Map<AutorViewModel>(await _autorRepository.ObterPorId(id));
        }


    }
}
