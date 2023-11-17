﻿using AgendaMed.Business.Genericos;
using AgendaMedWebApp.Business.Genericos;

namespace AgendaMedWebApp.Models
{
    public class EspecialidadeModel
    {
        public long Id { get; set; }
        public string NomeEspecialidade { get; set; }
        
        public EspecialidadeModel()
        {

        }

        public EspecialidadeModel(Especialidade especialidade)
        {
            Id = especialidade.Id;
            NomeEspecialidade = especialidade.NomeEspecialidade;
        }

        public Pessoa GetEspecialidade()
        {
            return new Pessoa()
            {
                Id = Id,
                Nome = NomeEspecialidade,
            };
        }
    }
}
