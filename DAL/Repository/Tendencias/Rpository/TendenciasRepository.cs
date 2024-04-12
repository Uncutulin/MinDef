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
    public class TendenciasRepository : ITendenciasRepository
    {
        private MinDefContext _db;
        private readonly SignInService<Usuario> _signInManager;
        private readonly UserManager<Usuario> _UserManager;
        private readonly IContenedorTrabajo<Tendencias> _unitWorks;

        public TendenciasRepository(MinDefContext db, SignInService<Usuario> signInManager ,
            UserManager<Usuario> userManager)
        {
            this._UserManager = userManager;
            this._signInManager = signInManager;
            this._db = db;
        }

        public TendenciasRepository(MinDefContext db)
        {
            this._db = db;
        }

        public List<Tendencias> GetTendencias()
        {
            try
            {
                return _db.Tendencias.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

      
        public List<Tendencias> GetTendencias(params Expression<Func<Tendencias, object>>[] includes)
        {
            try
            {
                IQueryable<Tendencias> query = _db.Tendencias;
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

        public Tendencias GetTendencias(int tendenciasId)
        {
            try
            {
                return _db.Tendencias.Where(x => x.Id == tendenciasId).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

        public Tendencias AddTendencias(Tendencias tendencias)
        {
            try
            {
                _unitWorks.Add(tendencias);
                _unitWorks.Save();
                return tendencias;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

        public Tendencias UpdateTendencias(Tendencias tendencias)
        {
            try
            {
                _unitWorks.Update(tendencias);
                _unitWorks.Save();
                return tendencias;
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
