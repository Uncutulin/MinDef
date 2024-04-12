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
    public class TipoMediosRepository : ITipoMediosRepository
    {
        private MinDefContext _db;
        private readonly SignInService<Usuario> _signInManager;
        private readonly UserManager<Usuario> _UserManager;
        private readonly IContenedorTrabajo<TipoMedios> _unitWorks;

        public TipoMediosRepository(MinDefContext db, SignInService<Usuario> signInManager ,
            UserManager<Usuario> userManager)
        {
            this._UserManager = userManager;
            this._signInManager = signInManager;
            this._db = db;
        }

        public TipoMediosRepository(MinDefContext db)
        {
            this._db = db;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<TipoMedios> GetTipoMedios()
        {
            try
            {
                return _db.TipoMedios.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

        public List<TipoMedios> GetTipoMedios(params Expression<Func<TipoMedios, object>>[] includes)
        {
            try
            {
                IQueryable<TipoMedios> query = _db.TipoMedios;
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

        public TipoMedios GetTipoMedios(int tipoMediosId)
        {
            try
            {
                return _db.TipoMedios.Where(x => x.Id == tipoMediosId).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

        public TipoMedios AddTipoMedios(TipoMedios accion)
        {
            try
            {
                _unitWorks.Add(accion);
                _unitWorks.Save();
                return accion;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

        public TipoMedios UpdateTipoMedios(TipoMedios accion)
        {
            try
            {
                _unitWorks.Update(accion);
                _unitWorks.Save();
                return accion;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }
    }
}
