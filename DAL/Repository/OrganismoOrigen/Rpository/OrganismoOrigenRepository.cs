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
    public class OrganismoOrigenRepository : IOrganismoOrigenRepository
    {
        private MinDefContext _db;
        private readonly SignInService<Usuario> _signInManager;
        private readonly UserManager<Usuario> _UserManager;
        private readonly IContenedorTrabajo<IndicadoresBase> _unitWorks;

        public OrganismoOrigenRepository(MinDefContext db, SignInService<Usuario> signInManager ,
            UserManager<Usuario> userManager)
        {
            this._UserManager = userManager;
            this._signInManager = signInManager;
            this._db = db;
        }

        public OrganismoOrigenRepository(MinDefContext db)
        {
            this._db = db;
        }

        public List<OrganismoOrigen> GetOrganismos()
        {
            try
            {
                return _db.OrganismoOrigen.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

        public List<OrganismoOrigen> GetOrganismos(params Expression<Func<OrganismoOrigen, object>>[] includes)
        {
            IQueryable<OrganismoOrigen> query = _db.OrganismoOrigen;
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query.ToList();
        }

        public OrganismoOrigen GetOrganismos(int organismoId)
        {
            try
            {
                return _db.OrganismoOrigen.Where(x => x.Id == organismoId).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

        

        public OrganismoOrigen GetOrganismosbyCode(string organismoCod)
        {
            try
            {
                return _db.OrganismoOrigen.Where(x => x.Codigo == organismoCod).FirstOrDefault();
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
