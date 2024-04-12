using Commons.Identity.Services;
using DAL.DTOs.Admin;
using DAL.Models.Admin;
using DAL.Models.Comunicacion;
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
    public class TipoMedicionesRepository : ITipoMedicionesRepository
    {
        private MinDefContext _db;
        private readonly SignInService<Usuario> _signInManager;
        private readonly UserManager<Usuario> _UserManager;
        private readonly IContenedorTrabajo<TipoMediciones> _unitWorks;

        public TipoMedicionesRepository(MinDefContext db, SignInService<Usuario> signInManager ,
            UserManager<Usuario> userManager)
        {
            this._UserManager = userManager;
            this._signInManager = signInManager;
            this._db = db;
        }

        public TipoMedicionesRepository(MinDefContext db)
        {
            this._db = db;
        }

        public List<TipoMediciones> GetTipoMediciones()
        {
            try
            {
                return _db.TipoMediciones.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

      
        public List<TipoMediciones> GetTipoMediciones(params Expression<Func<TipoMediciones, object>>[] includes)
        {
            try
            {
                IQueryable<TipoMediciones> query = _db.TipoMediciones;
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
       
        public TipoMediciones GetTipoMediciones(int tipoMedicionesId)
        {
            try
            {
                return _db.TipoMediciones.Where(x => x.Id == tipoMedicionesId).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

        public TipoMediciones AddTipoMediciones(TipoMediciones tipoMediciones)
        {
            try
            {
                _unitWorks.Add(tipoMediciones);
                _unitWorks.Save();
                return tipoMediciones;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

        public TipoMediciones UpdateTipoMediciones(TipoMediciones tipoMediciones)
        {
            try
            {
                _unitWorks.Update(tipoMediciones);
                _unitWorks.Save();
                return tipoMediciones;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
