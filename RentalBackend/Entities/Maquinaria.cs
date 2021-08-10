using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mach.Entities
{
    public class Maquinaria
    {
        public int Id { get; set; }
        public string Serie { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Descripcion { get; set; }
        public string Observaciones { get; set; }
        public DateTime FechaCompra { get; set; }
        public int HorasAlquilerDefecto { get; set; }
    }
}
