using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalBackend.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string DocumentoIdentidad { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombres { get; set; }



    }
}
