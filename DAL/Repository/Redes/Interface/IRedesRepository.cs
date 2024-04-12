using DAL.DTOs.Admin;
using DAL.Models.Admin;
using DAL.Models.Comunicacion;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL.Repository.Interface
{
    public interface IRedesRepository : IDisposable
    {

        /// <summary>
        /// Obtiene todas las Acción
        /// </summary>
        /// <returns></returns>
        List<Redes> GetRedes();

      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        List<Redes> GetRedes(params Expression<Func<Redes, object>>[] includes);

        /// <summary>
        /// Obtiene una Acción en especifico
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Redes GetRedes(int redId);

        /// <summary>
        /// Agrega una Acción
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Redes AddRedes(Redes red);

        /// <summary>
        /// Actualiza la Acción
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Redes UpdateRedes(Redes red);       
    }
}