using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Commons.Identity;

namespace DAL.Models.Admin
{
    public class Usuario : CommonsUser
    {
        public virtual Persona Persona { get; set; }

        public override string GetFirstName()
        {
            if (Persona is null)
            {
                return "Nombres";
            }
            return Persona?.Nombre;
        }

        public override string GetLastName()
        {
            if (Persona is null)
            {
                return "Nombre completo";
            }
            return Persona?.Apellido;
        }

        public override string GetMiddleName()
        {
            if (Persona is null)
            {
                return "";
            }
            return "";
        }

        public override List<IWorkSpace> GetRelatedIWorkSpaces()
        {
            return new List<IWorkSpace>();
        }

        public override string GetRoleString()
        {
            return "Usuario";
        }
        public string GetFullName()
        {
            return (GetFirstName() + " " + GetMiddleName() + " " + GetLastName()).Trim();
        }

    }
}
