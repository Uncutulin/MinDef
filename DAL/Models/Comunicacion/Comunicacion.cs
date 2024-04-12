using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models.Comunicacion
{
   
        public class Redes
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Descripcion { get; set; }//debatible
            public string Logo { get; set; }
            public bool Activo { get; set; }
            public DateTime FechaActualizacion { get; set; } = DateTime.Now;
        }

        public class TipoMediciones
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public bool Activo { get; set; }
            public DateTime FechaActualizacion { get; set; } = DateTime.Now;
        }

        public class Ubicaciones
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Latitud { get; set; }
            public string Longitud { get; set; }
            public bool Activo { get; set; }
            public DateTime FechaActualizacion { get; set; } = DateTime.Now;
        }

        public class Interacciones
        {
            public int Id { get; set; }
            public DateTime Fecha { get; set; }
            public virtual Redes Red { get; set; }
            public virtual Ubicaciones Ubicacion { get; set; }
            public int Numero { get; set; }
            public virtual TipoMediciones TipoMedicion { get; set; }
            public DateTime FechaActualizacion { get; set; } = DateTime.Now;
        }

        public class Ministerios
           {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Logo { get; set; }
            public bool Activo { get; set; }
            public DateTime FechaActualizacion { get; set; } = DateTime.Now;
        }

        public class Tendencias
        {
            public int Id { get; set; }
            public bool Tendencia { get; set; }
            public virtual Ministerios Ministerio { get; set; }
            public virtual Redes Red { get; set; }
            public DateTime Fecha { get; set; }
            public DateTime FechaActualizacion { get; set; } = DateTime.Now;
        }
    
}
