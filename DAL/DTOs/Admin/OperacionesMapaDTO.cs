using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DTOs.Admin
{
    public class OperacionesMapaDTO
    {
        public string Nombre { set; get; }
        public string Descripcion { set; get; }
        public string Latitud { set; get; }
        public string Longitud { set; get; }
        public string Color { set; get; }
    }
}
