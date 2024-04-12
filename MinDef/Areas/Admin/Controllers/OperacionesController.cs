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
using Microsoft.Azure.KeyVault.Models;
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
    public class OperacionesController : MinDefBaseController
    {

        protected IContenedorTrabajo<Operaciones> _unitWork;
        public OperacionesController(MinDefContext db, IContenedorTrabajo<Usuario> workSpace,
            IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
            _workSpace = workSpace;
            _unitWork = new ContenedorTrabajo<Operaciones>(db);
        }

        public IActionResult Index(string MedioId = null, string PersonalOperacionesId = null)
        {
            ViewBag.MediosId = MedioId;
            ViewBag.PersonalOperacionesId = PersonalOperacionesId;
            return View();
        }

        public IActionResult _OperacionesDataTableIndex()
        {           
            return PartialView("_OperacionesDataTable");
        }

        public IActionResult _OperacionesDataTable()
        {
            var query = _unitWork.Operaciones.GetOperaciones();
            var listaOperacionesDTO = new List<OperacionesDTO>();

            foreach (var lista in query)
            {
                listaOperacionesDTO.Add(MapperManual.MapearOperacionesDTO(lista));
            }
            return DataTable(listaOperacionesDTO.AsQueryable());
        }

        public IActionResult _Create()
        {
            return PartialView("_Create");
        }

        [HttpPost]
        public async Task<IActionResult> _Create(OperacionesDTO operacion, string color)
        {
            try
            {
                ModelState.Remove("Id");
                if (ModelState.IsValid)
                {
                    _unitWork.Add(MapperManual.MapearOperacionesyColor(operacion,color));
                    _unitWork.Save();
                    AddPageAlerts(PageAlertType.Success, "Se ha creado con éxito la Operación.");
                    return RedirectToAction(nameof(Index));
                }               
            }
            catch (Exception e)
            {
                AddPageAlerts(PageAlertType.Error, "Ha ocurrido un error al crear la Operación, intentelo nuevamente mas tarde.");
                return RedirectToAction(nameof(Index));
            }
            return PartialView("_Create", operacion);
        }


        public IActionResult _Update(int Id)
        {
            Operaciones operacion = _unitWork.Operaciones.GetOperaciones(Id);
            return PartialView("_Update", MapperManual.MapearOperacionesDTO(operacion));
        }

        [HttpPost]
        public async Task<IActionResult> _Update(OperacionesDTO operacion, string color)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unitWork.Update(MapperManual.MapearOperacionesyColor(operacion, color));
                    _unitWork.Save();
                    AddPageAlerts(PageAlertType.Success, "Se ha editado con éxito la Operación.");
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception e)
            {
                AddPageAlerts(PageAlertType.Error, "Ha ocurrido un error al editar la Operación, intentelo nuevamente mas tarde.");
                return RedirectToAction(nameof(Index));
            }
            return PartialView("_Update", operacion);
        }              
        
        
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unitWork.Operaciones.DeleteOperaciones(Id);
                    return Ok(new
                    {
                        message = "Error al Borrar la Operación",
                        errors = "",
                    });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    message = "Error al Borrar la Operación",
                    errors = e,
                });
            }

            return BadRequest(new
            {
                message = "Error al Borrar la Operación",
                errors = "",
            });
        }               
    }
}
