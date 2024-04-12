using System.Collections.Generic;
using Commons.Extensions;
using Commons.Helpers;
using System.Security.Claims;
using Commons.Models;
using Microsoft.AspNetCore.Mvc;
using Commons.Identity.Services;
using System;
using Microsoft.AspNetCore.Hosting;
using DAL.Models.Admin;
using MinDef.Data;
using Commons.Identity.Extensions;
using Castle.Core.Internal;
using static System.Net.Mime.MediaTypeNames;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using DAL.Models.Comunes;
using DAL.Models.Comunicacion;
using System.Runtime.InteropServices;

namespace Commons.Controllers.ViewComponents.Layout
{
    public class SidebarViewComponent : ViewComponent
    {

        private readonly IHostingEnvironment env;
        private readonly MinDefContext _context;

        public SidebarViewComponent()
        {
        }

        public IViewComponentResult Invoke(string filter)
        {

            var sidebars = new List<SidebarMenu>();

            sidebars.Add(MenuHelpers.AddHeader("MENU PRINCIPAL"));
            sidebars.Add(MenuHelpers.AddModule("Inicio", "/", "fa fa-pie-chart"));
            var organizacion = MenuHelpers.AddTree("Organización del Ministerio", "fa fa-users");
            var fuerzasOperativas = MenuHelpers.AddTree("Fuerzas Operativas", "fa fa-user");
            var empresas = MenuHelpers.AddTree("Empresas", "fa fa-building");
            var organizacionesDescentralizadas = MenuHelpers.AddTree("Organismos Descentralizados", "fa fa-university");
            var sistemas = MenuHelpers.AddTree("Administración", "fa fa-gears");

            if (((ClaimsPrincipal)User).IsAdmin())
            {
                // Organizacion Ministerio
                organizacion.TreeChild = new List<SidebarMenu>()
                {
                    MenuHelpers.AddModule("Secretaría de Estrategia y Asuntos Militares", "/SecrEstrategiaAsuntosMilitares", "fa fa-circle-o text-yellow"),
                    //MenuHelpers.AddModule("Subsecretaría de Planeamiento Estratégico y Política Militar", "/SubSecrPlaneamientoEstrategicoPoliticoMilitar", "fa fa-circle-o text-yellow"),
                    MenuHelpers.AddModule("Secretaría de Asuntos Internacionales de Defensa", "/SecrAsuntosInternacionalesDefensa", "fa fa-circle-o text-yellow"),
                    MenuHelpers.AddModule("Secretaría de Investigación Política Industrial y Producción para la Defensa", "/SecrInvestigacionPoliticaIndustrialProduccionParaLaDefensa", "fa fa-circle-o text-yellow"),
                    MenuHelpers.AddModule("Subsecretaría de Planeamiento Operativo y Coordinación Ejecutiva en Emergencias", "/SubSecrPlaneamientoOperativoCoordinacionEjecutivaEmergencias", "fa fa-circle-o text-yellow"),
                    MenuHelpers.AddModule("Subsecretaría de Planeamiento Operativo y Servicio Logístico de la Defensa", "/SubSecrPlaneamientoOperativoServicioLogisticoDeLaDefensa", "fa fa-circle-o text-yellow"),
                    MenuHelpers.AddModule("Subsecretaría de Gestión Administrativa", "/SubSecrGestionAdministrativa", "fa fa-circle-o text-yellow")
                };

                if (organizacion.TreeChild.Count > 0) sidebars.Add(organizacion);


                var emco = MenuHelpers.AddTree("EMCO", "fa fa-bars");



                //Acciones
                    emco.TreeChild = new List<SidebarMenu>() {
                    ////MenuHelpers.AddModule("Comando Operacional", "/1", "fa fa-circle-o text-success"),
                    //MenuHelpers.AddModule("Comando Operacional", "/COPERAL", "fa fa-circle-o text-success"),
                    //MenuHelpers.AddModule("Comando Conjunto Aeroespacial", "/asd3", "fa fa-circle-o text-success"),
                    ////MenuHelpers.AddModule("Aeroespacial", "/4", "fa fa-circle-o text-success"),
                    //MenuHelpers.AddModule("Comando Conjunto Transporte", "/asd5", "fa fa-circle-o text-success"),
                    //MenuHelpers.AddModule("Comando Conjunto Territorial", "/asd2", "fa fa-circle-o text-success"),
                    //MenuHelpers.AddModule("Comando Conjunto de las Fuerzas de Operaciones Especiales", "/asd7", "fa fa-circle-o text-success"),
                    //MenuHelpers.AddModule("Comando Conjunto Antártico", "/asd8", "fa fa-circle-o text-success"),
                    //MenuHelpers.AddModule("Comando Conjunto Marítimo", "/asd9", "fa fa-circle-o text-success"),
                    //MenuHelpers.AddModule("Comando Conjunto Ciberdefensa", "/asd10", "fa fa-circle-o text-success"),
                    //MenuHelpers.AddModule("DIMAE", "/asd11", "fa fa-circle-o text-success"),
                    //MenuHelpers.AddModule("CAECOPAZ", "/sd12", "fa fa-circle-o text-success")
                    MenuHelpers.AddModule("Inicio", "/EMCO/Home/Index", "fa fa-circle-o text-red"),
                    MenuHelpers.AddModule("Apoyo Logístico a Ministerio de Seguridad", "/COPERAL", "fa fa-circle-o text-red"),
                    MenuHelpers.AddModule("Vigilancia y Control Espacio Terrestre “MARVAL”", "/asd5", "fa fa-circle-o text-red"),
                    MenuHelpers.AddModule("Vigilancia y Control Espacio Marítimo", "/asd5", "fa fa-circle-o text-red"),
                    MenuHelpers.AddModule("Vigilancia y Control Aeroespacial “FRONTERAS”", "/asd5", "fa fa-circle-o text-red"),
                    MenuHelpers.AddModule("Vigilancia y Control del Ciberespacio", "/asd5", "fa fa-circle-o text-red"),
                    MenuHelpers.AddModule("Operaciones Militares de Paz", "/asd5", "fa fa-circle-o text-red"),
                    MenuHelpers.AddModule("Apoyos a la Comunidad", "/asd5", "fa fa-circle-o text-red"),
                    MenuHelpers.AddModule("Actividad Antártica", "/asd5", "fa fa-circle-o text-red"),
                };


                //// Fuerzas Operativas
                fuerzasOperativas.TreeChild = new List<SidebarMenu>()
                {
                    
                    //emco,
                    //MenuHelpers.AddModule("EMCO", "/EMCO/Home/Index", "fa fa-bars"),
                    emco,
                    MenuHelpers.AddModule("EA", "/EA/Home/Index", "fa fa-circle-o text-success"),
                    MenuHelpers.AddModule("ARA", "/ARA/Home/Index", "fa fa-circle-o text-success"),
                    MenuHelpers.AddModule("FAA", "/FAA/Home/Index", "fa fa-circle-o text-success"),
                };

                if (fuerzasOperativas.TreeChild.Count > 0) sidebars.Add(fuerzasOperativas);

                //// Empresas
                empresas.TreeChild = new List<SidebarMenu>()
                {
                    MenuHelpers.AddModule("FAdeA", "/11", "fa fa-circle-o text-red"),
                    MenuHelpers.AddModule("TANDANOR", "/12", "fa fa-circle-o text-red"),
                    MenuHelpers.AddModule("COVIARA", "/13", "fa fa-circle-o text-red"),
                    MenuHelpers.AddModule("Frabricación Militares", "/14", "fa fa-circle-o text-red"),
                    MenuHelpers.AddModule("Coorporación Interestadual Pulmarí", "/15", "fa fa-circle-o text-red"),
                };

                if (empresas.TreeChild.Count > 0) sidebars.Add(empresas);


                //// Organizaciones
                organizacionesDescentralizadas.TreeChild = new List<SidebarMenu>()
                {
                    MenuHelpers.AddModule("IAF", "/17", "fa fa-circle-o text-blue"),
                    MenuHelpers.AddModule("IGN", "/18", "fa fa-circle-o text-blue"),
                    MenuHelpers.AddModule("Servicio Meteorológico Nacional", "/19", "fa fa-circle-o text-blue"),
                    MenuHelpers.AddModule("UNDEF", "/20", "fa fa-circle-o text-blue"),
                    MenuHelpers.AddModule("IOSFA", "/16", "fa fa-circle-o text-blue"),
                };

                if (organizacionesDescentralizadas.TreeChild.Count > 0) sidebars.Add(organizacionesDescentralizadas);



                var administracion = MenuHelpers.AddTree("Administración", "fa fa-sitemap ");
                var acciones = MenuHelpers.AddTree("Acciones", "fa fa-bars");
                var comunicaciones = MenuHelpers.AddTree("Comunicaciones", "fa fa-bars");
                comunicaciones.TreeChild = new List<SidebarMenu>()
                {
                    MenuHelpers.AddModule("Tipo de Metrica", "/Comunicacion/TipoMediciones/", "fa fa-circle-o text-orange"),
                    MenuHelpers.AddModule("Red Social", "/Comunicacion/Redes","fa fa-circle-o text-orange"),
                    MenuHelpers.AddModule("Ministerios", "/Comunicacion/Ministerios","fa fa-circle-o text-orange"),
                    MenuHelpers.AddModule("Ubicaciones", "/Comunicacion/Ubicaciones","fa fa-circle-o text-orange"),
                    MenuHelpers.AddModule("Tendencias", "/Comunicacion/Tendencias","fa fa-circle-o text-orange"),
                    MenuHelpers.AddModule("Interacciones", "/Comunicacion/Interacciones","fa fa-circle-o text-orange"),
                };

                //Acciones
                acciones.TreeChild = new List<SidebarMenu>() {
                    MenuHelpers.AddModule("Secretaría de Estrategia y Asuntos Militares", "/SecrEstrategiaAsuntosMilitares/Acciones", "fa fa-circle-o text-orange"),
                    MenuHelpers.AddModule("Secretaría de Asuntos Internacionales de Defensa", "/SecrAsuntosInternacionalesDefensa/Acciones", "fa fa-circle-o text-orange"),
                    MenuHelpers.AddModule("Secretaría de Investigación Política Industrial y Producción para la Defensa", "/SecrInvestigacionPoliticaIndustrialProduccionParaLaDefensa/Acciones", "fa fa-circle-o text-orange"),
                    MenuHelpers.AddModule("Subsecretaría de Planeamiento Operativo y Coordinación Ejecutiva en Emergencias", "/SubSecrPlaneamientoOperativoCoordinacionEjecutivaEmergencias/Acciones", "fa fa-circle-o text-orange"),
                    MenuHelpers.AddModule("Subsecretaría de Planeamiento Operativo y Servicio Logístico de la Defensa", "/SubSecrPlaneamientoOperativoServicioLogisticoDeLaDefensa/Acciones", "fa fa-circle-o text-orange"),
                    MenuHelpers.AddModule("Subsecretaría de Gestión Administrativa", "/SubSecrGestionAdministrativa/Acciones", "fa fa-circle-o text-orange")
                };

                administracion.TreeChild = new List<SidebarMenu>()
                {
                    MenuHelpers.AddModule("Fuerzas", "/Admin/Fuerzas", "fa fa-circle-o text-orange"),
                    MenuHelpers.AddModule("Tipos Medios", "/Admin/TipoMedios", "fa fa-circle-o text-orange"),
                    MenuHelpers.AddModule("Operaciones", "/Admin/Operaciones", "fa fa-circle-o text-orange"),
                    MenuHelpers.AddModule("Indicadores", "/Admin/Indicadores", "fa fa-circle-o text-orange"),
                    acciones,
                    MenuHelpers.AddModule("Usuarios", "/Admin/Usuario", "fa fa-circle-o text-orange"),
                    MenuHelpers.AddModule("Roles", "/SecurityRoles", "fa fa-circle-o text-orange"),
                    MenuHelpers.AddModule("Funciones", "/SecurityFunctions", "fa fa-circle-o text-orange"),
                    comunicaciones,
                    



                    
                //if (administracion.TreeChild.Count > 0) sidebars.Add(administracion);
                };
                //if (acciones.TreeChild.Count > 0) administracion.TreeChild.Add(acciones);
                if (administracion.TreeChild.Count > 0) sidebars.Add(administracion);

                //// SISTEMA
                //sistemas.TreeChild = new List<SidebarMenu>()
                //{

                //};

                //if (sistemas.TreeChild.Count > 0) sidebars.Add(sistemas);
                sidebars.Add(MenuHelpers.AddModule("Cierra Sesión", "javascript:document.getElementById('logoutForm').submit()", "fa fa-sign-out"));

            }
            else if (((ClaimsPrincipal)User).HasClaim("Ministro", "true"))
            {
                // Organizacion Ministerio
                organizacion.TreeChild = new List<SidebarMenu>()
                {
                    MenuHelpers.AddModule("Secretaría de Estrategia y Asuntos Militares", "/SecrEstrategiaAsuntosMilitares", "fa fa-circle-o text-yellow"),
                    //MenuHelpers.AddModule("Subsecretaría de Planeamiento Estratégico y Política Militar", "/SubSecrPlaneamientoEstrategicoPoliticoMilitar", "fa fa-circle-o text-yellow"),
                    MenuHelpers.AddModule("Secretaría de Asuntos Internacionales de Defensa", "/SecrAsuntosInternacionalesDefensa", "fa fa-circle-o text-yellow"),
                    MenuHelpers.AddModule("Secretaría de Investigación Política Industrial y Producción para la Defensa", "/SecrInvestigacionPoliticaIndustrialProduccionParaLaDefensa", "fa fa-circle-o text-yellow"),
                    MenuHelpers.AddModule("Subsecretaría de Planeamiento Operativo y Coordinación Ejecutiva en Emergencias", "/SubSecrPlaneamientoOperativoCoordinacionEjecutivaEmergencias", "fa fa-circle-o text-yellow"),
                    MenuHelpers.AddModule("Subsecretaría de Planeamiento Operativo y Servicio Logístico de la Defensa", "/SubSecrPlaneamientoOperativoServicioLogisticoDeLaDefensa", "fa fa-circle-o text-yellow"),
                    MenuHelpers.AddModule("Subsecretaría de Gestión Administrativa", "/SubSecrGestionAdministrativa", "fa fa-circle-o text-yellow"),
                };

                if (organizacion.TreeChild.Count > 0) sidebars.Add(organizacion);


                //// Fuerzas Operativas
                fuerzasOperativas.TreeChild = new List<SidebarMenu>()
                {
                    MenuHelpers.AddModule("EMCO", "/EMCO/Home/Index", "fa fa-circle-o text-success"),
                    MenuHelpers.AddModule("EA", "/EA/Home/Index", "fa fa-circle-o text-success"),
                    MenuHelpers.AddModule("ARA", "/ARA/Home/Index", "fa fa-circle-o text-success"),
                    MenuHelpers.AddModule("FAA", "/FAA/Home/Index", "fa fa-circle-o text-success"),
                };

                if (fuerzasOperativas.TreeChild.Count > 0) sidebars.Add(fuerzasOperativas);

                //// Empresas
                empresas.TreeChild = new List<SidebarMenu>()
                {
                    MenuHelpers.AddModule("FAdeA", "/11", "fa fa-circle-o text-red"),
                    MenuHelpers.AddModule("TANDANOR", "/12", "fa fa-circle-o text-red"),
                    MenuHelpers.AddModule("COVIARA", "/13", "fa fa-circle-o text-red"),
                    MenuHelpers.AddModule("Frabricación Militares", "/14", "fa fa-circle-o text-red"),
                    MenuHelpers.AddModule("Coorporación Interestadual Pulmarí", "/15", "fa fa-circle-o text-red"),
                    MenuHelpers.AddModule("Servicio de hidrografía Naval Interestadual Pulmarí", "/21", "fa fa-circle-o text-blue"),

                };

                if (empresas.TreeChild.Count > 0) sidebars.Add(empresas);


                //// Organizaciones
                organizacionesDescentralizadas.TreeChild = new List<SidebarMenu>()
                {
                    MenuHelpers.AddModule("IAF", "/17", "fa fa-circle-o text-blue"),
                    MenuHelpers.AddModule("IGN", "/18", "fa fa-circle-o text-blue"),
                    MenuHelpers.AddModule("Servicio Meteorológico Nacional", "/19", "fa fa-circle-o text-blue"),
                    MenuHelpers.AddModule("UNDEF", "/20", "fa fa-circle-o text-blue"),
                    MenuHelpers.AddModule("IOSFA", "/16", "fa fa-circle-o text-red"),
                };

                if (organizacionesDescentralizadas.TreeChild.Count > 0) sidebars.Add(organizacionesDescentralizadas);

                if (sistemas.TreeChild.Count > 0) sidebars.Add(sistemas);
                sidebars.Add(MenuHelpers.AddModule("Cierra Sesión", "javascript:document.getElementById('logoutForm').submit()", "fa fa-sign-out"));
            }
            else
            {

                organizacion.TreeChild = new List<SidebarMenu>();

                // ORGANIZACION

                if (((ClaimsPrincipal)User).IsInRole("SercEstrategiaAsuntosMilitares"))
                    organizacion.TreeChild.Add(MenuHelpers.AddModule("Secretaría de Estrategia y Asuntos Militares", "/SecrEstrategiaAsuntosMilitares", "fa fa-circle-o text-yellow"));

                if (((ClaimsPrincipal)User).IsInRole("SercAsuntosInternacionalesDefensa"))
                    organizacion.TreeChild.Add(MenuHelpers.AddModule("Secretaría de Asuntos Internacionales de Defensa", "/SecrAsuntosInternacionalesDefensa", "fa fa-circle-o text-yellow"));

                if (((ClaimsPrincipal)User).IsInRole("SubSecrGestionAdministrativa"))
                    organizacion.TreeChild.Add(MenuHelpers.AddModule("Subsecretaría de Gestión Administrativas", "/SubSecrGestionAdministrativa", "fa fa-circle-o text-yellow"));

                if (((ClaimsPrincipal)User).IsInRole("SecrInvestigacionPoliticaIndustrialProduccionParaLaDefensa"))
                    organizacion.TreeChild.Add(MenuHelpers.AddModule("Secretaría de Investigación Política Industrial y Producción para la Defensa", "/SecrInvestigacionPoliticaIndustrialProduccionParaLaDefensa", "fa fa-circle-o text-yellow"));

                if (((ClaimsPrincipal)User).IsInRole("SubSecrPlaneamientoOperativoServicioLogisticoDeLaDefensa"))
                    organizacion.TreeChild.Add(MenuHelpers.AddModule("Subsecretaría de Planeamiento Operativo y Servicio Logístico de la Defensa", "/SubSecrPlaneamientoOperativoServicioLogisticoDeLaDefensa", "fa fa-circle-o text-yellow"));

                if (((ClaimsPrincipal)User).IsInRole("SubSecrPlaneamientoOperativoCoordinacionEjecutivaEmergencias"))
                    organizacion.TreeChild.Add(MenuHelpers.AddModule("Subsecretaría de Planeamiento Operativo y Coordinación Ejecutiva en Emergencias", "/SubSecrPlaneamientoOperativoCoordinacionEjecutivaEmergencias", "fa fa-circle-o text-yellow"));


                if (organizacion.TreeChild.Count > 0) sidebars.Add(organizacion);

                sistemas.TreeChild = new List<SidebarMenu>();

                // SISTEMA

                if (((ClaimsPrincipal)User).IsInRole("SercEstrategiaAsuntosMilitares"))
                    sistemas.TreeChild.Add(MenuHelpers.AddModule("Acciones", "/SecrEstrategiaAsuntosMilitares/Acciones", "fa fa-circle-o text-orange"));

                if (((ClaimsPrincipal)User).IsInRole("SercAsuntosInternacionalesDefensa"))
                    sistemas.TreeChild.Add(MenuHelpers.AddModule("Acciones", "/SecrAsuntosInternacionalesDefensa/Acciones", "fa fa-circle-o text-orange"));
                if (((ClaimsPrincipal)User).IsInRole("SubSecrGestionAdministrativa"))
                    sistemas.TreeChild.Add(MenuHelpers.AddModule("Acciones", "/SubSecrGestionAdministrativa/Acciones", "fa fa-circle-o text-orange"));
                if (((ClaimsPrincipal)User).IsInRole("SecrInvestigacionPoliticaIndustrialProduccionParaLaDefensa"))
                    sistemas.TreeChild.Add(MenuHelpers.AddModule("Acciones", "/SecrInvestigacionPoliticaIndustrialProduccionParaLaDefensa/Acciones", "fa fa-circle-o text-orange"));

                if (((ClaimsPrincipal)User).IsInRole("SubSecrPlaneamientoOperativoServicioLogisticoDeLaDefensa"))
                    sistemas.TreeChild.Add(MenuHelpers.AddModule("Acciones", "/SubSecrPlaneamientoOperativoServicioLogisticoDeLaDefensa/Acciones", "fa fa-circle-o text-orange"));

                if (((ClaimsPrincipal)User).IsInRole("SubSecrPlaneamientoOperativoCoordinacionEjecutivaEmergencias"))
                    sistemas.TreeChild.Add(MenuHelpers.AddModule("Acciones", "/SubSecrPlaneamientoOperativoCoordinacionEjecutivaEmergencias/Acciones", "fa fa-circle-o text-orange"));


                if (sistemas.TreeChild.Count > 0) sidebars.Add(sistemas);

                sidebars.Add(MenuHelpers.AddModule("Cierra Sesión", "javascript:document.getElementById('logoutForm').submit()", "fa fa-sign-out"));
            }

            return View("LayoutSidebar", sidebars);
        }
    }
}

