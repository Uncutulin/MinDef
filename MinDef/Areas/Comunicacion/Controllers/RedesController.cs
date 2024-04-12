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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinDef.Areas.Comunicacion.Controllers
{
    [Area("Comunicacion")]
    public class RedesController : MinDefBaseController
    {
        protected IContenedorTrabajo<Redes> _unitWork;
        public RedesController(MinDefContext db, IContenedorTrabajo<Usuario> workSpace,
           IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
            _workSpace = workSpace;
            _unitWork = new ContenedorTrabajo<Redes>(db);
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult _RedesDataTable()
        {
            var query = _unitWork.Redes.GetRedes();
            var listaRedesDTO = new List<RedesDTO>();

            foreach (var lista in query)
            {
                listaRedesDTO.Add(MapperManual.MapearRedesDTO(lista));
            }
            return DataTable(listaRedesDTO.AsQueryable());
        }
        public IActionResult _Create()
        {
            return PartialView("_Create");
        }
        [HttpPost]
        public async Task<IActionResult> _Create(RedesDTO redes)
        {
            try
            {
                ModelState.Remove("Id");
                if (ModelState.IsValid)
                {
                    _unitWork.Add(MapperManual.MapearRedes(redes));
                    _unitWork.Save();
                    AddPageAlerts(PageAlertType.Success, "Se ha creado con éxito la red Social.");
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception e)
            {
                AddPageAlerts(PageAlertType.Error, "Ha ocurrido un error al crear la Red Social, intentelo nuevamente mas tarde.");
                return RedirectToAction(nameof(Index));
            }
            return PartialView("_Create", redes);
        }

        public IActionResult _Update(int Id)
        {
            Redes redes = _unitWork.Redes.GetRedes(Id);
            return PartialView("_Update", MapperManual.MapearRedesDTO(redes));
        }

        [HttpPost]
        public async Task<IActionResult> _Update(RedesDTO redes)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unitWork.Update(MapperManual.MapearRedes(redes));
                    _unitWork.Save();
                    AddPageAlerts(PageAlertType.Success, "Se ha editado con éxito Red Social.");
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception e)
            {
                AddPageAlerts(PageAlertType.Error, "Ha ocurrido un error al editar la Red Social, intentelo nuevamente mas tarde.");
                return RedirectToAction(nameof(Index));
            }

            return PartialView("_Update", redes);
        }
    }
}
