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
    public class MinisteriosRepository : IMinisteriosRepository
    {
        private MinDefContext _db;
        private readonly SignInService<Usuario> _signInManager;
        private readonly UserManager<Usuario> _UserManager;
        private readonly IContenedorTrabajo<Ministerios> _unitWorks;

        public MinisteriosRepository(MinDefContext db, SignInService<Usuario> signInManager ,
            UserManager<Usuario> userManager)
        {
            this._UserManager = userManager;
            this._signInManager = signInManager;
            this._db = db;
        }

        public MinisteriosRepository(MinDefContext db)
        {
            this._db = db;
        }

        public List<Ministerios> GetMinisterios()
        {
            try
            {
                return _db.Ministerios.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

      
        public List<Ministerios> GetMinisterios(params Expression<Func<Ministerios, object>>[] includes)
        {
            try
            {
                IQueryable<Ministerios> query = _db.Ministerios;
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

        public Ministerios GetMinisterios(int ministeriosId)
        {
            try
            {
                return _db.Ministerios.Where(x => x.Id == ministeriosId).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

        public Ministerios AddMinisterios(Ministerios ministerios)
        {
            try
            {
                _unitWorks.Add(ministerios);
                _unitWorks.Save();
                return ministerios;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

        public Ministerios UpdateMinisterios(Ministerios ministerios)
        {
            try
            {
                _unitWorks.Update(ministerios);
                _unitWorks.Save();
                return ministerios;
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
