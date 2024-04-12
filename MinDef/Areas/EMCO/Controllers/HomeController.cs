using AutoMapper;
using DAL.DTOs.Admin;
using DAL.Mapper;
using DAL.Models.Comunes;
using DAL.Repository;
using DAL.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using MinDef.Areas.Admin.Controllers;
using MinDef.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinDef.Areas.EMCO.Controllers
{
    [Area("EMCO")]
    public class HomeController : MinDefBaseController
    {
        protected MinDefContext _db;
        protected IContenedorTrabajo<Operaciones> _unitWork;
        protected string Codigo_SecrEstAsMil = "SecrEstAsMil";
        public HomeController(MinDefContext db)
        {
            this._db = db;
            _unitWork = new ContenedorTrabajo<Operaciones>(db);
        }
        public IActionResult Index()
        {
            var operaciones = _unitWork.Operaciones.GetOperaciones();
            //ViewBag.listaCardDTO = operacion;

            List<OperacionesBaseDTO> listOperacionesDTO = new List<OperacionesBaseDTO>();

            foreach (var operacion in operaciones)
            {
                listOperacionesDTO.Add(MapperManual.MapearOperacionesBaseDTO(operacion));
            }

            return View(listOperacionesDTO);
        }


        [HttpGet]
        public List<OperacionesMapaDTO> ListadoOperaciones() 
        {
            var operaciones = _unitWork.Operaciones.GetOperaciones();
            var operacionesDTO = new List<OperacionesMapaDTO>();    
            foreach (var item in operaciones)
            {
                var operacionDTO = new OperacionesMapaDTO
                {
                    Nombre = item.Nombre,
                    Descripcion = item.Descripcion,
                    Longitud = item.Longitud,
                    Latitud = item.Latitud,
                    Color = item.Color
                };
                operacionesDTO.Add(operacionDTO);  
            }
            return operacionesDTO; 
        }

    }
}
