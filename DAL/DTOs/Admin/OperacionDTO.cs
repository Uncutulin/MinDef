using DAL.Models.Comunes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.DTOs.Admin
{
    public class OperacionesDTO
    {
        public int Id { set; get; }
        public string Nombre { set; get; }
        public string Descripcion { set; get; }
        public string Latitud { set; get; }
        public string Longitud { set; get; }
        public virtual List<Medios> Medios { set; get; }
    }

}
