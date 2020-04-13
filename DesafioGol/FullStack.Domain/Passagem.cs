using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStack.Domain.Model
{
    public class Passagem
    {
        public int PassagemId {get; set;}

        public string Nome { get; set; }

        public string Destino { get; set; }

        public string Origem { get; set; }

        public string DataPartida { get; set; }

        public string HoraPartida { get; set; }
    }
}
