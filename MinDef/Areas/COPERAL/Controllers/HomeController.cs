using DAL.Models.Admin;
using DAL.Repository.Interface;
using DAL.Repository;
using Microsoft.AspNetCore.Mvc;
using MinDef.Areas.Admin.Controllers;
using MinDef.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Models.Comunes;
using DAL.DTOs.Admin;
using DAL.Mapper;

namespace MinDef.Areas.COPERAL.Controllers
{
    [Area("COPERAL")]
    public class HomeController : MinDefBaseController
    {
        protected MinDefContext _db;
        protected IContenedorTrabajo<Operaciones> _unitWork;
        protected string Codigo_SecrEstAsMil = "SecrEstAsMil";
        public HomeController(IContenedorTrabajo<Operaciones> unitWork, MinDefContext db)
        {
            this._db = db;
            _unitWork  = new ContenedorTrabajo<Operaciones>(db);
        }
        public IActionResult Index()
        {
            Operaciones operacion = _unitWork.Operaciones.GetOperaciones().FirstOrDefault();
            ViewBag.listaCardDTO = operacion;
            return View();
        }

        
        public IActionResult _OperacionDetallesIndex(string Operacion, string TipoMedios)
        {
            ViewBag.OperacionId = Operacion;
            ViewBag.TipoMedia = TipoMedios;
            return PartialView("_OperacionDetallesDataTable");
        }

        public IActionResult _OperacionDetallesDataTable(string Operacion, string TipoMedios)
        {
            var query = _unitWork.Medios.GetMediosByOperacionIdAndTipoMedio(Operacion, TipoMedios);
            var listaMediosDTO = new List<MediosDTO>();

            foreach (var lista in query)
            {
                listaMediosDTO.Add(MapperManual.MapearMediosDTO(lista));
            }
            return DataTable(listaMediosDTO.AsQueryable());
        }
    }
}
