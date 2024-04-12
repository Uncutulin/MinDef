using DAL.DTOs.Admin;
using DAL.Models.Admin;
using DAL.Models.Comunes;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL.Repository.Interface
{
    public interface ITipoMediosRepository : IDisposable
    {

        /// <summary>
        /// Obtiene todos los Tipo Medios
        /// </summary>
        /// <returns></returns>
        List<TipoMedios> GetTipoMedios();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        List<TipoMedios> GetTipoMedios(params Expression<Func<TipoMedios, object>>[] includes);

        /// <summary>
        /// Obtiene un Tipo Medios en especifico
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        TipoMedios GetTipoMedios(int tipoMediosId);

        /// <summary>
        /// Agrega un Tipo Medios
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        TipoMedios AddTipoMedios(TipoMedios accion);

        /// <summary>
        /// Actualiza el Tipo Medios
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        TipoMedios UpdateTipoMedios(TipoMedios accion);       
    }
}