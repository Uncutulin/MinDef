using AutoMapper;
using Commons.Controllers;
using DAL.Models.Admin;
using DAL.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MinDef.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinDef.Areas.Admin.Controllers
{
    [Authorize]
    public class MinDefBaseController : BaseController
    {
        protected IContenedorTrabajo<Usuario> _workSpace;
        protected MinDefContext _db;
        protected IMapper _mapper;
        //public IHttpContextAccessor _httpContextAccessor;

        public MinDefBaseController()
        {
                
        }

        public MinDefBaseController(MinDefContext db, IContenedorTrabajo<Usuario> workSpace,
            IMapper mapper)
        {
            this._mapper = mapper;
            this._db = db;
            this._workSpace = workSpace;
        }

        public IActionResult LogoutSesion()
        {
            _workSpace.Usuarios.Logout();
            return Redirect("~/Identity/Account/Login");
        }
    }
}
