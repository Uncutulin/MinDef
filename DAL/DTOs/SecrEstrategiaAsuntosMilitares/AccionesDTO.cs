using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.DTOs.SecrEstrategiaAsuntosMilitares
{
    public class AccionesDTO
    {
        public int Id { set; get; }
        public string Titulo { set; get; }
        public string Descripcion { set; get; }           
        public string Porcentaje { set; get; }
        public string Proridad { set; get; }
        public int ProridadId { set; get; }
        public string ProridadColor { set; get; }
        public int OrganismoId { set; get; }
        public string OrganismoNombre { set; get; }
    }
}
