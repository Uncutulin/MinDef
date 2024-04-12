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
    public class FuerzasRepository : IFuerzasRepository
    {
        private MinDefContext _db;
        private readonly SignInService<Usuario> _signInManager;
        private readonly UserManager<Usuario> _UserManager;
        private readonly IContenedorTrabajo<Fuerzas> _unitWorks;

        public FuerzasRepository(MinDefContext db, SignInService<Usuario> signInManager ,
            UserManager<Usuario> userManager)
        {
            this._UserManager = userManager;
            this._signInManager = signInManager;
            this._db = db;
        }

        public FuerzasRepository(MinDefContext db)
        {
            this._db = db;
        }
       
        public List<Fuerzas> GetFuerzas()
        {
            try
            {
                return _db.Fuerzas.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

        public List<Fuerzas> GetFuerzas(params Expression<Func<Fuerzas, object>>[] includes)
        {
            try
            {
                IQueryable<Fuerzas> query = _db.Fuerzas;
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

        public Fuerzas GetFuerzas(int fuerzaId)
        {
            try
            {
                return _db.Fuerzas.Where(x => x.Id == fuerzaId).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

        public Fuerzas AddFuerzas(Fuerzas fuerza)
        {
            try
            {
                _unitWorks.Add(fuerza);
                _unitWorks.Save();
                return fuerza;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

        public Fuerzas UpdateFuerzas(Fuerzas fuerza)
        {
            try
            {
                _unitWorks.Update(fuerza);
                _unitWorks.Save();
                return fuerza;
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
