using DAL.DTOs.Admin;
using DAL.Models.Admin;
using DAL.Models.Comunes;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL.Repository.Interface
{
    public interface IOperacionesRepository : IDisposable
    {

        /// <summary>
        /// Obtiene todas las Operaciones
        /// </summary>
        /// <returns></returns>
        List<Operaciones> GetOperaciones();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        List<Operaciones> GetOperaciones(params Expression<Func<Operaciones, object>>[] includes);

        /// <summary>
        /// Obtiene una Operación en especifico
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Operaciones GetOperaciones(int operacionId);

        /// <summary>
        /// Agrega una Operación
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Operaciones AddOperaciones(Operaciones operacion);

        /// <summary>
        /// Actualiza la Operación
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Operaciones UpdateOperaciones(Operaciones operacion);     
        
        /// <summary>
        /// Elimina la Operación
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        bool DeleteOperaciones(int operacionId);       
    }
}