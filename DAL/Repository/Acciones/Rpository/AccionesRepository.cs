using Commons.Identity.Services;
using DAL.DTOs.Admin;
using DAL.Models.Admin;
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
    public class AccionesRepository : IAccionesRepository
    {
        private MinDefContext _db;
        private readonly SignInService<Usuario> _signInManager;
        private readonly UserManager<Usuario> _UserManager;
        private readonly IContenedorTrabajo<Acciones> _unitWorks;

        public AccionesRepository(MinDefContext db, SignInService<Usuario> signInManager ,
            UserManager<Usuario> userManager)
        {
            this._UserManager = userManager;
            this._signInManager = signInManager;
            this._db = db;
        }

        public AccionesRepository(MinDefContext db)
        {
            this._db = db;
        }

        public List<Acciones> GetAcciones()
        {
            try
            {
                return _db.Acciones.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

        public List<Acciones> GetAccionesOrganismobyId(int id)
        {
            try
            {
                return _db.Acciones.Where(x => x.OrganismoOrigen.Id == id).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

        public List<Acciones> GetAccionesOrganismobyCod(string cod)
        {
            try
            {
                return _db.Acciones.Where(x => x.OrganismoOrigen.Codigo == cod).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

        public List<Acciones> GetAcciones(params Expression<Func<Acciones, object>>[] includes)
        {
            try
            {
                IQueryable<Acciones> query = _db.Acciones;
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

        public Acciones GetAcciones(int accionId)
        {
            try
            {
                return _db.Acciones.Where(x => x.Id == accionId).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

        public Acciones AddAcciones(Acciones accion)
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

        public Acciones UpdateAcciones(Acciones accion)
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

        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
