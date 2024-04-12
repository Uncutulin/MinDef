using DAL.Models.Comunes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.DTOs.Admin
{
    public class MediosDTO
    {
        public int Id { set; get; }
        public string Nombre { set; get; }
        public string Finalidad { set; get; }
        public int Cantidad { set; get; }
        public virtual Fuerzas Fuerza { set; get; }
        public virtual TipoMedios TipoMedios { set; get; }
        public int OperacionId { set; get; }
        public bool Activo { set; get; } = true;
        public string FuerzaNombre { set; get; }
        public string TipoNombre  { set; get; }
        public DateTime FechaActualizacion { get; set; } = DateTime.Now;
    }

}
