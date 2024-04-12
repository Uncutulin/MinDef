using DAL.Models.Comunicacion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.DTOs.Comunicacion
{
    public class MinisteriosDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Logo { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaActualizacion { get; set; } = DateTime.Now;
    }

}
