using AutoMapper;
using Commons.Controllers;
using DAL.DTOs.SecrEstrategiaAsuntosMilitares;
using DAL.Mapper;
using DAL.Models.Admin;
using DAL.Repository.Interface;
using DAL.Repository;
using Microsoft.AspNetCore.Mvc;
using MinDef.Areas.Admin.Controllers;
using MinDef.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinDef.Areas.SubSecrGestionAdministrativa.Controllers
{
    [Area("SubSecrGestionAdministrativa")]
    public class HomeController : MinDefBaseController
    {
        protected IContenedorTrabajo<Acciones> _unitWork;
        protected string codOrganismo = "SubsGestAdmin";
        public HomeController(MinDefContext db, IContenedorTrabajo<Usuario> workSpace,
          IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
            _workSpace = workSpace;
            _unitWork = new ContenedorTrabajo<Acciones>(db);
        }
        public IActionResult Index()
        {
            ViewBag.Titulo = "Subsecretaría de Gestión Administrativa";
            List<Acciones> query = _unitWork.Acciones.GetAccionesOrganismobyCod(codOrganismo);
            List<AccionesDTO> listaAccionesDTO = new List<AccionesDTO>();
            listaAccionesDTO = query.Select(lista => MapperManual.MapearAccionesDTO(lista)).ToList();
            ViewBag.AccionesPrioridadAlta = listaAccionesDTO.Where(a => a.Proridad == "Alta").ToList();
            ViewBag.AccionesPrioridadMedia = listaAccionesDTO.Where(a => a.Proridad == "Media").ToList();
            ViewBag.AccionesPrioridadBaja = listaAccionesDTO.Where(a => a.Proridad == "Baja").ToList();
            return View();
        }
    }
}







