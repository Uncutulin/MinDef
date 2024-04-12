﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MinDef.Data;

namespace MinDef.Data.Migrations
{
    [DbContext(typeof(MinDefContext))]
    [Migration("20240319235108_add_table_Personal_Operacion")]
    partial class add_table_Personal_Operacion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Commons.Identity.CommonsFunction", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("DeletedById");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<string>("Description");

                    b.Property<bool>("Display");

                    b.Property<string>("LastEditById");

                    b.Property<DateTime>("LastEditTime");

                    b.Property<string>("Name");

                    b.Property<string>("RoutesJson");

                    b.Property<bool>("Show");

                    b.HasKey("Id");

                    b.ToTable("AspNetFunctions");
                });

            modelBuilder.Entity("Commons.Identity.CommonsRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<bool>("Enabled");

                    b.Property<DateTime?>("Expiration");

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.Property<bool>("Show");

                    b.Property<string>("ShowName");

                    b.Property<string>("WorkSpaceId");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Commons.Identity.CommonsRoleFunction", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<string>("FunctionId");

                    b.Property<string>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("FunctionId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleFunctions");
                });

            modelBuilder.Entity("DAL.Models.Admin.Acciones", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo");

                    b.Property<string>("Descripcion");

                    b.Property<DateTime>("FechaActualizacion");

                    b.Property<int?>("OrganismoOrigenId");

                    b.Property<string>("Porcentaje");

                    b.Property<int?>("PrioridadId");

                    b.Property<string>("Titulo");

                    b.HasKey("Id");

                    b.HasIndex("OrganismoOrigenId");

                    b.HasIndex("PrioridadId");

                    b.ToTable("Acciones");
                });

            modelBuilder.Entity("DAL.Models.Admin.IndicadoresBase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo");

                    b.Property<string>("Descripcion");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<DateTime>("FechaActualizacion");

                    b.Property<string>("Icono");

                    b.Property<int>("Orden");

                    b.Property<string>("Titulo");

                    b.HasKey("Id");

                    b.ToTable("IndicadoresBase");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IndicadoresBase");
                });

            modelBuilder.Entity("DAL.Models.Admin.OrganismoOrigen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abreviatura");

                    b.Property<bool>("Activo");

                    b.Property<string>("Codigo");

                    b.Property<string>("Descripcion");

                    b.Property<DateTime>("FechaActualizacion");

                    b.Property<int>("Orden");

                    b.Property<string>("Titulo");

                    b.HasKey("Id");

                    b.ToTable("OrganismoOrigen");
                });

            modelBuilder.Entity("DAL.Models.Admin.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .IsRequired();

                    b.Property<string>("Cuil");

                    b.Property<DateTime>("FechaActualizacion");

                    b.Property<DateTime?>("FechaNacimiento");

                    b.Property<byte[]>("Foto");

                    b.Property<string>("Nombre")
                        .IsRequired();

                    b.Property<string>("NroDocumento");

                    b.HasKey("Id");

                    b.ToTable("Persona");
                });

            modelBuilder.Entity("DAL.Models.Admin.Prioridades", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo");

                    b.Property<string>("Descripcion");

                    b.Property<DateTime>("FechaActualizacion");

                    b.Property<string>("Titulo");

                    b.HasKey("Id");

                    b.ToTable("Prioridades");
                });

            modelBuilder.Entity("DAL.Models.Admin.Usuario", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<int?>("PersonaId");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("PersonaId");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("DAL.Models.Comunes.Fuerzas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Activo");

                    b.Property<string>("Codigo");

                    b.Property<DateTime>("FechaActualizacion");

                    b.Property<string>("Logo");

                    b.Property<string>("Nombre");

                    b.Property<string>("Orden");

                    b.HasKey("Id");

                    b.ToTable("Fuerzas");
                });

            modelBuilder.Entity("DAL.Models.Comunes.Medios", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo");

                    b.Property<int>("Cantidad");

                    b.Property<DateTime>("FechaActualizacion");

                    b.Property<string>("Finalidad");

                    b.Property<int?>("FuerzaId");

                    b.Property<string>("Nombre");

                    b.Property<int?>("OperacionId");

                    b.Property<int?>("TipoMediosId");

                    b.HasKey("Id");

                    b.HasIndex("FuerzaId");

                    b.HasIndex("OperacionId");

                    b.HasIndex("TipoMediosId");

                    b.ToTable("Medios");
                });

            modelBuilder.Entity("DAL.Models.Comunes.Operaciones", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo");

                    b.Property<string>("Descripcion");

                    b.Property<DateTime>("FechaActualizacion");

                    b.Property<string>("Latitud");

                    b.Property<string>("Longitud");

                    b.Property<string>("Nombre");

                    b.HasKey("Id");

                    b.ToTable("Operaciones");
                });

            modelBuilder.Entity("DAL.Models.Comunes.PersonalOperaciones", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo");

                    b.Property<int>("Cantidad");

                    b.Property<DateTime>("FechaActualizacion");

                    b.Property<int?>("FuerzaId");

                    b.Property<int?>("OperacionId");

                    b.HasKey("Id");

                    b.HasIndex("FuerzaId");

                    b.HasIndex("OperacionId");

                    b.ToTable("PersonalOperaciones");
                });

            modelBuilder.Entity("DAL.Models.Comunes.TipoMedios", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo");

                    b.Property<string>("Codigo");

                    b.Property<string>("Descripcion");

                    b.Property<DateTime>("FechaActualizacion");

                    b.Property<string>("Logo");

                    b.Property<string>("Nombre");

                    b.Property<string>("Orden");

                    b.HasKey("Id");

                    b.ToTable("TipoMedios");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("DAL.Models.Admin.IndicadorComunicacion", b =>
                {
                    b.HasBaseType("DAL.Models.Admin.IndicadoresBase");

                    b.Property<string>("PrimerSubTitulo");

                    b.Property<string>("PrimerValor");

                    b.Property<string>("SegundoSubTituto");

                    b.Property<string>("SegundoValor");

                    b.HasDiscriminator().HasValue("IndicadorComunicacion");
                });

            modelBuilder.Entity("DAL.Models.Admin.IndicadorNumero", b =>
                {
                    b.HasBaseType("DAL.Models.Admin.IndicadoresBase");

                    b.Property<string>("Numero");

                    b.HasDiscriminator().HasValue("IndicadorNumero");
                });

            modelBuilder.Entity("DAL.Models.Admin.IndicadorPorcentaje", b =>
                {
                    b.HasBaseType("DAL.Models.Admin.IndicadoresBase");

                    b.Property<string>("Porcentaje");

                    b.HasDiscriminator().HasValue("IndicadorPorcentaje");
                });

            modelBuilder.Entity("Commons.Identity.CommonsRoleFunction", b =>
                {
                    b.HasOne("Commons.Identity.CommonsFunction", "Function")
                        .WithMany()
                        .HasForeignKey("FunctionId");

                    b.HasOne("Commons.Identity.CommonsRole", "Role")
                        .WithMany("RoleFunctions")
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("DAL.Models.Admin.Acciones", b =>
                {
                    b.HasOne("DAL.Models.Admin.OrganismoOrigen", "OrganismoOrigen")
                        .WithMany()
                        .HasForeignKey("OrganismoOrigenId");

                    b.HasOne("DAL.Models.Admin.Prioridades", "Prioridad")
                        .WithMany()
                        .HasForeignKey("PrioridadId");
                });

            modelBuilder.Entity("DAL.Models.Admin.Usuario", b =>
                {
                    b.HasOne("DAL.Models.Admin.Persona", "Persona")
                        .WithMany()
                        .HasForeignKey("PersonaId");
                });

            modelBuilder.Entity("DAL.Models.Comunes.Medios", b =>
                {
                    b.HasOne("DAL.Models.Comunes.Fuerzas", "Fuerza")
                        .WithMany()
                        .HasForeignKey("FuerzaId");

                    b.HasOne("DAL.Models.Comunes.Operaciones", "Operacion")
                        .WithMany("Medios")
                        .HasForeignKey("OperacionId");

                    b.HasOne("DAL.Models.Comunes.TipoMedios", "TipoMedios")
                        .WithMany()
                        .HasForeignKey("TipoMediosId");
                });

            modelBuilder.Entity("DAL.Models.Comunes.PersonalOperaciones", b =>
                {
                    b.HasOne("DAL.Models.Comunes.Fuerzas", "Fuerza")
                        .WithMany()
                        .HasForeignKey("FuerzaId");

                    b.HasOne("DAL.Models.Comunes.Operaciones", "Operacion")
                        .WithMany()
                        .HasForeignKey("OperacionId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Commons.Identity.CommonsRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("DAL.Models.Admin.Usuario")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("DAL.Models.Admin.Usuario")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Commons.Identity.CommonsRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DAL.Models.Admin.Usuario")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("DAL.Models.Admin.Usuario")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
