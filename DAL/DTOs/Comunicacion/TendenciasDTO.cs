using DAL.Models.Comunicacion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.DTOs.Comunicacion
{
    public class TendenciasDTO
    {
        public int Id { get; set; }
        public bool Tendencia { get; set; }
        public virtual Ministerios Ministerio { get; set; }
        public virtual Redes Red { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaActualizacion { get; set; } = DateTime.Now;
        public string RedNombre { set; get; }
        public string MinisterioNombre { set; get; }
    }

}
