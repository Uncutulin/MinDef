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
    public class UbicacionesRepository : IUbicacionesRepository
    {
        private MinDefContext _db;
        private readonly SignInService<Usuario> _signInManager;
        private readonly UserManager<Usuario> _UserManager;
        private readonly IContenedorTrabajo<Ubicaciones> _unitWorks;

        public UbicacionesRepository(MinDefContext db, SignInService<Usuario> signInManager ,
            UserManager<Usuario> userManager)
        {
            this._UserManager = userManager;
            this._signInManager = signInManager;
            this._db = db;
        }

        public UbicacionesRepository(MinDefContext db)
        {
            this._db = db;
        }

        public List<Ubicaciones> GetUbicaciones()
        {
            try
            {
                return _db.Ubicaciones.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

      
        public List<Ubicaciones> GetUbicaciones(params Expression<Func<Ubicaciones, object>>[] includes)
        {
            try
            {
                IQueryable<Ubicaciones> query = _db.Ubicaciones;
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

        public Ubicaciones GetUbicaciones(int ubicacionesId)
        {
            try
            {
                return _db.Ubicaciones.Where(x => x.Id == ubicacionesId).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

        public Ubicaciones AddUbicaciones(Ubicaciones ubicaciones)
        {
            try
            {
                _unitWorks.Add(ubicaciones);
                _unitWorks.Save();
                return ubicaciones;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

        public Ubicaciones UpdateUbicaciones(Ubicaciones ubicaciones)
        {
            try
            {
                _unitWorks.Update(ubicaciones);
                _unitWorks.Save();
                return ubicaciones;
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
