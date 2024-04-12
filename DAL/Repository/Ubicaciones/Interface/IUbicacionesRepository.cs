using DAL.DTOs.Admin;
using DAL.Models.Admin;
using DAL.Models.Comunicacion;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL.Repository.Interface
{
    public interface IUbicacionesRepository : IDisposable
    {

        /// <summary>
        /// Obtiene todas las Acción
        /// </summary>
        /// <returns></returns>
        List<Ubicaciones> GetUbicaciones();

      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        List<Ubicaciones> GetUbicaciones(params Expression<Func<Ubicaciones, object>>[] includes);

        /// <summary>
        /// Obtiene una Acción en especifico
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Ubicaciones GetUbicaciones(int UbicacionesId);

        /// <summary>
        /// Agrega una Acción
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Ubicaciones AddUbicaciones(Ubicaciones ubicaciones);

        /// <summary>
        /// Actualiza la Acción
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Ubicaciones UpdateUbicaciones(Ubicaciones ubicaciones);       
    }
}