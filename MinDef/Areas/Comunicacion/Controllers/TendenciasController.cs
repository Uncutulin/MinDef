using AutoMapper;
using DAL.DTOs.Admin;
using DAL.DTOs.Comunicacion;
using DAL.Mapper;
using DAL.Models.Admin;
using DAL.Models.Comunes;
using DAL.Models.Comunicacion;
using DAL.Repository;
using DAL.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MinDef.Areas.Admin.Controllers;
using MinDef.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinDef.Areas.Comunicacion.Controllers
{
    [Area("Comunicacion")]
    public class TendenciasController : MinDefBaseController
    {
        protected IContenedorTrabajo<Tendencias> _unitWork;
        protected IContenedorTrabajo<Redes> _unitWorkRedes;
        protected IContenedorTrabajo<Ministerios> _unitWorkMinisterio;
        public TendenciasController(MinDefContext db, IContenedorTrabajo<Usuario> workSpace,
           IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
            _workSpace = workSpace;
            _unitWork = new ContenedorTrabajo<Tendencias>(db);
            _unitWorkMinisterio = new ContenedorTrabajo<Ministerios>(db);
            _unitWorkRedes = new ContenedorTrabajo<Redes>(db);
           
        }
            public IActionResult Index()
        {
            return View();
        }
        public IActionResult _TendenciasDataTable()
        {
            var query = _unitWork.Tendencias.GetTendencias();
            var tendenciasDTO = new List<TendenciasDTO>();

            foreach (var lista in query)
            {
                tendenciasDTO.Add(MapperManual.MapearTendenciasDTO(lista));
            }
            return DataTable(tendenciasDTO.AsQueryable());
        }
        public IActionResult _Create(string Id)
        {
            ViewBag.Redes = _unitWork.Redes.GetRedes().Select(g => new SelectListItem() { Text = g.Nombre, Value = g.Id.ToString() });
            ViewBag.Ministerios = _unitWork.Ministerios.GetMinisterios().Select(g => new SelectListItem() { Text = g.Nombre, Value = g.Id.ToString() });
            return PartialView("_Create");
        }

        [HttpPost]
        public async Task<IActionResult> _Create(TendenciasDTO tendencias)
        {
            try
            {
                ModelState.Remove("Id");
                if (ModelState.IsValid)
                {
                    tendencias.Id = 0;
                    Redes red = _unitWorkRedes.Redes.GetRedes(tendencias.Red.Id);
                    Ministerios ministerio = _unitWorkMinisterio.Ministerios.GetMinisterios(tendencias.Ministerio.Id);
                    _unitWork.Add(MapperManual.MapearTendencias(tendencias, ministerio, red));
                    _unitWork.Save();
                    AddPageAlerts(PageAlertType.Success, "Se ha creado con éxito la tendencia.");
                    return Redirect($"/Comunicacion/Tendencias/Index?TendenciId={tendencias.Id}");
                }
            }
            catch (Exception e)
            {
                AddPageAlerts(PageAlertType.Error, "Ha ocurrido un error al crear la tendencia, intentelo nuevamente mas tarde.");
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Red = _unitWork.Redes.GetRedes().Select(g => new SelectListItem() { Text = g.Nombre, Value = g.Id.ToString() });
            ViewBag.Ministerios = _unitWork.Ministerios.GetMinisterios().Select(g => new SelectListItem() { Text = g.Nombre, Value = g.Id.ToString() });
            return PartialView("_Create", tendencias);
        }


        public IActionResult _Update(int Id)
        {
            ViewBag.Redes = _unitWork.Redes.GetRedes().Select(g => new SelectListItem() { Text = g.Nombre, Value = g.Id.ToString() });
            ViewBag.Ministerios = _unitWork.Ministerios.GetMinisterios().Select(g => new SelectListItem() { Text = g.Nombre, Value = g.Id.ToString() });
            Tendencias tendencias = _unitWork.Tendencias.GetTendencias(Id);
            return PartialView("_Update", MapperManual.MapearTendenciasDTO(tendencias));
        }

        [HttpPost]
        public async Task<IActionResult> _Update(TendenciasDTO tendencias)
        {
            try
            {
                ModelState.Remove("Id");
                if (ModelState.IsValid)
                {
                    Redes red = _unitWorkRedes.Redes.GetRedes(tendencias.Red.Id);
                    Ministerios ministerio = _unitWorkMinisterio.Ministerios.GetMinisterios(tendencias.Ministerio.Id);
                    _unitWork.Update(MapperManual.MapearTendencias(tendencias, ministerio, red));
                    _unitWork.Save();
                    AddPageAlerts(PageAlertType.Success, "Se ha editado con éxito la tendencia.");
                    return Redirect($"/Comunicacion/Tendencias/Index?TendenciaId={tendencias.Id}");
                }
            }
            catch (Exception e)
            {
                AddPageAlerts(PageAlertType.Error, "Ha ocurrido un error al editar la tendencia, intentelo nuevamente mas tarde.");
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Redes = _unitWork.Redes.GetRedes().Select(g => new SelectListItem() { Text = g.Nombre, Value = g.Id.ToString() });
            ViewBag.Ministerios = _unitWork.Ministerios.GetMinisterios().Select(g => new SelectListItem() { Text = g.Nombre, Value = g.Id.ToString() });
            return PartialView("_Update", tendencias);
        }
    }
}
