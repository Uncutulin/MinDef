using DAL.DTOs.Admin;
using DAL.Models.Admin;
using DAL.Models.Comunes;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL.Repository.Interface
{
    public interface IPersonalOperacionesRepository : IDisposable
    {

        /// <summary>
        /// Obtiene el personal de las Operaciones
        /// </summary>
        /// <returns></returns>
        List<PersonalOperaciones> GetPersonalOperaciones();

        /// <summary>
        /// Obtiene todos todo el personal de una Operación especifica
        /// </summary>
        /// <returns></returns>
        List<PersonalOperaciones> GetPersonalByOperacionId(string Id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        List<PersonalOperaciones> GetPersonalOperaciones(params Expression<Func<PersonalOperaciones, object>>[] includes);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        PersonalOperaciones GetPersonalOperaciones(int Id, params Expression<Func<PersonalOperaciones, object>>[] includes);

        /// <summary>
        /// Obtiene un Persnal en especifico
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        PersonalOperaciones GetPersonalOperaciones(int personalId);

        /// <summary>
        /// Agrega un Personal
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        PersonalOperaciones AddPersonalOperaciones(PersonalOperaciones personal);

        /// <summary>
        /// Actualiza un Personal
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        PersonalOperaciones UpdatePersonalOperaciones(PersonalOperaciones personal);


        /// <summary>
        /// Elimina el Personal
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        bool DeletePersonalOperaciones(int personalId);
    }
}