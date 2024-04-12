using System;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models.Admin
{
    public class Persona
    {
        public int Id { get; set; }
        public DateTime FechaActualizacion { get; set; } = DateTime.Now;
        public string NroDocumento { get; set; }
        [Required(ErrorMessage = "Ingrese el nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Ingrese el apellido")]
        public string Apellido { get; set; }

        public DateTime? FechaNacimiento { get; set; }
        public byte[] Foto { get; set; }
        public string Cuil { get; set; }

        public int GetEdad()
        {
            try
            {
                var today = DateTime.Today;
                var edad = today.Year - FechaNacimiento?.Year;
                if (FechaNacimiento?.Date > today.AddYears((int)-edad)) edad--;

                return (int)edad;
            }
            catch (Exception)
            {
                return 0;
            }

        }

        public string GetFechaNacimiento()
        {
            return FechaNacimiento == null ? "":((DateTime)FechaNacimiento).ToString("dd/MM/yyyy");
        }

        public string GetNombreCompleto()
        {
            return Apellido + " " + Nombre;
        }

        public string GetDocumentoCompleto()
        {
            return "DNI - " + NroDocumento;
        }

        public string GetTipoDocumento()
        {
            return "DNI";
        }

    }
}
