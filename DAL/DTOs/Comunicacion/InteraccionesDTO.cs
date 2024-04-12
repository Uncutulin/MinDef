using DAL.Models.Comunicacion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.DTOs.Comunicacion
{
    public class InteraccionesDTO
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public virtual Redes Red { get; set; }
        public virtual Ubicaciones Ubicacion { get; set; }
        public int Numero { get; set; }
        public virtual TipoMediciones TipoMedicion { get; set; }
        public DateTime FechaActualizacion { get; set; } = DateTime.Now;
        public string RedNombre { set; get; }
        public string UbicacionNombre { set; get; }
        public string TipoMedicionNombre { set; get; }
    }

}
