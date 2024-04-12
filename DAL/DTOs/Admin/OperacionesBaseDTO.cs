using DAL.Models.Comunes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DTOs.Admin
{
    public class OperacionesBaseDTO
    {
        public int Id { set; get; }
        public string Nombre { set; get; }
        public string Descripcion { set; get; }
        public string Latitud { set; get; }
        public string Longitud { set; get; }
        public List<Medios> Medios { set; get; }
        public List<IconoTipoMedioDTO> IconosTipoMedios { set; get; }
        public List<PersonalOperaciones> Personal { set; get; }
        public List<string> tipoMedios { set; get; }
        public bool Activo { set; get; } = true;
        public string Color { set; get; }
        public DateTime FechaActualizacion { get; set; } = DateTime.Now;
    }

    public class IconoTipoMedioDTO
    {
        public string Nombre { get; set; }
        public string Icono { get; set; } // Asumiendo que el logo es una cadena (URL o path)
    }
}
