using Commons.Identity.Services;
using DAL.Models.Admin;
using DAL.Models.Comunicacion;
using DAL.Models.Comunes;
using DAL.Repository.Interface;
using Microsoft.AspNetCore.Identity;
using MinDef.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public class ContenedorTrabajo<TEntity> : IContenedorTrabajo<TEntity> where TEntity : class
    {
        private MinDefContext _db;
        private readonly SignInService<Usuario> _signInManager;
        private readonly UserManager<Usuario> _UserManager;
        public ContenedorTrabajo(MinDefContext db, SignInService<Usuario> signInManager
            , UserManager<Usuario> userManager)
        {
            this._signInManager = signInManager;
            this._UserManager = userManager;
            this._db = db;
            this.Usuarios = new UserRepository(db,signInManager, userManager);
        }

        public ContenedorTrabajo(MinDefContext db)
        {
            this._db = db;
            this.Indicadores = new IndicadoresRepository(db);
            this.Acciones = new AccionesRepository(db);
            this.OrganismosOrigen = new OrganismoOrigenRepository(db);
            this.Prioridades = new PrioridadesRepository(db);
            this.Fuerzas = new FuerzasRepository(db);
            this.TipoMedios = new TipoMediosRepository(db);
            this.Medios = new MediosRepository(db);
            this.Operaciones = new OperacionesRepository(db);
            this.PersonalOperaciones = new PersonalOperacionesRepository(db);
            this.Redes = new RedesRepository(db);
            this.TipoMediciones = new TipoMedicionesRepository(db);
            this.Ministerios = new MinisteriosRepository(db);
            this.Tendencias = new TendenciasRepository(db);
            this.Ubicaciones= new UbicacionesRepository(db);
            this.Interacciones = new InteraccionesRepository(db);
        }

        public IUserRepository Usuarios { get; set; }

        public IIndicadoresRepository Indicadores { get; set; }

        public IAccionesRepository Acciones { get; set; }
        public IOrganismoOrigenRepository OrganismosOrigen { get; set; }

        public IPrioridadesRepository Prioridades { get; set; }

        public IFuerzasRepository Fuerzas { get; set; }

        public ITipoMediosRepository TipoMedios { get; set; }

        public IMediosRepository Medios { get; set; }

        public IOperacionesRepository Operaciones { get; set; }
        public IPersonalOperacionesRepository PersonalOperaciones { get; set; }

        public IRedesRepository Redes { get; set; }
        public ITipoMedicionesRepository TipoMediciones { get; set; }
        public IUbicacionesRepository Ubicaciones { get; set; }
        public IInteraccionesRepository Interacciones { get; set; }
        public IMinisteriosRepository Ministerios { get; set; }
        public ITendenciasRepository Tendencias { get; set; }
       
        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public async void SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public void Add(TEntity entity)
        {
            _db.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entity)
        {
            _db.Set<TEntity>().Update(entity);
        }
    }
}
