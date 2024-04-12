using Commons.Identity.Services;
using DAL.DTOs.Admin;
using DAL.Models.Admin;
using DAL.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MinDef.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        private MinDefContext _db;
        private readonly SignInService<Usuario> _signInManager;
        private readonly UserManager<Usuario> _UserManager;

        public UserRepository(MinDefContext db, SignInService<Usuario> signInManager ,
            UserManager<Usuario> userManager)
        {
            this._UserManager = userManager;
            this._signInManager = signInManager;
            this._db = db;
        }
        public bool AddUsuario(Usuario user)
        {
            throw new NotImplementedException();
        }

        public void AddPersona(Persona pers)
        {
            _db.Persona.Add(pers);
            _db.SaveChanges();
        }

      

        public bool DeleteUsuarioBajaLogica(string id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUsuarioPermante(string id)
        {
            throw new NotImplementedException();
        }

      

        public bool EnableUsuario(string id)
        {
            throw new NotImplementedException();
        }

        public void UpdateUsuario(Usuario user)
        {
            _db.Usuario.Update(user);
        }

        public void UpdatePersona(Persona pers)
        {
            _db.Persona.Update(pers);
            _db.SaveChanges();
        }
        #region GETs usuarios
        public Usuario GetUsuario(string userId)
        {
            try
            {
                return _db.Usuario.Where(x => x.Id == userId).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

        public List<Usuario> GetUsuarios(params Expression<Func<Usuario, object>>[] includes)
        {
            try
            {
                IQueryable<Usuario> query = _db.Usuario;

                // Aplica cada inclusión pasada al método
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }

                return query.Where(x => x.UserName != "admin@admin.com")
                            .OrderByDescending(x => x.Id).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

        public List<Usuario> GetUsuarios()
        {
            try
            {
                return _db.Usuario.Where(x => x.UserName != "admin@admin.com")
                           .OrderByDescending(x => x.Id).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

        #endregion






        #region Creacion y actualizacion de Usuario de Sesion
        public async Task<bool> CreateUserAsync(UsuarioPersonaDTO user, Persona persona)
        {
            try
            {
                var us = new Usuario
                {
                    UserName = user.Email,
                    Email = user.Email,
                    EmailConfirmed = true,
                    Persona = persona
                };

                var result = await _UserManager.CreateAsync(us, user.Password);
                await _UserManager.AddClaimAsync(us, new Claim("User Username", user.Email));
                return result.Succeeded;
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task<bool> UpdateUserPersona(UsuarioPersonaUpdateDTO user, Persona persona) 
        {
            try {
                var us = this.GetUsuario(user.Id); us.Persona = persona;
                this.UpdateUsuario(us); 
                await _db.SaveChangesAsync(); 
                return true;
            } catch (Exception e) { return false; }
        }

        #endregion

        #region Logout Usuario
        public void Logout()
        {
            try
            {
                // Eliminar la cookie de autenticación del usuario actual y Limpiar la sesión
                _signInManager.SignOutAsync().Wait();
                //_httpContextAccessor.HttpContext.Session.Clear();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
        
        #region Foto de perfil
        public async Task<bool> AgregarImagenPerfil(IFormFile file, string userId)
        {
            try
            {
                Usuario us = this.GetUsuario(userId);
                if (us.Persona != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await file.CopyToAsync(memoryStream);
                        us.Persona.Foto = memoryStream.ToArray();
                        await _db.SaveChangesAsync();
                    }                    
                    return true;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());               
            }
            return false;
        }
        #endregion

        #region Persona recursos
        public Persona MapearPersona(UsuarioPersonaDTO us)
        {
            Persona persona = new Persona()
            {
                Nombre = us.Nombre,
                Apellido = us.Nombre,
                NroDocumento = us.NroDocumento,
                Cuil = us.Cuil,
                FechaNacimiento = us.FechaNacimiento,
                FechaActualizacion = DateTime.Now
            };

            this.AddPersona(persona);
            return persona;
        }

        public Persona MapearPersonaUpdate(UsuarioPersonaUpdateDTO us)
        {
            Persona persona = new Persona()
            {
                Nombre = us.Nombre,
                Apellido = us.Nombre,
                NroDocumento = us.NroDocumento,
                Cuil = us.Cuil,
                FechaNacimiento = us.FechaNacimiento,
                FechaActualizacion = DateTime.Now
            };

            this.UpdatePersona(persona);
            return persona;
        }
        #endregion
    }
}
