using DAL.DTOs.Admin;
using DAL.Models.Admin;
using DAL.Models.Comunicacion;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL.Repository.Interface
{
    public interface ITendenciasRepository : IDisposable
    {

        /// <summary>
        /// Obtiene todas las Acción
        /// </summary>
        /// <returns></returns>
        List<Tendencias> GetTendencias();

      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        List<Tendencias> GetTendencias(params Expression<Func<Tendencias, object>>[] includes);

        /// <summary>
        /// Obtiene una Acción en especifico
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Tendencias GetTendencias(int tendenciasId);

        /// <summary>
        /// Agrega una Acción
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Tendencias AddTendencias(Tendencias tendencias);

        /// <summary>
        /// Actualiza la Acción
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Tendencias UpdateTendencias(Tendencias tendencias);       
    }
}