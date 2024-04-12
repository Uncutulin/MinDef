using DAL.DTOs.Admin;
using DAL.Models.Admin;
using DAL.Models.Comunicacion;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL.Repository.Interface
{
    public interface ITipoMedicionesRepository : IDisposable
    {

        /// <summary>
        /// Obtiene todas las Acción
        /// </summary>
        /// <returns></returns>
        List<TipoMediciones> GetTipoMediciones();
   
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        List<TipoMediciones> GetTipoMediciones(params Expression<Func<TipoMediciones, object>>[] includes);

        /// <summary>
        /// Obtiene una Acción en especifico
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        TipoMediciones GetTipoMediciones(int tipoMedicionesId);

        /// <summary>
        /// Agrega una Acción
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        TipoMediciones AddTipoMediciones(TipoMediciones tipoMediciones);

        /// <summary>
        /// Actualiza la Acción
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        TipoMediciones UpdateTipoMediciones(TipoMediciones tipoMediciones);       
    }
}