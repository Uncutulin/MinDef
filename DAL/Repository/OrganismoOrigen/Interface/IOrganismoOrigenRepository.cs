using DAL.DTOs.Admin;
using DAL.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL.Repository.Interface
{
    public interface IOrganismoOrigenRepository : IDisposable
    {

        /// <summary>
        /// Obtiene todos los Organismos
        /// </summary>
        /// <returns></returns>
        List<OrganismoOrigen> GetOrganismos();        
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        List<OrganismoOrigen> GetOrganismos(params Expression<Func<OrganismoOrigen, object>>[] includes);

        /// <summary>
        /// Obtiene un Organismo en especifico
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        OrganismoOrigen GetOrganismos(int organismoId);

        /// <summary>
        /// Obtiene un Organismo en especifico
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        OrganismoOrigen GetOrganismosbyCode(string organismoCod);

    }
}