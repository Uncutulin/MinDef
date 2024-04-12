using Commons.Identity;
using DAL.Models.Admin;
using DAL.Models.Comunes;
using DAL.Models.Comunicacion;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinDef.Data
{
    public class MinDefContext : CommonsDbContext<Usuario>
    {
        public MinDefContext(DbContextOptions<MinDefContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        

        public DbSet<Persona> Persona { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<IndicadoresBase> IndicadoresBase { get; set; }
        public DbSet<IndicadorPorcentaje> IndicadorPorcentaje { get; set; }
        public DbSet<IndicadorComunicacion> IndicadorComunicacion { get; set; }
        public DbSet<IndicadorNumero> IndicadorNumero { get; set; }

        public DbSet<Prioridades> Prioridades { get; set; }
        public DbSet<Acciones> Acciones { get; set; }
        public DbSet<OrganismoOrigen> OrganismoOrigen { get; set; }


        //COPERAL
        public DbSet<Fuerzas> Fuerzas { get; set; }
        public DbSet<TipoMedios> TipoMedios { get; set; }
        public DbSet<Medios> Medios { get; set; }
        public DbSet<Operaciones> Operaciones { get; set; }
        public DbSet<PersonalOperaciones> PersonalOperaciones { get; set; }

        //Comunicaciones
        public DbSet<Redes> Redes { get; set; }
        public DbSet<TipoMediciones> TipoMediciones {  get; set; }
        public DbSet<Ubicaciones> Ubicaciones { get; set; }
        public DbSet<Interacciones> Interacciones { get; set; }
        public DbSet<Ministerios> Ministerios { get; set; }
        public DbSet<Tendencias> Tendencias { get; set; }

        public override List<IWorkSpace> GetIWorkSpaces()
        {
            return new List<IWorkSpace>();
        }
    }
}
