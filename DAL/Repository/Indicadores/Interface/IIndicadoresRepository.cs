using DAL.DTOs.Admin;
using DAL.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL.Repository.Interface
{
    public interface IIndicadoresRepository : IDisposable
    {

        /// <summary>
        /// Obtiene todos los Indicadores Activos
        /// </summary>
        /// <returns></returns>
        List<IndicadoresBase> GetIndicadores();        
        
        /// <summary>
        /// Obtiene todos los Indicadores
        /// </summary>
        /// <returns></returns>
        List<IndicadoresBase> GetIndicadoresAll();

        /// <summary>
        /// Obtiene todos los Typos Indicadores
        /// </summary>
        /// <returns></returns>
        List<Type> GetTypeIndicadores();

        /// <summary>
        /// Obtiene todos los nomlbres de los Typos Indicadores
        /// </summary>
        /// <returns></returns>
        List<string> GetTypeIndicadoresName();

        /// <summary>
        /// Obtiene todos los nomlbres de los Typos Indicadores
        /// </summary>
        /// <returns></returns>
        Type GetTypeIndicador(string typeIndicadorName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        List<IndicadoresBase> GetIndicadores(params Expression<Func<IndicadoresBase, object>>[] includes);

        /// <summary>
        /// Obtiene un Indicador en especifico
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        IndicadoresBase GetIndicador(int indicadorId);       

        /// <summary>
        /// Agrega un Indicador
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        bool AddIndicador(IndicadoresBase indicador);

        /// <summary>
        /// Actualiza el Indicador
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        bool UpdateIndicador(IndicadoresBase indicador);

        /// <summary>
        /// Elimina el Indicador
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        bool DeleteIndicador(int indicadorId);
    }
}