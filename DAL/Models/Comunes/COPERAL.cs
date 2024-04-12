using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models.Comunes
{
    public class Fuerzas
    {
        public int Id {set;get;}
        public string Nombre {set;get;}
        public string Codigo {set;get;}
        public string Logo {set;get;}
        public string Activo {set;get; }
        public string Orden {set;get; }
        public DateTime FechaActualizacion { get; set; } = DateTime.Now;
    }

    public class TipoMedios
    {
        public int Id { set; get; }
        public string Nombre { set; get; }
        public string Descripcion { set; get; }
        public string Codigo { set; get; }
        public string Logo { set; get; }
        public string Orden { set; get; }
        public bool Activo { set; get; } = true;
        public DateTime FechaActualizacion { get; set; } = DateTime.Now;
    }

    public class Medios
    {
        public int Id { set; get; }
        public string Nombre { set; get; }
        public string Finalidad { set; get; }
        public int Cantidad { set; get; }
        public virtual Fuerzas Fuerza { set; get; }
        public virtual TipoMedios TipoMedios { set; get; }
        public virtual Operaciones Operacion { set; get; }
        public bool Activo { set; get; } = true;
        public DateTime FechaActualizacion { get; set; } = DateTime.Now;
    }

    public class Operaciones
    {
        public int Id { set; get; }
        public string Nombre { set; get; }
        public string Descripcion { set; get; }
        public string Latitud { set; get; }
        public string Longitud { set; get; }
        public virtual List<Medios> Medios { set; get; }
        public virtual List<PersonalOperaciones> Personal { set; get; }
        public bool Activo { set; get; } = true;
        public string Color { set; get; }
        public DateTime FechaActualizacion { get; set; } = DateTime.Now;
    }

    public class PersonalOperaciones
    {
        public int Id { set; get; }
        public virtual Fuerzas Fuerza { set; get; }
        public virtual Operaciones Operacion { set; get; }
        public int Cantidad { set; get; }
        public bool Activo { set; get; } = true;
        public DateTime FechaActualizacion { get; set; } = DateTime.Now;
    }
}
