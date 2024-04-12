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
    public class IndicadoresRepository : IIndicadoresRepository
    {
        private MinDefContext _db;
        private readonly SignInService<Usuario> _signInManager;
        private readonly UserManager<Usuario> _UserManager;
        private readonly IContenedorTrabajo<IndicadoresBase> _unitWorks;

        public IndicadoresRepository(MinDefContext db, SignInService<Usuario> signInManager ,
            UserManager<Usuario> userManager)
        {
            this._UserManager = userManager;
            this._signInManager = signInManager;
            this._db = db;
        }

        public IndicadoresRepository(MinDefContext db)
        {
            this._db = db;
        }

        public List<IndicadoresBase> GetIndicadores()
        {
            try
            {
                return _db.IndicadoresBase.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

        public List<IndicadoresBase> GetIndicadoresAll()
        {
            try
            {
                List<IndicadorPorcentaje> indicadoresPorcentaje = _db.IndicadorPorcentaje.ToList();
                List<IndicadorComunicacion> indicadoresComunicacion = _db.IndicadorComunicacion.ToList();
                List<IndicadorNumero> indicadoresNumero = _db.IndicadorNumero.ToList();
                List<IndicadoresBase> indicadoresList = indicadoresPorcentaje.Cast<IndicadoresBase>()
                    .Concat(indicadoresComunicacion)
                    .Concat(indicadoresNumero)
                    .ToList();
                _db.IndicadoresBase.ToList();

                return indicadoresList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

        public List<IndicadoresBase> GetIndicadores(params Expression<Func<IndicadoresBase, object>>[] includes)
        {
            try
            {
                IQueryable<IndicadoresBase> query = _db.IndicadoresBase;
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }

                return query.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

        public IndicadoresBase GetIndicador(int indicadorId)
        {
            try
            {
                return _db.IndicadoresBase.Where(x => x.Id == indicadorId).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

        public IndicadoresBase AddIndicador(IndicadoresBase indicador)
        {
            try
            {
                _unitWorks.Add(indicador);
                _unitWorks.Save();
                return indicador;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

        public bool UpdateIndicador(IndicadoresBase indicador)
        {
            throw new NotImplementedException();
        }

        public IndicadoresBase GetIndicador(string indicadorId)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        bool IIndicadoresRepository.AddIndicador(IndicadoresBase indicador)
        {
            throw new NotImplementedException();
        }

        public List<string> GetTypeIndicadoresName()
        {
            //List<IndicadoresBase> list = GetIndicadoresAll();
            //return list.Select(indicador => indicador.GetType().BaseType.Name).Distinct().ToList();
            var list = new List<string>
            {
                "IndicadorPorcentaje",
                "IndicadorComunicacion",
                "IndicadorNumero"
            };
            return list;
        }


        public List<Type> GetTypeIndicadores()
        {
            List<IndicadoresBase> list = GetIndicadoresAll();
            return list.Select(indicador => indicador.GetType()).Distinct().ToList();
        }

        public Type GetTypeIndicador(string typeIndicadorName)
        {
            List<IndicadoresBase> list = GetIndicadoresAll();
            return list.Where(x=>x.GetType().BaseType.Name==typeIndicadorName).Select(indicador => indicador.GetType()).Distinct().FirstOrDefault();
        }

        public bool DeleteIndicador(int indicadorId)
        {
            try
            {
                _db.IndicadoresBase.Remove(_db.IndicadoresBase.Where(x => x.Id == indicadorId).FirstOrDefault());
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
