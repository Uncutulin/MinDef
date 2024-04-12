using AutoMapper;
using Commons.Controllers;
using DAL.DTOs.SecrEstrategiaAsuntosMilitares;
using DAL.Mapper;
using DAL.Models.Admin;
using DAL.Repository.Interface;
using DAL.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MinDef.Areas.Admin.Controllers;
using MinDef.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinDef.Areas.SecrInvestigacionPoliticaIndustrialProduccionParaLaDefensa.Controllers
{
    [Area("SecrInvestigacionPoliticaIndustrialProduccionParaLaDefensa")]
    public class AccionesController : MinDefBaseController
    {
        protected IContenedorTrabajo<Acciones> _unitWork;
        protected IContenedorTrabajo<Prioridades> _unitWorkPrioridades;
        protected IContenedorTrabajo<OrganismoOrigen> _unitWorkOrganismo;
        protected string codOrganismo = "SecInvPolIndProdDef";
        public AccionesController(MinDefContext db, IContenedorTrabajo<Usuario> workSpace,
            IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
            _workSpace = workSpace;
            _unitWork = new ContenedorTrabajo<Acciones>(db);
            _unitWorkPrioridades = new ContenedorTrabajo<Prioridades>(_db);
            _unitWorkOrganismo = new ContenedorTrabajo<OrganismoOrigen>(_db);
        }
        public IActionResult Index()
        {
            ViewBag.Titulo = "\"Secretaría de Investigación Política Industrial y Producción para la Defensa";
            return View();
        }
        public IActionResult _AccionesDataTable()
        {
            List<Acciones> query = _unitWork.Acciones.GetAccionesOrganismobyCod(codOrganismo);
            List<AccionesDTO> listaAccionesDTO = new List<AccionesDTO>();
            listaAccionesDTO = query.Select(lista => MapperManual.MapearAccionesDTO(lista)).ToList();
            return DataTable(listaAccionesDTO.AsQueryable());
        }

        public IActionResult _Create()
        {
            ViewBag.Prioridades = _unitWork.Prioridades.GetPrioridades().Select(g => new SelectListItem() { Text = g.Titulo, Value = g.Id.ToString() });
            return PartialView("_Create");
        }

        [HttpPost]
        public async Task<IActionResult> _Create(AccionesDTO accionesDTO)
        {
            try
            {
                ModelState.Remove("Id");
                if (ModelState.IsValid)
                {
                    Prioridades prioridad = _unitWorkPrioridades.Prioridades.GetPrioridades(accionesDTO.ProridadId);
                    OrganismoOrigen organismoOrigen = _unitWorkOrganismo.OrganismosOrigen.GetOrganismosbyCode(codOrganismo);

                    Acciones accion = MapperManual.MapearAcciones(accionesDTO, organismoOrigen, prioridad);
                    _unitWork.Add(accion);
                    _unitWork.Save();
                    AddPageAlerts(PageAlertType.Success, "Se ha creado con éxito la Acción.");
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception e)
            {
                AddPageAlerts(PageAlertType.Error, "Ha ocurrido un error al crear la Acción, intentelo nuevamente mas tarde.");
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Prioridades = _unitWork.Prioridades.GetPrioridades().Select(g => new SelectListItem() { Text = g.Titulo, Value = g.Id.ToString() });
            return PartialView("_Create", accionesDTO);
        }

        public IActionResult _Update(int Id)
        {
            Acciones accion = _unitWork.Acciones.GetAcciones(Id);
            ViewBag.Prioridades = _unitWork.Prioridades.GetPrioridades().Select(g => new SelectListItem() { Text = g.Titulo, Value = g.Id.ToString() });
            return PartialView("_Update", MapperManual.MapearAccionesDTO(accion));
        }

        [HttpPost]
        public async Task<IActionResult> _Update(AccionesDTO accionesDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Prioridades prioridad = _unitWorkPrioridades.Prioridades.GetPrioridades(accionesDTO.ProridadId);
                    OrganismoOrigen organismoOrigen = _unitWorkOrganismo.OrganismosOrigen.GetOrganismosbyCode(codOrganismo);

                    Acciones accion = MapperManual.MapearAcciones(accionesDTO, organismoOrigen, prioridad);
                    _unitWork.Update(accion);
                    _unitWork.Save();
                    AddPageAlerts(PageAlertType.Success, "Se ha editado con éxito la Acción.");
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception e)
            {
                AddPageAlerts(PageAlertType.Error, "Ha ocurrido un error al editar la Acción, intentelo nuevamente mas tarde.");
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Prioridades = _unitWork.Prioridades.GetPrioridades().Select(g => new SelectListItem() { Text = g.Titulo, Value = g.Id.ToString() });
            return PartialView("_Update", accionesDTO);
        }

    }
}

