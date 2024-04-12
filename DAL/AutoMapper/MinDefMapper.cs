using AutoMapper;
using DAL.DTOs.Admin;
using DAL.Models.Admin;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.AutoMapper
{
    public class MinDefMapper : Profile
    {
        public MinDefMapper()
        {
            CreateMap<Usuario, UsuarioPersonaDTO>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
              .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Persona.Nombre))
              .ForMember(dest => dest.Apellido, opt => opt.MapFrom(src => src.Persona.Apellido))
              .ForMember(dest => dest.NroDocumento, opt => opt.MapFrom(src => src.Persona.NroDocumento))
              .ForMember(dest => dest.FechaNacimiento, opt => opt.MapFrom(src => src.Persona.FechaNacimiento))
              .ForMember(dest => dest.Cuil, opt => opt.MapFrom(src => src.Persona.Cuil))
             .ForMember(dest => dest.FotoBase64, opt => opt.MapFrom(src => Convert.ToBase64String(src.Persona.Foto)))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.UserName))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.PasswordHash));

            CreateMap<Usuario, UsuarioPersonaUpdateDTO>()
             .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
             .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Persona.Nombre))
             .ForMember(dest => dest.Apellido, opt => opt.MapFrom(src => src.Persona.Apellido))
             .ForMember(dest => dest.NroDocumento, opt => opt.MapFrom(src => src.Persona.NroDocumento))
             .ForMember(dest => dest.FechaNacimiento, opt => opt.MapFrom(src => src.Persona.FechaNacimiento))
             .ForMember(dest => dest.Cuil, opt => opt.MapFrom(src => src.Persona.Cuil))
            .ForMember(dest => dest.FotoBase64, opt => opt.MapFrom(src => Convert.ToBase64String(src.Persona.Foto)));

        }
    }
}
