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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinDef.Areas.Comunicacion.Controllers
{
    [Area("Comunicacion")]
    public class InteraccionesController : MinDefBaseController
    {
        protected IContenedorTrabajo<Interacciones> _unitWork;
        protected IContenedorTrabajo<Redes> _unitWorkRedes;
        protected IContenedorTrabajo<Ubicaciones> _unitWorkUbicacion;
        protected IContenedorTrabajo<TipoMediciones> _unitWorkTipoMedicion;
        public InteraccionesController(MinDefContext db, IContenedorTrabajo<Usuario> workSpace,
           IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
            _workSpace = workSpace;
            _unitWork = new ContenedorTrabajo<Interacciones>(db);
            _unitWorkUbicacion = new ContenedorTrabajo<Ubicaciones>(db);
            _unitWorkRedes = new ContenedorTrabajo<Redes>(db);
            _unitWorkTipoMedicion = new ContenedorTrabajo<TipoMediciones>(db);
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult _InteraccionesDataTable()
        {
            var query = _unitWork.Interacciones.GetInteracciones();
            var interaccionesDTO = new List<InteraccionesDTO>();

            foreach (var lista in query)
            {
                interaccionesDTO.Add(MapperManual.MapearInteraccionesDTO(lista));
            }
            return DataTable(interaccionesDTO.AsQueryable());
        }
        public IActionResult _Create(string Id)
        {
            ViewBag.Redes = _unitWork.Redes.GetRedes().Select(g => new SelectListItem() { Text = g.Nombre, Value = g.Id.ToString() });
            ViewBag.Ubicaciones = _unitWork.Ubicaciones.GetUbicaciones().Select(g => new SelectListItem() { Text = g.Nombre, Value = g.Id.ToString() });
            ViewBag.TipoMediciones = _unitWork.TipoMediciones.GetTipoMediciones().Select(g => new SelectListItem() { Text = g.Nombre, Value = g.Id.ToString() });
            return PartialView("_Create");
        }
        [HttpPost]
        public async Task<IActionResult> _Create(InteraccionesDTO interacciones)
        {
            try
            {
                ModelState.Remove("Id");
                if (ModelState.IsValid)
                {
                    interacciones.Id = 0;
                    Redes red = _unitWorkRedes.Redes.GetRedes(interacciones.Red.Id);
                    Ubicaciones ubicacion = _unitWorkUbicacion.Ubicaciones.GetUbicaciones(interacciones.Ubicacion.Id);
                    TipoMediciones tipoMediciones = _unitWorkTipoMedicion.TipoMediciones.GetTipoMediciones(interacciones.TipoMedicion.Id);
                    _unitWork.Add(MapperManual.MapearInteracciones(interacciones, ubicacion, red,tipoMediciones));
                    _unitWork.Save();
                    AddPageAlerts(PageAlertType.Success, "Se ha creado con éxito la interaccion.");
                    return Redirect($"/Comunicacion/Interacciones/Index?InteraccionId={interacciones.Id}");
                }
            }
            catch (Exception e)
            {
                AddPageAlerts(PageAlertType.Error, "Ha ocurrido un error al crear la interracion, intentelo nuevamente mas tarde.");
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Red = _unitWork.Redes.GetRedes().Select(g => new SelectListItem() { Text = g.Nombre, Value = g.Id.ToString() });
            ViewBag.Ubicaciones = _unitWork.Ubicaciones.GetUbicaciones().Select(g => new SelectListItem() { Text = g.Nombre, Value = g.Id.ToString() });
            ViewBag.TipoMediciones = _unitWork.TipoMediciones.GetTipoMediciones().Select(g => new SelectListItem() { Text = g.Nombre, Value = g.Id.ToString() });
            return PartialView("_Create", interacciones);
        }
        public IActionResult _Update(int Id)
        {
            ViewBag.Redes = _unitWork.Redes.GetRedes().Select(g => new SelectListItem() { Text = g.Nombre, Value = g.Id.ToString() });
            ViewBag.Ubicaciones = _unitWork.Ubicaciones.GetUbicaciones().Select(g => new SelectListItem() { Text = g.Nombre, Value = g.Id.ToString() });
            ViewBag.TipoMediciones = _unitWork.TipoMediciones.GetTipoMediciones().Select(g => new SelectListItem() { Text = g.Nombre, Value = g.Id.ToString() });
            Interacciones interacciones = _unitWork.Interacciones.GetInteracciones(Id);
            return PartialView("_Update", MapperManual.MapearInteraccionesDTO(interacciones));
        }
        [HttpPost]
        public async Task<IActionResult> _Update(InteraccionesDTO interacciones)
        {
            try
            {
                ModelState.Remove("Id");
                if (ModelState.IsValid)
                {
                    Redes red = _unitWorkRedes.Redes.GetRedes(interacciones.Red.Id);
                    Ubicaciones ubicacion = _unitWorkUbicacion.Ubicaciones.GetUbicaciones(interacciones.Ubicacion.Id);
                    TipoMediciones tipomedicion = _unitWorkTipoMedicion.TipoMediciones.GetTipoMediciones(interacciones.TipoMedicion.Id);
                    _unitWork.Update(MapperManual.MapearInteracciones(interacciones, ubicacion,red, tipomedicion));
                    _unitWork.Save();
                    AddPageAlerts(PageAlertType.Success, "Se ha editado con éxito la tendencia.");
                    return Redirect($"/Comunicacion/Interacciones/Index?InteraccionesId={interacciones.Id}");
                }
            }
            catch (Exception e)
            {
                AddPageAlerts(PageAlertType.Error, "Ha ocurrido un error al editar la interaccion, intentelo nuevamente mas tarde.");
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Redes = _unitWork.Redes.GetRedes().Select(g => new SelectListItem() { Text = g.Nombre, Value = g.Id.ToString() });
            ViewBag.Ubicaciones = _unitWork.Ubicaciones.GetUbicaciones().Select(g => new SelectListItem() { Text = g.Nombre, Value = g.Id.ToString() });
            ViewBag.TipoMediciones = _unitWork.TipoMediciones.GetTipoMediciones().Select(g => new SelectListItem() { Text = g.Nombre, Value = g.Id.ToString() });
            return PartialView("_Update", interacciones);
        }
    }
}
