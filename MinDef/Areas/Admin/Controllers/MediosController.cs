using AutoMapper;
using Commons.Controllers;
using Commons.Identity.Services;
using DAL.DTOs.Admin;
using DAL.Mapper;
using DAL.Models.Admin;
using DAL.Models.Comunes;
using DAL.Repository;
using DAL.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MinDef.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace MinDef.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MediosController : MinDefBaseController
    {

        protected IContenedorTrabajo<Medios> _unitWork;
        protected IContenedorTrabajo<TipoMedios> _unitWorkTipoMedio;
        protected IContenedorTrabajo<Fuerzas> _unitWorkFuerza;
        protected IContenedorTrabajo<Operaciones> _unitWorkOperaciones;
        public MediosController(MinDefContext db, IContenedorTrabajo<Usuario> workSpace,
            IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
            _workSpace = workSpace;
            _unitWork = new ContenedorTrabajo<Medios>(db);
            _unitWorkTipoMedio = new ContenedorTrabajo<TipoMedios>(db);
            _unitWorkFuerza = new ContenedorTrabajo<Fuerzas>(db);
            _unitWorkOperaciones = new ContenedorTrabajo<Operaciones>(db);
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult _MediosDataTableIndex(string Id)
        {
            Operaciones operacion = _unitWorkOperaciones.Operaciones.GetOperaciones(Convert.ToInt32(Id));
            ViewBag.OperacionId = Id;
            ViewBag.OperacionNombre = operacion.Nombre;
            return PartialView("_MediosDataTable");
        }

        public IActionResult _MediosDataTable(string Id)
        {
            var query = _unitWork.Medios.GetMediosByOperacionId(Id);
            var listaMediosDTO = new List<MediosDTO>();
            
            foreach (var lista in query)
            {
                listaMediosDTO.Add(MapperManual.MapearMediosDTO(lista));
            }
            return DataTable(listaMediosDTO.AsQueryable());
        }

        public IActionResult _Create(string Id)
        {
            ViewBag.OperacionId = Id;
            ViewBag.Fuerza = _unitWork.Fuerzas.GetFuerzas().Select(g => new SelectListItem() { Text =  g.Nombre, Value = g.Id.ToString() });
            ViewBag.TipoMedios = _unitWork.TipoMedios.GetTipoMedios().Select(g => new SelectListItem() { Text =  g.Nombre, Value = g.Id.ToString() });
            return PartialView("_Create");
        }

        [HttpPost]
        public async Task<IActionResult> _Create(MediosDTO medios)
        {
            try
            {
                ModelState.Remove("Id");
                if (ModelState.IsValid)
                {
                    medios.Id=0;
                    Operaciones operacion = _unitWorkOperaciones.Operaciones.GetOperaciones(medios.OperacionId);
                    TipoMedios tipoMedio = _unitWorkTipoMedio.TipoMedios.GetTipoMedios(medios.TipoMedios.Id);
                    Fuerzas fuerza = _unitWorkFuerza.Fuerzas.GetFuerzas(medios.Fuerza.Id);
                    _unitWork.Add(MapperManual.MapearMedios(medios, fuerza, tipoMedio, operacion));
                    _unitWork.Save();
                    AddPageAlerts(PageAlertType.Success, "Se ha creado con éxito el Medio.");
                    return Redirect($"/Admin/Operaciones/Index?MedioId={medios.OperacionId}");
                }               
            }
            catch (Exception e)
            {
                AddPageAlerts(PageAlertType.Error, "Ha ocurrido un error al crear el Medio, intentelo nuevamente mas tarde.");
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Fuerza = _unitWork.Fuerzas.GetFuerzas().Select(g => new SelectListItem() { Text =  g.Nombre, Value = g.Id.ToString() });
            ViewBag.TipoMedios = _unitWork.TipoMedios.GetTipoMedios().Select(g => new SelectListItem() { Text =  g.Nombre, Value = g.Id.ToString() });
            return PartialView("_Create", medios);
        }


        public IActionResult _Update(int Id)
        {
            ViewBag.Fuerza = _unitWork.Fuerzas.GetFuerzas().Select(g => new SelectListItem() { Text =  g.Nombre, Value = g.Id.ToString() });
            ViewBag.TipoMedios = _unitWork.TipoMedios.GetTipoMedios().Select(g => new SelectListItem() { Text =  g.Nombre, Value = g.Id.ToString() });
            Medios medios = _unitWork.Medios.GetMedios(Id, p => p.Operacion);
            return PartialView("_Update", MapperManual.MapearMediosDTO(medios));
        }

        [HttpPost]
        public async Task<IActionResult> _Update(MediosDTO medios)
        {
            try
            {
                ModelState.Remove("OperacionId");
                if (ModelState.IsValid)
                {
                    Operaciones operacion = _unitWorkOperaciones.Operaciones.GetOperaciones(medios.OperacionId);
                    TipoMedios tipoMedio = _unitWorkTipoMedio.TipoMedios.GetTipoMedios(medios.TipoMedios.Id);
                    Fuerzas fuerza = _unitWorkFuerza.Fuerzas.GetFuerzas(medios.Fuerza.Id);
                    _unitWork.Update(MapperManual.MapearMedios(medios, fuerza, tipoMedio, operacion));
                    _unitWork.Save();
                    AddPageAlerts(PageAlertType.Success, "Se ha editado con éxito el Medio.");
                    return Redirect($"/Admin/Operaciones/Index?MedioId={medios.OperacionId}");
                }
            }
            catch (Exception e)
            {
                AddPageAlerts(PageAlertType.Error, "Ha ocurrido un error al editar el Medio, intentelo nuevamente mas tarde.");
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Fuerza = _unitWork.Fuerzas.GetFuerzas().Select(g => new SelectListItem() { Text =  g.Nombre, Value = g.Id.ToString() });
            ViewBag.TipoMedios = _unitWork.TipoMedios.GetTipoMedios().Select(g => new SelectListItem() { Text =  g.Nombre, Value = g.Id.ToString() });
            return PartialView("_Update", medios);
        }


        [HttpPost]
        public IActionResult Delete(int Id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unitWork.Medios.DeleteMedio(Id);
                    return Ok(new
                    {
                        message = "Error al Borrar el Medio",
                        errors = "",
                    });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    message = "Error al Borrar el Medio",
                    errors = e,
                });
            }

            return BadRequest(new
            {
                message = "Error al Borrar el Medio",
                errors = "",
            });
        }
    }
}
