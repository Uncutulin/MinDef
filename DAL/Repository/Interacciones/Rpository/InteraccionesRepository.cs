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
    public class InteraccionesRepository : IInteraccionesRepository
    {
        private MinDefContext _db;
        private readonly SignInService<Usuario> _signInManager;
        private readonly UserManager<Usuario> _UserManager;
        private readonly IContenedorTrabajo<Interacciones> _unitWorks;

        public InteraccionesRepository(MinDefContext db, SignInService<Usuario> signInManager ,
            UserManager<Usuario> userManager)
        {
            this._UserManager = userManager;
            this._signInManager = signInManager;
            this._db = db;
        }

        public InteraccionesRepository(MinDefContext db)
        {
            this._db = db;
        }

        public List<Interacciones> GetInteracciones()
        {
            try
            {
                return _db.Interacciones.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

      
        public List<Interacciones> GetInteracciones(params Expression<Func<Interacciones, object>>[] includes)
        {
            try
            {
                IQueryable<Interacciones> query = _db.Interacciones;
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

        public Interacciones GetInteracciones(int interaccionesId)
        {
            try
            {
                return _db.Interacciones.Where(x => x.Id == interaccionesId).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

        public Interacciones AddInteracciones(Interacciones interacciones)
        {
            try
            {
                _unitWorks.Add(interacciones);
                _unitWorks.Save();
                return interacciones;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

        public Interacciones UpdateInteracciones(Interacciones interacciones)
        {
            try
            {
                _unitWorks.Update(interacciones);
                _unitWorks.Save();
                return interacciones;
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
