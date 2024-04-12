using DAL.Models.Comunes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.DTOs.Admin
{
    public class TipoMediosDTO
    {
        public int Id { set; get; }
        public string Nombre { set; get; }
        public string Descripcion { set; get; }
        public string Codigo { set; get; }
        public string Logo { set; get; }
        public string Orden { set; get; }
    }
}
