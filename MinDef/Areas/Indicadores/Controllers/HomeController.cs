using Commons.Controllers;
using DAL.DTOs.SecrEstrategiaAsuntosMilitares;
using DAL.Mapper;
using DAL.Models.Admin;
using DAL.Repository;
using DAL.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using MinDef.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinDef.Areas.Indicadores.Controllers
{
    [Area("Indicadores")]
    public class HomeController : BaseController
    {
        protected MinDefContext _db;
        protected IContenedorTrabajo<Acciones> _unitWork;
        protected string Codigo_SecrEstAsMil = "SecrEstAsMil";
        public HomeController(IContenedorTrabajo<Acciones> unitWork, MinDefContext db)
        {
            this._db = db;
            _unitWork  = new ContenedorTrabajo<Acciones>(db);
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GraficoTorta(string id)
        {
            return PartialView();
        }

        public IActionResult GraficoBarra(string id)
        {
            return PartialView();
        }


        public IActionResult _GraficoSecrEstrategiaAsuntosMilitares(string id)
        {
            List<Acciones> query = _unitWork.Acciones.GetAccionesOrganismobyCod(Codigo_SecrEstAsMil);
            List<AccionesDTO> listaAccionesDTO = new List<AccionesDTO>();
            listaAccionesDTO = query.Select(lista => MapperManual.MapearAccionesDTO(lista)).ToList();
            ViewBag.AccionesPrioridadAlta = listaAccionesDTO.Where(a => a.Proridad == "Alta").ToList();
            ViewBag.AccionesPrioridadMedia = listaAccionesDTO.Where(a => a.Proridad == "Media").ToList();
            ViewBag.AccionesPrioridadBaja = listaAccionesDTO.Where(a => a.Proridad == "Baja").ToList();
            return PartialView();
        }

        public IActionResult _GraficoSecrEstrategiaAsuntosMilitares_ProyecPrioritarios(string id)
        {
            return PartialView();
        }

        public IActionResult _GraficoSecrEstrategiaAsuntosMilitares_Comunicacion(string id)
        {
            return PartialView();
        }

    }
}
