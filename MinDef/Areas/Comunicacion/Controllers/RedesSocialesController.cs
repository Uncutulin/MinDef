using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DAL.DTOs.Comunicacion;
using DAL.Mapper;
using DAL.Models.Admin;
using DAL.Models.Comunicacion;
using DAL.Repository;
using DAL.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using MinDef.Areas.Admin.Controllers;
using MinDef.Data;

namespace MinDef.Areas.Comunicacion.Controllers
{
    [Area("Comunicacion")]
    public class RedesSocialesController : MinDefBaseController
    {
        private readonly IContenedorTrabajo<Interacciones> _unitWork;
        private readonly IContenedorTrabajo<Tendencias> _unitWorkTendencias;
        private readonly IMapper _mapper;

        public RedesSocialesController(MinDefContext db, IContenedorTrabajo<Usuario> workSpace, IMapper mapper)
        {
            _mapper = mapper;
            _unitWork = new ContenedorTrabajo<Interacciones>(db);
            _unitWorkTendencias = new ContenedorTrabajo<Tendencias>(db);
        }

        public IActionResult Index()
        {
            //var listaInteraccionesDTO = ObtenerInteracciones();
            //var listaTendenciasDTO = ObtenerTendencias();

            //ViewBag.Tendencias = listaInteraccionesDTO.GroupBy(i => i.RedNombre)
            //                                            .ToDictionary(g => g.Key, g => ObtenerTendenciasPorRed(g.Key));

            //var ultimasTendencias = ObtenerUltimasTendenciasPorMinisterio(listaTendenciasDTO);

            //var model = new Tuple<List<InteraccionesDTO>, List<TendenciasDTO>>(listaInteraccionesDTO, ultimasTendencias);

            return View();
        }

        public IActionResult _InteracionesTendencias()
        {

            var listaInteraccionesDTO = ObtenerInteracciones();
            var listaTendenciasDTO = ObtenerTendencias();

            ViewBag.Tendencias = listaInteraccionesDTO.GroupBy(i => i.RedNombre)
                                                        .ToDictionary(g => g.Key, g => ObtenerTendenciasPorRed(g.Key));

            var ultimasTendencias = ObtenerUltimasTendenciasPorMinisterio(listaTendenciasDTO);

            var model = new Tuple<List<InteraccionesDTO>, List<TendenciasDTO>>(listaInteraccionesDTO, ultimasTendencias);

            return PartialView(model);
        }

            private List<InteraccionesDTO> ObtenerInteracciones()
        {
            var interacciones = _unitWork.Interacciones.GetInteracciones();
            var listaInteraccionesDTO = interacciones.Select(i => MapperManual.MapearInteraccionesDTO(i))
                                                     .OrderBy(i => i.Id)
                                                     .ToList();
            return listaInteraccionesDTO;
        }

        private List<TendenciasDTO> ObtenerTendencias()
        {
            var tendencias = _unitWorkTendencias.Tendencias.GetTendencias();
            var listaTendenciasDTO = tendencias.Select(t => MapperManual.MapearTendenciasDTO(t))
                                                .OrderBy(t => t.Id)
                                                .ToList();
            return listaTendenciasDTO;
        }

        public List<TendenciasDTO> ObtenerTendenciasPorRed(string redNombre)
        {
            var tendencias = _unitWorkTendencias.Tendencias.GetTendencias().Where(t => t.Red.Nombre == redNombre);
            var ultimasTendenciasPorMinisterio = tendencias
                .GroupBy(t => t.Ministerio.Nombre)
                .Select(g => g.OrderByDescending(t => t.Fecha).FirstOrDefault())
                .ToList();

            var listaTendenciasDTO = ultimasTendenciasPorMinisterio
                .Select(t => MapperManual.MapearTendenciasDTO(t))
                .ToList();

            return listaTendenciasDTO;
        }

        [HttpGet]
        public IActionResult ObtenerInteraccionesDeRedesSociales(string red)
        {
            try
            {
                var query = _unitWork.Interacciones.GetInteracciones().Where(i => i.Red.Nombre == red);
                var listaInteraccionesDTO = query.Select(lista => MapperManual.MapearInteraccionesDTO(lista)).OrderBy(i => i.Fecha).ToList();

                return Json(listaInteraccionesDTO); // Devolver los datos en formato JSON
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción y devolver un error apropiado si es necesario
                return StatusCode(500, $"Error al obtener interacciones: {ex.Message}");
            }
        }

        private List<TendenciasDTO> ObtenerUltimasTendenciasPorMinisterio(List<TendenciasDTO> tendencias)
        {
            var ultimasTendencias = tendencias.GroupBy(t => t.Ministerio.Nombre)
                                              .Select(g => g.OrderByDescending(t => t.Fecha).FirstOrDefault())
                                              .ToList();
            return ultimasTendencias;
        }
    }
}
