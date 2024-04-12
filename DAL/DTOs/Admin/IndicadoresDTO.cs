using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.DTOs.Admin
{
    public class IndicadoresDTO
    {
        public int Id { set; get; }
        public string Titulo { set; get; }
        public string Descripcion { set; get; }        
        public string Discriminador { set; get; }
        public string Color { set; get; }
        public string Porcentaje { set; get; }
        public string PrimerSubTitulo { get; set; }
        public string SegundoSubTituto { get; set; }
        public string PrimerValor { get; set; }
        public string SegundoValor { get; set; }
        public string Numero { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public int Orden { get; set; }
        public string Icono { get; set; }
        public bool Activo { get; set; }
        public bool IndicarTendencia { get; set; }
        public int ValorAnteriorTendencia { get; set; }

    }
}
