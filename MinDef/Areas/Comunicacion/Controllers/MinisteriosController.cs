using AutoMapper;
using DAL.Models.Admin;
using DAL.Models.Comunicacion;
using DAL.Repository.Interface;
using DAL.Repository;
using Microsoft.AspNetCore.Mvc;
using MinDef.Areas.Admin.Controllers;
using MinDef.Data;
using DAL.DTOs.Comunicacion;
using DAL.Mapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace MinDef.Areas.Comunicacion.Controllers
{
    [Area("Comunicacion")]
    public class MinisteriosController : MinDefBaseController
    {
        protected IContenedorTrabajo<Ministerios> _unitWork;
        public MinisteriosController(MinDefContext db, IContenedorTrabajo<Usuario> workSpace,
           IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
            _workSpace = workSpace;
            _unitWork = new ContenedorTrabajo<Ministerios>(db);
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult _MinisteriosDataTable()
        {
            var query = _unitWork.Ministerios.GetMinisterios();
            var listaMinisteriosDTO = new List<MinisteriosDTO>();

            foreach (var lista in query)
            {
                listaMinisteriosDTO.Add(MapperManual.MapearMinisteriosDTO(lista));
            }
            return DataTable(listaMinisteriosDTO.AsQueryable());
        }

        public IActionResult _Create()
        {
            return PartialView("_Create");
        }
        [HttpPost]
        public async Task<IActionResult> _Create(MinisteriosDTO ministerios)
        {
            try
            {
                ModelState.Remove("Id");
                if (ModelState.IsValid)
                {
                    _unitWork.Add(MapperManual.MapearMinisterios(ministerios));
                    _unitWork.Save();
                    AddPageAlerts(PageAlertType.Success, "Se ha creado con éxito el Ministerio.");
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception e)
            {
                AddPageAlerts(PageAlertType.Error, "Ha ocurrido un error al crear el Ministerio, intentelo nuevamente mas tarde.");
                return RedirectToAction(nameof(Index));
            }
            return PartialView("_Create", ministerios);
        }

        public IActionResult _Update(int Id)
        {
            Ministerios ministerios = _unitWork.Ministerios.GetMinisterios(Id);
            return PartialView("_Update", MapperManual.MapearMinisteriosDTO(ministerios));
        }

        [HttpPost]
        public async Task<IActionResult> _Update(MinisteriosDTO ministerio)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unitWork.Update(MapperManual.MapearMinisterios(ministerio));
                    _unitWork.Save();
                    AddPageAlerts(PageAlertType.Success, "Se ha editado con éxito el Ministerio.");
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception e)
            {
                AddPageAlerts(PageAlertType.Error, "Ha ocurrido un error al editar el Ministerio, intentelo nuevamente mas tarde.");
                return RedirectToAction(nameof(Index));
            }

            return PartialView("_Update", ministerio);
        }
    }
}
