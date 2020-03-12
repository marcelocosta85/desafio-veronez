using Desafio.Business.Notificacoes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Business.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificaoes();
        void Handle(Notificacao notificacao);
    }
}
