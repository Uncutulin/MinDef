using DAL.DTOs.Admin;
using DAL.Models.Admin;
using DAL.Models.Comunes;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL.Repository.Interface
{
    public interface IFuerzasRepository : IDisposable
    {

        /// <summary>
        /// Obtiene todas las Fuerzas
        /// </summary>
        /// <returns></returns>
        List<Fuerzas> GetFuerzas();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        List<Fuerzas> GetFuerzas(params Expression<Func<Fuerzas, object>>[] includes);

        /// <summary>
        /// Obtiene una Acción en especifico
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Fuerzas GetFuerzas(int fuerzaId);

        /// <summary>
        /// Agrega una Acción
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Fuerzas AddFuerzas(Fuerzas fuerza);

        /// <summary>
        /// Actualiza la Acción
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Fuerzas UpdateFuerzas(Fuerzas fuerza);       
    }
}