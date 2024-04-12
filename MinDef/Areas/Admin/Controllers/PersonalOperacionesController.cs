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
    public class PersonalOperacionesController : MinDefBaseController
    {

        protected IContenedorTrabajo<PersonalOperaciones> _unitWork;
        protected IContenedorTrabajo<Fuerzas> _unitWorkFuerza;
        protected IContenedorTrabajo<Operaciones> _unitWorkOperaciones;
        public PersonalOperacionesController(MinDefContext db, IContenedorTrabajo<Usuario> workSpace,
            IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
            _workSpace = workSpace;
            _unitWork = new ContenedorTrabajo<PersonalOperaciones>(db);
            _unitWorkFuerza = new ContenedorTrabajo<Fuerzas>(db);
            _unitWorkOperaciones = new ContenedorTrabajo<Operaciones>(db);
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult _PersonalOperacionesDataTableIndex(string Id)
        {
            Operaciones operacion = _unitWorkOperaciones.Operaciones.GetOperaciones(Convert.ToInt32(Id));
            ViewBag.OperacionId = Id;
            ViewBag.OperacionNombre = operacion.Nombre;
            return PartialView("_PersonalDataTable");
        }

        public IActionResult _PersonalDataTable(string Id)
        {
            var query = _unitWork.PersonalOperaciones.GetPersonalByOperacionId(Id);
            var listaMediosDTO = new List<PersonalOperacionesDTO>();
            
            foreach (var lista in query)
            {
                listaMediosDTO.Add(MapperManual.MapearPersonalOperacionesDTO(lista));
            }
            return DataTable(listaMediosDTO.AsQueryable());
        }

        public IActionResult _Create(string Id)
        {
            ViewBag.OperacionId = Id;
            ViewBag.Fuerza = _unitWork.Fuerzas.GetFuerzas().Select(g => new SelectListItem() { Text =  g.Nombre, Value = g.Id.ToString() });
            return PartialView("_Create");
        }

        [HttpPost]
        public async Task<IActionResult> _Create(PersonalOperacionesDTO personal)
        {
            try
            {
                ModelState.Remove("Id");
                if (ModelState.IsValid)
                {
                    personal.Id=0;
                    Operaciones operacion = _unitWorkOperaciones.Operaciones.GetOperaciones(personal.OperacionId);
                    Fuerzas fuerza = _unitWorkFuerza.Fuerzas.GetFuerzas(personal.Fuerza.Id);
                    _unitWork.Add(MapperManual.MapearPersonalOperaciones(personal, fuerza, operacion));
                    _unitWork.Save();
                    AddPageAlerts(PageAlertType.Success, "Se ha cargado con exito el Personal de la Operación.");
                    return Redirect($"/Admin/Operaciones/Index?PersonalOperacionesId={personal.OperacionId}");
                }               
            }
            catch (Exception e)
            {
                AddPageAlerts(PageAlertType.Error, "Ha ocurrido un error al cargar el Personal de la Operació, intentelo nuevamente mas tarde.");
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Fuerza = _unitWork.Fuerzas.GetFuerzas().Select(g => new SelectListItem() { Text =  g.Nombre, Value = g.Id.ToString() });
            return PartialView("_Create", personal);
        }


        public IActionResult _Update(int Id)
        {
            ViewBag.Fuerza = _unitWork.Fuerzas.GetFuerzas().Select(g => new SelectListItem() { Text =  g.Nombre, Value = g.Id.ToString() });
            PersonalOperaciones personal = _unitWork.PersonalOperaciones.GetPersonalOperaciones(Id, p => p.Operacion);
            return PartialView("_Update", MapperManual.MapearPersonalOperacionesDTO(personal));
        }

        [HttpPost]
        public async Task<IActionResult> _Update(PersonalOperacionesDTO personal)
        {
            try
            {
                ModelState.Remove("OperacionId");
                if (ModelState.IsValid)
                {
                    Operaciones operacion = _unitWorkOperaciones.Operaciones.GetOperaciones(personal.OperacionId);
                    Fuerzas fuerza = _unitWorkFuerza.Fuerzas.GetFuerzas(personal.Fuerza.Id);
                    _unitWork.Update(MapperManual.MapearPersonalOperaciones(personal, fuerza, operacion));
                    _unitWork.Save();
                    AddPageAlerts(PageAlertType.Success, "Se ha editado el Personal de la Operación.");
                    return Redirect($"/Admin/Operaciones/Index?PersonalOperacionesId={personal.OperacionId}");
                }
            }
            catch (Exception e)
            {
                AddPageAlerts(PageAlertType.Error, "Ha ocurrido un error al editar el Personal de la Operación, intentelo nuevamente mas tarde.");
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Fuerza = _unitWork.Fuerzas.GetFuerzas().Select(g => new SelectListItem() { Text =  g.Nombre, Value = g.Id.ToString() });
            return PartialView("_Update", personal);
        }


        [HttpPost]
        public IActionResult Delete(int Id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unitWork.PersonalOperaciones.DeletePersonalOperaciones(Id);
                    return Ok(new
                    {
                        message = "Error al Borrar el Personal de la Operación",
                        errors = "",
                    });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    message = "Error al Borrar el Personal de la Operación",
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
