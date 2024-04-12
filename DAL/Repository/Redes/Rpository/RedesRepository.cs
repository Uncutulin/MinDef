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
    public class RedesRepository : IRedesRepository
    {
        private MinDefContext _db;
        private readonly SignInService<Usuario> _signInManager;
        private readonly UserManager<Usuario> _UserManager;
        private readonly IContenedorTrabajo<Redes> _unitWorks;

        public RedesRepository(MinDefContext db, SignInService<Usuario> signInManager ,
            UserManager<Usuario> userManager)
        {
            this._UserManager = userManager;
            this._signInManager = signInManager;
            this._db = db;
        }

        public RedesRepository(MinDefContext db)
        {
            this._db = db;
        }

        public List<Redes> GetRedes()
        {
            try
            {
                return _db.Redes.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

      
        public List<Redes> GetRedes(params Expression<Func<Redes, object>>[] includes)
        {
            try
            {
                IQueryable<Redes> query = _db.Redes;
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

        public Redes GetRedes(int redesId)
        {
            try
            {
                return _db.Redes.Where(x => x.Id == redesId).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

        public Redes AddRedes(Redes redes)
        {
            try
            {
                _unitWorks.Add(redes);
                _unitWorks.Save();
                return redes;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

        public Redes UpdateRedes(Redes redes)
        {
            try
            {
                _unitWorks.Update(redes);
                _unitWorks.Save();
                return redes;
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
