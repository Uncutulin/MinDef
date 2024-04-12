using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models.Admin
{
    public class IndicadoresBase
    {
        public int Id { get; set; }
        public DateTime FechaActualizacion { get; set; } = DateTime.Now;
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public int Orden { get; set; }
        public string Icono { get; set; }
        public string PrimerSubTitulo { get; set; }
        public string Color { get; set; }
    }

    public class IndicadorPorcentaje : IndicadoresBase
    {
        public string Porcentaje { get; set; }
        public bool IndicarTendencia { get; set; }
        public int ValorAnteriorTendencia { get; set; }
    }
    public class IndicadorComunicacion : IndicadoresBase
    {       
        public string SegundoSubTituto { get; set; }
        public string PrimerValor { get; set; }
        public string SegundoValor { get; set; }
    }

    public class IndicadorNumero : IndicadoresBase
    {
        public string Numero { get; set; }
    }

   

}
