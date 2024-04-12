using DAL.DTOs.Admin;
using DAL.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL.Repository.Interface
{
    public interface IAccionesRepository : IDisposable
    {

        /// <summary>
        /// Obtiene todas las Acción
        /// </summary>
        /// <returns></returns>
        List<Acciones> GetAcciones();

        /// <summary>
        /// Obtiene todas las Acción de un Organismo por el Id
        /// </summary>
        /// <returns></returns>
        List<Acciones> GetAccionesOrganismobyId(int id);

        /// <summary>
        /// Obtiene todas las Acción de un Organismo por el Codigo
        /// </summary>
        /// <returns></returns>
        List<Acciones> GetAccionesOrganismobyCod(string cod);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        List<Acciones> GetAcciones(params Expression<Func<Acciones, object>>[] includes);

        /// <summary>
        /// Obtiene una Acción en especifico
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Acciones GetAcciones(int accionId);

        /// <summary>
        /// Agrega una Acción
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Acciones AddAcciones(Acciones accion);

        /// <summary>
        /// Actualiza la Acción
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Acciones UpdateAcciones(Acciones accion);       
    }
}