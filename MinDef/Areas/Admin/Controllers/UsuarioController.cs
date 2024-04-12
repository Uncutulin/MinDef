using AutoMapper;
using Commons.Controllers;
using DAL.DTOs.Admin;
using DAL.Models.Admin;
using DAL.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinDef.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MinDef.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsuarioController : MinDefBaseController
    {
        public UsuarioController(MinDefContext db, IContenedorTrabajo<Usuario> workSpace,
            IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
            _workSpace = workSpace;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult _UserDataTable()
        {
            var query = _workSpace.Usuarios.GetUsuarios(p => p.Persona);
            var listaUsuarioDTO = new List<UsuarioPersonaDTO>();

            foreach (var lista in query)
            {
                listaUsuarioDTO.Add(_mapper.Map<UsuarioPersonaDTO>(lista));
            }

            return DataTable(listaUsuarioDTO.AsQueryable());
        }

        //[HttpGet]
        public IActionResult _Create()
        {
            ViewBag.Mostrar = 0;
            return PartialView("_Create");
        }

        [HttpPost]
        public async Task<IActionResult> _Create(UsuarioPersonaDTO user, string checkTipoUsuario)
        {
            try
            {
                ModelState.Remove("Foto");
                if (ModelState.IsValid)
                {
                    Persona pers = _workSpace.Usuarios.MapearPersona(user);

                    if (!await _workSpace.Usuarios.CreateUserAsync(user, pers))
                    {                        
                        return PartialView("_Create", user);
                    }

                    AddPageAlerts(PageAlertType.Success, "Se ha creado con éxito el usuario.");
                    return RedirectToAction(nameof(Index));
                }               
            }
            catch (Exception e)
            {
                AddPageAlerts(PageAlertType.Error, "Ha ocurrido un error al crear el usuario, intentelo nuevamente mas tarde.");
                return RedirectToAction(nameof(Index));
            }

            //Retorno
            return PartialView("_Create", user); //<------------------ Aca lo retorno
        }


        public IActionResult _Update(string Id)
        {
            try
            {
                var usuario = _workSpace.Usuarios.GetUsuario(Id);
                var usuarioDto = new UsuarioPersonaUpdateDTO();
                usuarioDto = _mapper.Map<UsuarioPersonaUpdateDTO>(usuario);
                return PartialView(usuarioDto);
            }
            catch (Exception e)
            {
                AddPageAlerts(PageAlertType.Error, "Ha ocurrido un error al modificar el usuario, intentelo nuevamente mas tarde.");
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> _Update(UsuarioPersonaUpdateDTO user, string checkTipoUsuario)
        {
            ViewBag.Mostrar = 0;                         
            try
            {
                ModelState.Remove("FotoBase64");
                if (ModelState.IsValid)
                {
                    //var currentPassword = _workSpace.Usuarios.GetUsuario(user.Id).PasswordHash.ToString();
                    Persona pers = _workSpace.Usuarios.MapearPersonaUpdate(user);

                    if (!(await _workSpace.Usuarios.UpdateUserPersona(user,pers)))
                    {
                        return PartialView("_Update", user);
                    }

                    AddPageAlerts(PageAlertType.Success, "Se ha actualizado con éxito los datos del usuario.");
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception e)
            {
                AddPageAlerts(PageAlertType.Error, "Ha ocurrido un error al actualizar el usuario, intentelo nuevamente mas tarde.");
                return RedirectToAction(nameof(Index));
            }

            //Retorno
            return PartialView("_Update", user); //<------------------ Aca lo retorno
        }

        #region Agregar Imagen Usuario

        public IActionResult _AgregarImagenPerfil(string Id)
        {
            ViewBag.userId = Id;
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> _AgregarImagenPerfil(IFormFile file, string userId)
        {
            try
            {
                if (file == null || file.ContentType != "image/jpeg")
                {
                    AddPageAlerts(PageAlertType.Error, "Debe subir un Icono con la extensión JPG");
                }
                else
                {
                    if (await _workSpace.Usuarios.AgregarImagenPerfil(file, userId))
                    {
                        AddPageAlerts(PageAlertType.Success, $"Se agrego correctamente la imagen del usuario.");
                        return RedirectToAction(nameof(Index));
                    }
                    
                    AddPageAlerts(PageAlertType.Warning, $"Ha ocurrido un error, Debe cargar primero los datos personales del usuario (Nombre, apellido, Dni, Cuil, Fecha de nacimiento).");
                    return RedirectToAction(nameof(Index));
                }                
            }
            catch (System.Exception e)
            {
                AddPageAlerts(PageAlertType.Error, "Hubo un Error al subir la imagen. Intentelo nuevamente mas tarde.");
            }
            return RedirectToAction(nameof(Index));
        }

        #endregion

    }
}
