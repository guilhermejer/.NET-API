using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interfusao.Teste.Api.Models
{
    public class Analise
    {
        public int Id { get; set; }

        public string DataSolicitacao { get; set; }

        public string DataTarget { get; set; }

        public bool AnaliseConcluida { get; set; }

        public string DataConclusao { get; set; }

        public string Resultado { get; set; }
    }
}
