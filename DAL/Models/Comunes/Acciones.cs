using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models.Admin
{
    public class Acciones
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public string Porcentaje { get; set; }
        public virtual Prioridades Prioridad { get; set; }
        public virtual OrganismoOrigen OrganismoOrigen { get; set; }
        public DateTime FechaActualizacion { get; set; } = DateTime.Now;
    }
}
