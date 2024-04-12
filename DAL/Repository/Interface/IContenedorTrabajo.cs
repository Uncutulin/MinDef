using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository.Interface
{
    public interface IContenedorTrabajo<TEntity> where TEntity : class
    {
        IUserRepository Usuarios { get; }
        IIndicadoresRepository Indicadores { get; }
        IAccionesRepository Acciones { get; }
        IOrganismoOrigenRepository OrganismosOrigen { get; }
        IPrioridadesRepository Prioridades { get; }
        IFuerzasRepository Fuerzas { get; }
        ITipoMediosRepository TipoMedios { get; }
        IMediosRepository Medios { get; }
        IOperacionesRepository Operaciones { get; }
        IPersonalOperacionesRepository PersonalOperaciones { get; }
        IRedesRepository Redes { get; }
        ITipoMedicionesRepository TipoMediciones { get; }
        IUbicacionesRepository Ubicaciones { get; }
        IInteraccionesRepository Interacciones { get; }
        IMinisteriosRepository Ministerios { get; }
        ITendenciasRepository Tendencias { get; }
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Save();
        void SaveAsync();
    }
}
