﻿using Desafio.Business.Interfaces;
using Desafio.Business.Models;
using Desafio.Business.Notificacoes;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Desafio.Business.Services
{
    public abstract class BaseService
    {
        private readonly INotificador _notificador;
        public BaseService(INotificador notificador)
        {
            _notificador = notificador;
        }
        protected void Notificar(FluentValidation.Results.ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }

        protected void Notificar(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }

        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validacao.Validate(entidade);
            if (validator.IsValid) return true;

            Notificar(validator);
            return false;
        }

    }
}
