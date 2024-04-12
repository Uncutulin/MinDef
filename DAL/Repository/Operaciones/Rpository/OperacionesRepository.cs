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
    public class OperacionesRepository : IOperacionesRepository
    {
        private MinDefContext _db;
        private readonly SignInService<Usuario> _signInManager;
        private readonly UserManager<Usuario> _UserManager;
        private readonly IContenedorTrabajo<Operaciones> _unitWorks;

        public OperacionesRepository(MinDefContext db, SignInService<Usuario> signInManager ,
            UserManager<Usuario> userManager)
        {
            this._UserManager = userManager;
            this._signInManager = signInManager;
            this._db = db;
        }

        public OperacionesRepository(MinDefContext db)
        {
            this._db = db;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<Operaciones> GetOperaciones()
        {
            try
            {
                return _db.Operaciones.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

        public List<Operaciones> GetOperaciones(params Expression<Func<Operaciones, object>>[] includes)
        {
            try
            {
                IQueryable<Operaciones> query = _db.Operaciones;
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

        public Operaciones GetOperaciones(int operacionId)
        {
            try
            {
                return _db.Operaciones.Where(x => x.Id == operacionId).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

        public Operaciones AddOperaciones(Operaciones operacion)
        {
            try
            {
                _unitWorks.Add(operacion);
                _unitWorks.Save();
                return operacion;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

        public Operaciones UpdateOperaciones(Operaciones operacion)
        {
            try
            {
                _unitWorks.Update(operacion);
                _unitWorks.Save();
                return operacion;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

        public bool DeleteOperaciones(int operacionId)
        {
            try
            {
                List<Medios> medios = _db.Medios.Where(x => x.Operacion.Id == operacionId).ToList();
                Operaciones operacion = _db.Operaciones.Where(x => x.Id == operacionId).FirstOrDefault();
                _db.Medios.RemoveRange(medios);
                _db.Operaciones.Remove(operacion);
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
