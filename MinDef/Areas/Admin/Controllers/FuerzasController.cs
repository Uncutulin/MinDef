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
    public class FuerzasController : MinDefBaseController
    {

        protected IContenedorTrabajo<Fuerzas> _unitWork;
        public FuerzasController(MinDefContext db, IContenedorTrabajo<Usuario> workSpace,
            IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
            _workSpace = workSpace;
            _unitWork = new ContenedorTrabajo<Fuerzas>(db);
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult _FuerzasDataTable()
        {
            var query = _unitWork.Fuerzas.GetFuerzas();
            var listaFuerzasDTO = new List<FuerzasDTO>();

            foreach (var lista in query)
            {
                listaFuerzasDTO.Add(MapperManual.MapearFuerzaDTO(lista));
            }
            return DataTable(listaFuerzasDTO.AsQueryable());
        }

        public IActionResult _Create()
        {
            return PartialView("_Create");
        }

        [HttpPost]
        public async Task<IActionResult> _Create(FuerzasDTO fuerza)
        {
            try
            {
                ModelState.Remove("Id");
                if (ModelState.IsValid)
                {
                    _unitWork.Add(MapperManual.MapearFuerza(fuerza));
                    _unitWork.Save();          
                    AddPageAlerts(PageAlertType.Success, "Se ha creado con éxito la Fuerza.");
                    return RedirectToAction(nameof(Index));
                }               
            }
            catch (Exception e)
            {
                AddPageAlerts(PageAlertType.Error, "Ha ocurrido un error al crear la Fuerza, intentelo nuevamente mas tarde.");
                return RedirectToAction(nameof(Index));
            }
            return PartialView("_Create", fuerza);
        }


        public IActionResult _Update(int Id)
        {
            Fuerzas fuerza = _unitWork.Fuerzas.GetFuerzas(Id);
            return PartialView("_Update", MapperManual.MapearFuerzaDTO(fuerza));
        }

        [HttpPost]
        public async Task<IActionResult> _Update(FuerzasDTO fuerza)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unitWork.Update(MapperManual.MapearFuerza(fuerza));
                    _unitWork.Save();
                    AddPageAlerts(PageAlertType.Success, "Se ha editado con éxito la Fuerza.");
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception e)
            {
                AddPageAlerts(PageAlertType.Error, "Ha ocurrido un error al editar la Fuerza, intentelo nuevamente mas tarde.");
                return RedirectToAction(nameof(Index));
            }
            return PartialView("_Update", fuerza);
        }               
    }
}
