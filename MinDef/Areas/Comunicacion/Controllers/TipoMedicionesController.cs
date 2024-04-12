using AutoMapper;
using DAL.DTOs.Comunicacion;
using DAL.Mapper;
using DAL.Models.Admin;
using DAL.Models.Comunicacion;
using DAL.Repository;
using DAL.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MinDef.Areas.Admin.Controllers;
using MinDef.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using DAL.DTOs.Admin;
using DAL.Models.Comunes;

namespace MinDef.Areas.Comunicacion.Controllers
{
    [Area ("Comunicacion")]
    public class TipoMedicionesController : MinDefBaseController
    {
        protected IContenedorTrabajo<TipoMediciones> _unitWork;
        public TipoMedicionesController(MinDefContext db, IContenedorTrabajo<Usuario> workSpace,
           IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
            _workSpace = workSpace;
            _unitWork = new ContenedorTrabajo<TipoMediciones>(db);
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult _TipoMedicionesDataTable()
        {
            var query = _unitWork.TipoMediciones.GetTipoMediciones();
            var listaTipoMedicionesDTO = new List<TipoMedicionesDTO>();

            foreach (var lista in query)
            {
                listaTipoMedicionesDTO.Add(MapperManual.MapearTipoMedicionesDTO(lista));
            }
            return DataTable(listaTipoMedicionesDTO.AsQueryable());
        }

        public IActionResult _Create()
        {
            return PartialView("_Create");
        }

        [HttpPost]
        public async Task<IActionResult> _Create(TipoMedicionesDTO medicion)
        {
            try
            {
                ModelState.Remove("Id");
                if (ModelState.IsValid)
                {
                    _unitWork.Add(MapperManual.MapearTipoMediciones(medicion));
                    _unitWork.Save();
                    AddPageAlerts(PageAlertType.Success, "Se ha creado con éxito la Metrica.");
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception e)
            {
                AddPageAlerts(PageAlertType.Error, "Ha ocurrido un error al crear la Metrica, intentelo nuevamente mas tarde.");
                return RedirectToAction(nameof(Index));
            }
            return PartialView("_Create", medicion);
        }
       
        public IActionResult _Update(int Id)
        {
            TipoMediciones tipomedicion = _unitWork.TipoMediciones.GetTipoMediciones(Id);
            return PartialView("_Update", MapperManual.MapearTipoMedicionesDTO(tipomedicion));
        }

        [HttpPost]
        public async Task<IActionResult> _Update(TipoMedicionesDTO tipomedicion)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unitWork.Update(MapperManual.MapearTipoMediciones(tipomedicion));
                    _unitWork.Save();
                    AddPageAlerts(PageAlertType.Success, "Se ha editado con éxito la Metrica.");
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception e)
            {
                AddPageAlerts(PageAlertType.Error, "Ha ocurrido un error al editar la Metrica, intentelo nuevamente mas tarde.");
                return RedirectToAction(nameof(Index));
            }

            return PartialView("_Update", tipomedicion);
        }


    }
}
