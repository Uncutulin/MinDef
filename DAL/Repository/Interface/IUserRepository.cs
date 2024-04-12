using DAL.DTOs.Admin;
using DAL.Models.Admin;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL.Repository.Interface
{
    public interface IUserRepository 
    {
        /// <summary>
        /// Deslogue al usuario y lo lleva al login
        /// </summary>
        /// <returns>Lo redirecciona a la pantalla de login</returns>
        void Logout();

        /// <summary>
        /// Obtiene todos los usuarios creados
        /// </summary>
        /// <returns></returns>
        List<Usuario> GetUsuarios();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        List<Usuario> GetUsuarios(params Expression<Func<Usuario, object>>[] includes);

        /// <summary>
        /// Obtiene un usuario en especifico
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Usuario GetUsuario(string userId);

        /// <summary>
        /// Agrega un usuario
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        bool AddUsuario(Usuario user);

        /// <summary>
        /// Actualiza el usuario
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        void UpdateUsuario(Usuario user);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteUsuarioPermante(string id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteUsuarioBajaLogica(string id);

        /// <summary>
        ///  habilitar usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool EnableUsuario(string id);
        /// <summary>
        ///  Crear usuario
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<bool> CreateUserAsync(UsuarioPersonaDTO user, Persona persona);

        Task<bool> UpdateUserPersona(UsuarioPersonaUpdateDTO user, Persona persona);

        /// <summary>
        /// Agregar Imagen de perfil
        /// </summary>
        /// <param name="file"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<bool> AgregarImagenPerfil(IFormFile file, string userId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="us"></param>
        /// <returns></returns>
        Persona MapearPersona(UsuarioPersonaDTO us);
        Persona MapearPersonaUpdate(UsuarioPersonaUpdateDTO us);

        void AddPersona(Persona pers);
        void UpdatePersona(Persona pers);
    }
}