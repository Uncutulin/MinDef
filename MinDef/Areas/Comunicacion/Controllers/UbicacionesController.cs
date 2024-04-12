using AutoMapper;
using DAL.Models.Admin;
using DAL.Models.Comunicacion;
using DAL.Repository.Interface;
using DAL.Repository;
using Microsoft.AspNetCore.Mvc;
using MinDef.Data;
using MinDef.Areas.Admin.Controllers;
using DAL.DTOs.Comunicacion;
using DAL.Mapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace MinDef.Areas.Comunicacion.Controllers
{
    [Area("Comunicacion")]
    public class UbicacionesController : MinDefBaseController
    {

        protected IContenedorTrabajo<Ubicaciones> _unitWork;
        public UbicacionesController(MinDefContext db, IContenedorTrabajo<Usuario> workSpace,
           IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
            _workSpace = workSpace;
            _unitWork = new ContenedorTrabajo<Ubicaciones>(db);
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult _UbicacionesDataTable()
        {
            var query = _unitWork.Ubicaciones.GetUbicaciones();
            var ubicacionesDTO = new List<UbicacionesDTO>();

            foreach (var lista in query)
            {
                ubicacionesDTO.Add(MapperManual.MapearUbicacionesDTO(lista));
            }
            return DataTable(ubicacionesDTO.AsQueryable());
        }
        public IActionResult _Create()
        {
            return PartialView("_Create");
        }
        [HttpPost]
        public async Task<IActionResult> _Create(UbicacionesDTO ubis)
        {
            try
            {
                ModelState.Remove("Id");
                if (ModelState.IsValid)
                {
                    _unitWork.Add(MapperManual.MapearUbicaciones(ubis));
                    _unitWork.Save();
                    AddPageAlerts(PageAlertType.Success, "Se ha creado con éxito la Ubicación.");
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception e)
            {
                AddPageAlerts(PageAlertType.Error, "Ha ocurrido un error al crear la Ubicación, intentelo nuevamente mas tarde.");
                return RedirectToAction(nameof(Index));
            }
            return PartialView("_Create", ubis);
        }

        public IActionResult _Update(int Id)
        {
            Ubicaciones ubis = _unitWork.Ubicaciones.GetUbicaciones(Id);
            return PartialView("_Update", MapperManual.MapearUbicacionesDTO(ubis));
        }

        [HttpPost]
        public async Task<IActionResult> _Update(UbicacionesDTO ubis)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unitWork.Update(MapperManual.MapearUbicaciones(ubis));
                    _unitWork.Save();
                    AddPageAlerts(PageAlertType.Success, "Se ha editado con éxito la Ubicación.");
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception e)
            {
                AddPageAlerts(PageAlertType.Error, "Ha ocurrido un error al editar la Ubicación, intentelo nuevamente mas tarde.");
                return RedirectToAction(nameof(Index));
            }

            return PartialView("_Update", ubis);
        }
    }
}
