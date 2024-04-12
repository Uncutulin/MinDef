using AutoMapper;
using Commons.Controllers;
using DAL.Models;
using DAL.Models.Admin;
using DAL.Repository.Interface;
using DAL.Repository;
using Microsoft.AspNetCore.Mvc;
using MinDef.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MinDef.Areas.Admin.Controllers;
using DAL.DTOs.Admin;
using Microsoft.AspNetCore.Mvc.Rendering;
using DAL.Mapper;
using System.Collections;
using System.Security.Claims;

namespace MinDef.Controllers
{
    public class HomeController : MinDefBaseController
    {
        protected IContenedorTrabajo<IndicadoresBase> _unitWork;
        protected IContenedorTrabajo<Acciones> _unitWorkAcciones;
        public HomeController(MinDefContext db, IContenedorTrabajo<Usuario> workSpace,
            IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
            _workSpace = workSpace;
            _unitWork = new ContenedorTrabajo<IndicadoresBase>(db);
            _unitWorkAcciones = new ContenedorTrabajo<Acciones>(db);
        }

        public IActionResult Index()
        {
           

            var query = _unitWork.Indicadores.GetIndicadoresAll();
            ViewBag.listaIndicadoresDTO = query.Select(lista => MapperManual.MapearIndicadorDTO(lista)).OrderBy(i => i.Orden).ToList();

            var accionesAlta = _unitWorkAcciones.Acciones.GetAcciones().Where(e => e.Prioridad.Titulo == "Alta");
            var accionesMedia = _unitWorkAcciones.Acciones.GetAcciones().Where(e => e.Prioridad.Titulo == "Media");
            var accionesBaja = _unitWorkAcciones.Acciones.GetAcciones().Where(e => e.Prioridad.Titulo == "Baja");

            var listAccionesAlta = accionesAlta.GroupBy(e => e.OrganismoOrigen).Select(g => g.OrderByDescending(e => e.Id).FirstOrDefault());
            var listAccionesMedia = accionesMedia.GroupBy(e => e.OrganismoOrigen).Select(g => g.OrderByDescending(e => e.Id).FirstOrDefault());
            var listAccionesBaja = accionesBaja.GroupBy(e => e.OrganismoOrigen).Select(g => g.OrderByDescending(e => e.Id).FirstOrDefault());

            ViewBag.listAccionesAlta = listAccionesAlta.Select(lista => MapperManual.MapearAccionesDTO(lista)).OrderByDescending(i => i.Id).ToList();
            ViewBag.listAccionesMedia = listAccionesMedia.Select(lista => MapperManual.MapearAccionesDTO(lista)).OrderByDescending(i => i.Id).ToList();
            ViewBag.listAccionesBaja = listAccionesBaja.Select(lista => MapperManual.MapearAccionesDTO(lista)).OrderByDescending(i => i.Id).ToList();

            return View();
        }

        public IActionResult DetalleAccion(int Id)
        {
            var accion = _unitWorkAcciones.Acciones.GetAcciones(Id);
            var acciones = _unitWorkAcciones.Acciones.GetAcciones().Where(e => e.Prioridad.Titulo == accion.Prioridad.Titulo && e.OrganismoOrigen.Id == accion.OrganismoOrigen.Id);
            ViewBag.NombreOrganismo = accion.OrganismoOrigen.Titulo;
            ViewBag.Prioridad = accion.Prioridad.Titulo;
            return View(acciones.Select(lista => MapperManual.MapearAccionesDTO(lista)).OrderByDescending(i => i.Id).ToList());
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
