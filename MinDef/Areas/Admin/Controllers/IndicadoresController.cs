using AutoMapper;
using Commons.Controllers;
using Commons.Identity.Services;
using DAL.DTOs.Admin;
using DAL.Mapper;
using DAL.Models.Admin;
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
    public class IndicadoresController : MinDefBaseController
    {

        protected IContenedorTrabajo<IndicadoresBase> _unitWork;
        public IndicadoresController(MinDefContext db, IContenedorTrabajo<Usuario> workSpace,
            IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
            _workSpace = workSpace;
            _unitWork = new ContenedorTrabajo<IndicadoresBase>(db);
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult _IndicadoresDataTable()
        {
            var query = _unitWork.Indicadores.GetIndicadoresAll();
            var listaIndicadoresDTO = new List<IndicadoresDTO>();
            
            foreach (var lista in query)
            {
                listaIndicadoresDTO.Add(MapperManual.MapearIndicadorDTO(lista));
            }
            return DataTable(listaIndicadoresDTO.AsQueryable());
        }

        public IActionResult _Create()
        {
            ViewBag.TypeIndicador = _unitWork.Indicadores.GetTypeIndicadoresName().Select(g => new SelectListItem() { Text =  MapperManual.AgregarEspacioSegundaMayuscula(g), Value = g });
                ViewBag.TypeColor = new List<SelectListItem> {
                new SelectListItem { Text = "Rojo", Value = "#dd4b39" },
                new SelectListItem { Text = "Verde", Value = "#00a65a" },
                new SelectListItem { Text = "Celeste", Value = "#00c0ef" }
            };
            return PartialView("_Create");
        }

        [HttpPost]
        public async Task<IActionResult> _Create(IndicadoresDTO indicador)
        {
            try
            {
                ModelState.Remove("Id");
                if (ModelState.IsValid)
                {
                    AddIndicador(indicador);                
                    AddPageAlerts(PageAlertType.Success, "Se ha creado con éxito el Indicador.");
                    return RedirectToAction(nameof(Index));
                }               
            }
            catch (Exception e)
            {
                AddPageAlerts(PageAlertType.Error, "Ha ocurrido un error al crear el Indicador, intentelo nuevamente mas tarde.");
                return RedirectToAction(nameof(Index));
            }
            ViewBag.TypeIndicador = _unitWork.Indicadores.GetTypeIndicadoresName().Select(g => new SelectListItem() { Text = g, Value = g });
            return PartialView("_Create", indicador);
        }


        public IActionResult _Update(int Id)
        {
            ViewBag.TypeIndicador = _unitWork.Indicadores.GetTypeIndicadoresName().Select(g => new SelectListItem() { Text = MapperManual.AgregarEspacioSegundaMayuscula(g), Value = g });
            ViewBag.TypeColor = new List<SelectListItem> {
                 new SelectListItem { Text = "Rojo", Value = "#dd4b39" },
                new SelectListItem { Text = "Verde", Value = "#00a65a" },
                new SelectListItem { Text = "Celeste", Value = "#00c0ef" }
            };
            IndicadoresBase indicador = _unitWork.Indicadores.GetIndicador(Id);
            var eee = MapperManual.MapearIndicadorDTO(indicador);
            return PartialView("_Update", MapperManual.MapearIndicadorDTO(indicador));
        }


        [HttpPost]
        public IActionResult Delete(int Id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unitWork.Indicadores.DeleteIndicador(Id);
                    return Ok(new
                    {
                        message = "Error al Borrar el Indicador",
                        errors = "",
                    });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    message = "Error al Borrar el Indicador",
                    errors = e,
                });
            }

            return BadRequest(new
            {
                message = "Error al Borrar el Indicador",
                errors = "",
            });
        }
    

        [HttpPost]
        public async Task<IActionResult> _Update(IndicadoresDTO indicador, string CheckIndicarTendencia)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    indicador.IndicarTendencia = CheckIndicarTendencia=="on" ? true : false;
                    UpdateIndicador(indicador);
                    AddPageAlerts(PageAlertType.Success, "Se ha editado con éxito el Indicador.");
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception e)
            {
                AddPageAlerts(PageAlertType.Error, "Ha ocurrido un error al editar el Indicador, intentelo nuevamente mas tarde.");
                return RedirectToAction(nameof(Index));
            }
            ViewBag.TypeIndicador = _unitWork.Indicadores.GetTypeIndicadoresName().Select(g => new SelectListItem() { Text = g, Value = g });
            return PartialView("_Update", indicador);
        }

        private void AddIndicador(IndicadoresDTO indicador)
        {
            indicador.Icono = "nuevo.svg";
            indicador.Activo = true;
            if (indicador.Discriminador == "IndicadorPorcentaje")
            {

                IContenedorTrabajo<IndicadorPorcentaje> _unitWorkOther = new ContenedorTrabajo<IndicadorPorcentaje>(_db);
                int nroOrden = _unitWorkOther.Indicadores.GetIndicadoresAll().Select(x => x.Orden).DefaultIfEmpty().Max();
                indicador.Orden = nroOrden+1;
                _unitWorkOther.Add(MapperManual.MapearIndicadorPorcentaje(indicador));
                _unitWorkOther.Save();
            }
            else if (indicador.Discriminador == "IndicadorComunicacion")
            {

                IContenedorTrabajo<IndicadorComunicacion> _unitWorkOther = new ContenedorTrabajo<IndicadorComunicacion>(_db);
                int nroOrden = _unitWorkOther.Indicadores.GetIndicadoresAll().Select(x => x.Orden).DefaultIfEmpty().Max();
                indicador.Orden = nroOrden+1;
                _unitWorkOther.Add(MapperManual.MapearIndicadorComunicacion(indicador));
                _unitWorkOther.Save();
            }
            else if (indicador.Discriminador == "IndicadorNumero")
            {
                IContenedorTrabajo<IndicadorNumero> _unitWorkOther = new ContenedorTrabajo<IndicadorNumero>(_db);
                int nroOrden = _unitWorkOther.Indicadores.GetIndicadoresAll().Select(x => x.Orden).DefaultIfEmpty().Max();
                indicador.Orden = nroOrden+1;
                _unitWorkOther.Add(MapperManual.MapearIndicadorNumero(indicador));
                _unitWorkOther.Save();
            }
        }

        private void UpdateIndicador(IndicadoresDTO indicador)
        {
            if (indicador.Discriminador == "IndicadorPorcentaje")
            {
                IContenedorTrabajo<IndicadorPorcentaje> _unitWork = new ContenedorTrabajo<IndicadorPorcentaje>(_db);
                IndicadorPorcentaje IndicarOld = (IndicadorPorcentaje)_unitWork.Indicadores.GetIndicador(indicador.Id);
                indicador.ValorAnteriorTendencia = IndicarOld.Porcentaje != indicador.Porcentaje ? Convert.ToInt32(MapperManual.LimpiarCadena(IndicarOld.Porcentaje)) : IndicarOld.ValorAnteriorTendencia;
                _unitWork.Update(MapperManual.MapearIndicadorPorcentajeUpdate(indicador, IndicarOld));
                _unitWork.Save();
            }
            else if (indicador.Discriminador == "IndicadorComunicacion")
            {

                IContenedorTrabajo<IndicadorComunicacion> _unitWorkOther = new ContenedorTrabajo<IndicadorComunicacion>(_db);
                IndicadorComunicacion IndicarOld = (IndicadorComunicacion)_unitWork.Indicadores.GetIndicador(indicador.Id);
                _unitWorkOther.Update(MapperManual.MapearIndicadorComunicacionUpdate(indicador, IndicarOld));
                _unitWorkOther.Save();
            }
            else if (indicador.Discriminador == "IndicadorNumero")
            {
                IContenedorTrabajo<IndicadorNumero> _unitWorkOther = new ContenedorTrabajo<IndicadorNumero>(_db);
                IndicadorNumero IndicarOld = (IndicadorNumero)_unitWork.Indicadores.GetIndicador(indicador.Id);
                _unitWorkOther.Update(MapperManual.MapearIndicadorNumeroUpdate(indicador, IndicarOld));
                _unitWorkOther.Save();
            }
        }




    }
}
