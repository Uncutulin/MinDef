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
    public class MediosRepository : IMediosRepository
    {
        private MinDefContext _db;
        private readonly SignInService<Usuario> _signInManager;
        private readonly UserManager<Usuario> _UserManager;
        private readonly IContenedorTrabajo<Medios> _unitWorks;

        public MediosRepository(MinDefContext db, SignInService<Usuario> signInManager ,
            UserManager<Usuario> userManager)
        {
            this._UserManager = userManager;
            this._signInManager = signInManager;
            this._db = db;
        }

        public MediosRepository(MinDefContext db)
        {
            this._db = db;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<Medios> GetMedios()
        {
            try
            {
                return _db.Medios.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

        public List<Medios> GetMedios(params Expression<Func<Medios, object>>[] includes)
        {
            try
            {
                IQueryable<Medios> query = _db.Medios;
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

        public Medios GetMedios(int Id, params Expression<Func<Medios, object>>[] includes)
        {
            try
            {
                IQueryable<Medios> query = _db.Medios.Where(x=>x.Id==Id);
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

        public Medios GetMedios(int medioId)
        {
            try
            {
                return _db.Medios.Where(x => x.Id == medioId).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

        public Medios AddMedios(Medios medio)
        {
            try
            {
                _unitWorks.Add(medio);
                _unitWorks.Save();
                return medio;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

        public Medios UpdateMedios(Medios medio)
        {
            try
            {
                _unitWorks.Update(medio);
                _unitWorks.Save();
                return medio;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

        public List<Medios> GetMediosByOperacionId(string operacionId)
        {
            try
            {
                return _db.Medios.Where(x=>x.Operacion.Id==Convert.ToInt32(operacionId)).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

        public bool DeleteMedio(int medioId)
        {
            try
            {
                _db.Medios.Remove(_db.Medios.Where(x => x.Id == medioId).FirstOrDefault());
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Medios> GetMediosByOperacionIdAndTipoMedio(string operacionId, string tipoMedioId)
        {
            try
            {
                return _db.Medios.Where(x => x.Operacion.Id == Convert.ToInt32(operacionId) && x.TipoMedios.Nombre==tipoMedioId).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }
    }
}
