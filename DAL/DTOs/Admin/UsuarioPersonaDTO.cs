using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.DTOs.Admin
{
    public class UsuarioPersonaDTO
    {

        public string Id { set; get; }

        //Persona
        [Required(ErrorMessage = "El DNI es requerido")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "El DNI debe tener 8 caracteres.")]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "El DNI debe contener exactamente 8 números.")]
        public string NroDocumento { set; get; }

        [Required(ErrorMessage = "El Nombre es requerido")]
        public string Nombre { set; get; }

        [Required(ErrorMessage = "El Dni es requerido")]
        public string Apellido { set; get; }
        
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "La fecha de nacimiento es requerida")]
        [Display(Name = "Fecha")]
        public DateTime? FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El Cuil es requerido")]
        [StringLength(10, MinimumLength = 8, ErrorMessage = "El DNI debe tener 10 caracteres.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "El DNI debe contener exactamente 10 números.")]
        public string Cuil { get; set; }

        public string FotoBase64 { get; set; } //Base64 img

        //Usuario
        [Required(ErrorMessage = "El email es requerido")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }


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
            return FechaNacimiento == null ? "" : ((DateTime)FechaNacimiento).ToString("dd/MM/yyyy");
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
