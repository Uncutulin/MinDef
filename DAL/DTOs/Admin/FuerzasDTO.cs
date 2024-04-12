using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.DTOs.Admin
{
    public class FuerzasDTO
    {
        public int Id { set; get; }
        public string Nombre { set; get; }
        public string Codigo { set; get; }
        public string Logo { set; get; }
        public string Activo { set; get; }
        public string Orden { set; get; }
    }

}
