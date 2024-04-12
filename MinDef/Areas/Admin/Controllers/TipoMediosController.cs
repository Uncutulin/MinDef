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
    public class TipoMediosController : MinDefBaseController
    {

        protected IContenedorTrabajo<TipoMedios> _unitWork;
        public TipoMediosController(MinDefContext db, IContenedorTrabajo<Usuario> workSpace,
            IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
            _workSpace = workSpace;
            _unitWork = new ContenedorTrabajo<TipoMedios>(db);
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult _TipoMediosDataTable()
        {
            var query = _unitWork.TipoMedios.GetTipoMedios();
            var listaTipoMediosDTO = new List<TipoMediosDTO>();

            foreach (var lista in query)
            {
                listaTipoMediosDTO.Add(MapperManual.MapearTipoMediosDTO(lista));
            }
            return DataTable(listaTipoMediosDTO.AsQueryable());
        }

        public IActionResult _Create()
        {
            return PartialView("_Create");
        }

        [HttpPost]
        public async Task<IActionResult> _Create(TipoMediosDTO tipoMedios)
        {
            try
            {
                ModelState.Remove("Id");
                if (ModelState.IsValid)
                {
                    _unitWork.Add(MapperManual.MapearTipoMedios(tipoMedios));
                    _unitWork.Save();
                    AddPageAlerts(PageAlertType.Success, "Se ha creado con éxito el Tipo Medio.");
                    return RedirectToAction(nameof(Index));
                }               
            }
            catch (Exception e)
            {
                AddPageAlerts(PageAlertType.Error, "Ha ocurrido un error al crear el Tipo Medio, intentelo nuevamente mas tarde.");
                return RedirectToAction(nameof(Index));
            }
            return PartialView("_Create", tipoMedios);
        }


        public IActionResult _Update(int Id)
        {
            TipoMedios tipoMedios = _unitWork.TipoMedios.GetTipoMedios(Id);
            return PartialView("_Update", MapperManual.MapearTipoMediosDTO(tipoMedios));
        }

        [HttpPost]
        public async Task<IActionResult> _Update(TipoMediosDTO tipoMedios)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unitWork.Update(MapperManual.MapearTipoMedios(tipoMedios));
                    _unitWork.Save();
                    AddPageAlerts(PageAlertType.Success, "Se ha editado con éxito el Tipo Medio.");
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception e)
            {
                AddPageAlerts(PageAlertType.Error, "Ha ocurrido un error al editar el Tipo Medio, intentelo nuevamente mas tarde.");
                return RedirectToAction(nameof(Index));
            }
            return PartialView("_Update", tipoMedios);
        }               
    }
}
