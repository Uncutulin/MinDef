using Commons.Identity.Services;
using DAL.DTOs.Admin;
using DAL.Models.Admin;
using DAL.Models.Comunes;
using DAL.Repository.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MinDef.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace DAL.Repository
{
    public class PersonalOperacionesRepository : IPersonalOperacionesRepository
    {
        private MinDefContext _db;
        private readonly SignInService<Usuario> _signInManager;
        private readonly UserManager<Usuario> _UserManager;
        private readonly IContenedorTrabajo<PersonalOperaciones> _unitWorks;

        public PersonalOperacionesRepository(MinDefContext db, SignInService<Usuario> signInManager ,
            UserManager<Usuario> userManager)
        {
            this._UserManager = userManager;
            this._signInManager = signInManager;
            this._db = db;
        }

        public PersonalOperacionesRepository(MinDefContext db)
        {
            this._db = db;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<PersonalOperaciones> GetPersonalOperaciones()
        {
            try
            {
                return _db.PersonalOperaciones.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

        public List<PersonalOperaciones> GetPersonalOperaciones(params Expression<Func<PersonalOperaciones, object>>[] includes)
        {
            try
            {
                IQueryable<PersonalOperaciones> query = _db.PersonalOperaciones;
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
                return query.OrderByDescending(x => x.Id).ToList();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

        public PersonalOperaciones GetPersonalOperaciones(int Id, params Expression<Func<PersonalOperaciones, object>>[] includes)
        {
            try
            {
                IQueryable<PersonalOperaciones> query = _db.PersonalOperaciones.Where(x=>x.Id==Id);
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
                return query.OrderByDescending(x => x.Id).FirstOrDefault();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

        public PersonalOperaciones GetPersonalOperaciones(int persnalId)
        {
            try
            {
                return _db.PersonalOperaciones.Where(x => x.Id == persnalId).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

        public PersonalOperaciones AddPersonalOperaciones(PersonalOperaciones personal)
        {
            try
            {
                _unitWorks.Add(personal);
                _unitWorks.Save();
                return personal;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

        public PersonalOperaciones UpdatePersonalOperaciones(PersonalOperaciones personal)
        {
            try
            {
                _unitWorks.Update(personal);
                _unitWorks.Save();
                return personal;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

        public List<PersonalOperaciones> GetPersonalByOperacionId(string operacionId)
        {
            try
            {
                return _db.PersonalOperaciones.Where(x=>x.Operacion.Id==Convert.ToInt32(operacionId)).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

        public bool DeletePersonalOperaciones(int operacionId)
        {
            try
            {
                _db.PersonalOperaciones.Remove(_db.PersonalOperaciones.Where(x => x.Id == operacionId).FirstOrDefault());
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
