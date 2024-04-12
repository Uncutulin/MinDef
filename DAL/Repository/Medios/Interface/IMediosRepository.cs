using DAL.DTOs.Admin;
using DAL.Models.Admin;
using DAL.Models.Comunes;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL.Repository.Interface
{
    public interface IMediosRepository : IDisposable
    {

        /// <summary>
        /// Obtiene todos los Medios
        /// </summary>
        /// <returns></returns>
        List<Medios> GetMedios();

        /// <summary>
        /// Obtiene todos los Medios de una Operación especifica
        /// </summary>
        /// <returns></returns>
        List<Medios> GetMediosByOperacionId(string Id);

        /// <summary>
        /// Obtiene todos los Medios de una Operación y tipo de Medio especifico
        /// </summary>
        /// <returns></returns>
        List<Medios> GetMediosByOperacionIdAndTipoMedio(string operacionId, string tipoMedioId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        List<Medios> GetMedios(params Expression<Func<Medios, object>>[] includes);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Medios GetMedios(int Id, params Expression<Func<Medios, object>>[] includes);

        /// <summary>
        /// Obtiene un Medio en especifico
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Medios GetMedios(int accionId);

        /// <summary>
        /// Agrega un Medio
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Medios AddMedios(Medios medio);

        /// <summary>
        /// Actualiza un Medio
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Medios UpdateMedios(Medios medio);


        /// <summary>
        /// Elimina el Medio
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        bool DeleteMedio(int medioId);
    }
}