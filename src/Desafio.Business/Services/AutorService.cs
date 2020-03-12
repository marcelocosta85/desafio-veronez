using Desafio.Business.Interfaces;
using Desafio.Business.Models;
using Desafio.Business.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.Business.Services
{
    public class AutorService : BaseService, IAutorService
    {
        private readonly IAutorRepository _autorRepository;
        public AutorService(IAutorRepository autorRepository,
                            INotificador notificador) : base(notificador)
        {
            _autorRepository = autorRepository;
        }
        public async Task Adicionar(Autor autor)
        {
            if (!ExecutarValidacao(new AutorValidation(), autor)) return;

            if(_autorRepository.Buscar(a => a.CPF == autor.CPF).Result.Any())
            {
                Notificar("Já existe um autor brasileiro com este CPF.");
                return;
            }
            await _autorRepository.Adicionar(autor);
        }

        public async Task Atualizar(Autor autor)
        {
            if (!ExecutarValidacao(new AutorValidation(), autor)) return;

            await _autorRepository.Atualizar(autor);
        }

        public async Task Remover(Guid id)
        {
           await _autorRepository.Remover(id);
        }
        public void Dispose()
        {
            _autorRepository?.Dispose();
        }
    }
}
