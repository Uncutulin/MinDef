using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models.Admin
{
    public class OrganismoOrigen
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Abreviatura { get; set; }
        public string Codigo { get; set; }
        public bool Activo { get; set; }
        public int Orden { get; set; }
        public DateTime FechaActualizacion { get; set; } = DateTime.Now;
    }
}
