using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mach.Entities
{
    public class Contrato
    {
        public int Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public bool IsCombustible { get; set; }
        public bool IsTransporte { get; set; }
        public string Observaciones { get; set; }
    }
}
