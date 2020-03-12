using Desafio.Business.Interfaces;
using Desafio.Business.Models;
using Desafio.Business.Validations;
using System;
using System.Threading.Tasks;

namespace Desafio.Business.Services
{
    public class ObraService : BaseService, IObraService
    {
        private readonly IObraRepository _obraRepository;
        public ObraService(IObraRepository obraRepository,
                           INotificador notificador) : base(notificador)
        {
            _obraRepository = obraRepository;
        }
        public async Task Adicionar(Obra obra)
        {
            if (!ExecutarValidacao(new ObraValidation(), obra)) return;

            await _obraRepository.Adicionar(obra);
        }

        public async Task Atualizar(Obra obra)
        {
            if (!ExecutarValidacao(new ObraValidation(), obra)) return;

            await _obraRepository.Atualizar(obra);
        }

        public async Task Remover(Guid id)
        {
            await _obraRepository.Remover(id);
        }
        public void Dispose()
        {
            _obraRepository?.Dispose();
        }
    }
}
