using DAL.DTOs.Admin;
using DAL.DTOs.SecrEstrategiaAsuntosMilitares;
using DAL.DTOs.Comunicacion;
using DAL.Models.Admin;
using DAL.Models.Comunes;
using DAL.Models.Comunicacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DAL.Mapper
{
    public static class MapperManual
    {
        // Mapper de Indicadores
        public static IndicadorPorcentaje MapearIndicadorPorcentaje(IndicadoresDTO indicadorDTO)
        {
            IndicadorPorcentaje indicador = new IndicadorPorcentaje()
            {
                Id = indicadorDTO.Id,
                Titulo = indicadorDTO.Titulo,
                Descripcion = indicadorDTO.Descripcion,
                FechaActualizacion = DateTime.Now,
                Porcentaje = indicadorDTO.Porcentaje,
                Orden = indicadorDTO.Orden,
                Icono =  indicadorDTO.Icono,
                Activo =  indicadorDTO.Activo,
                PrimerSubTitulo =  indicadorDTO.PrimerSubTitulo,
                Color = indicadorDTO.Color,
                IndicarTendencia = indicadorDTO.IndicarTendencia,
                ValorAnteriorTendencia = indicadorDTO.ValorAnteriorTendencia

            };
            return indicador;

        }

        public static IndicadorComunicacion MapearIndicadorComunicacion(IndicadoresDTO indicadorDTO)
        {
            IndicadorComunicacion indicador = new IndicadorComunicacion()
            {
                Id = indicadorDTO.Id,
                Titulo = indicadorDTO.Titulo,
                Descripcion = indicadorDTO.Descripcion,
                FechaActualizacion = DateTime.Now,
                PrimerSubTitulo = indicadorDTO.PrimerSubTitulo,
                SegundoSubTituto  = indicadorDTO.SegundoSubTituto,
                PrimerValor = indicadorDTO.PrimerValor,
                SegundoValor  = indicadorDTO.SegundoValor,
                Orden = indicadorDTO.Orden,
                Icono = indicadorDTO.Icono,
                Activo =  indicadorDTO.Activo,
                Color = indicadorDTO.Color
            };
            return indicador;
        }

        public static IndicadorNumero MapearIndicadorNumero(IndicadoresDTO indicadorDTO)
        {
            IndicadorNumero indicador = new IndicadorNumero()
            {
                Id = indicadorDTO.Id,
                Titulo = indicadorDTO.Titulo,
                Descripcion = indicadorDTO.Descripcion,
                FechaActualizacion = DateTime.Now,
                Numero = indicadorDTO.Numero,
                Orden = indicadorDTO.Orden,
                Icono =  indicadorDTO.Icono,
                Activo =  indicadorDTO.Activo,
                PrimerSubTitulo =  indicadorDTO.PrimerSubTitulo,
                Color = indicadorDTO.Color
            };
            return indicador;
        }


        public static IndicadorPorcentaje MapearIndicadorPorcentajeUpdate(IndicadoresDTO indicadorDTO, IndicadorPorcentaje indicador)
        {
            indicador.Id = indicadorDTO.Id;
            indicador.Titulo = indicadorDTO.Titulo;
            indicador.Descripcion = indicadorDTO.Descripcion;
            indicador.FechaActualizacion = DateTime.Now;
            indicador.Porcentaje = indicadorDTO.Porcentaje;
            indicador.Orden = indicadorDTO.Orden;
            indicador.Icono =  indicadorDTO.Icono;
            indicador.Activo =  indicadorDTO.Activo;
            indicador.PrimerSubTitulo =  indicadorDTO.PrimerSubTitulo;
            indicador.Color = indicadorDTO.Color;
            indicador.IndicarTendencia = indicadorDTO.IndicarTendencia;
            indicador.ValorAnteriorTendencia = indicadorDTO.ValorAnteriorTendencia;
            return indicador;

        }

        public static IndicadorComunicacion MapearIndicadorComunicacionUpdate(IndicadoresDTO indicadorDTO, IndicadorComunicacion indicador)
        {
            indicador.Id = indicadorDTO.Id;
            indicador.Titulo = indicadorDTO.Titulo;
            indicador.Descripcion = indicadorDTO.Descripcion;
            indicador.FechaActualizacion = DateTime.Now;
            indicador.PrimerSubTitulo = indicadorDTO.PrimerSubTitulo;
            indicador.SegundoSubTituto  = indicadorDTO.SegundoSubTituto;
            indicador.PrimerValor = indicadorDTO.PrimerValor;
            indicador.SegundoValor  = indicadorDTO.SegundoValor;
            indicador.Orden = indicadorDTO.Orden;
            indicador.Icono = indicadorDTO.Icono;
            indicador.Activo =  indicadorDTO.Activo;
            indicador.Color = indicadorDTO.Color;
            return indicador;
        }

        public static IndicadorNumero MapearIndicadorNumeroUpdate(IndicadoresDTO indicadorDTO, IndicadorNumero indicador)
        {
            indicador.Id = indicadorDTO.Id;
            indicador.Titulo = indicadorDTO.Titulo;
            indicador.Descripcion = indicadorDTO.Descripcion;
            indicador.FechaActualizacion = DateTime.Now;
            indicador.Numero = indicadorDTO.Numero;
            indicador.Icono =  indicadorDTO.Icono;
            indicador.Activo =  indicadorDTO.Activo;
            indicador.PrimerSubTitulo =  indicadorDTO.PrimerSubTitulo;
            indicador.Color = indicadorDTO.Color;
            return indicador;
        }

        public static IndicadoresDTO MapearIndicadorDTO(IndicadoresBase indicador)
        {
            IndicadoresDTO indicadorDTO = new IndicadoresDTO()
            {
                Id = indicador.Id,
                Titulo = indicador.Titulo,
                Descripcion = indicador.Descripcion,
                FechaActualizacion = indicador.FechaActualizacion,
                Discriminador =  indicador.GetType().BaseType.Name,
                Orden =  indicador.Orden,
                Icono =  indicador.Icono,
                Activo =  indicador.Activo,
                PrimerSubTitulo =  indicador.PrimerSubTitulo,
                Color = indicador.Color,
            };

            if (indicador is IndicadorPorcentaje)
            {
                IndicadorPorcentaje nuevoIndicador = (IndicadorPorcentaje)indicador;
                indicadorDTO.Porcentaje = nuevoIndicador.Porcentaje;
                indicadorDTO.IndicarTendencia = nuevoIndicador.IndicarTendencia;
                indicadorDTO.ValorAnteriorTendencia = nuevoIndicador.ValorAnteriorTendencia;



            }
            else if (indicador is IndicadorComunicacion)
            {
                IndicadorComunicacion nuevoIndicador = (IndicadorComunicacion)indicador;
                indicadorDTO.PrimerSubTitulo = nuevoIndicador.PrimerSubTitulo;
                indicadorDTO.SegundoSubTituto = nuevoIndicador.SegundoSubTituto;
                indicadorDTO.PrimerValor = nuevoIndicador.PrimerValor;
                indicadorDTO.SegundoValor  = nuevoIndicador.SegundoValor;
            }
            else if (indicador is IndicadorNumero)
            {
                IndicadorNumero nuevoIndicador = (IndicadorNumero)indicador;
                indicadorDTO.Numero = nuevoIndicador.Numero;
                indicadorDTO.PrimerSubTitulo =  indicador.PrimerSubTitulo;
            }
            return indicadorDTO;
        }





        // Mapper de Acciones       

        public static AccionesDTO MapearAccionesDTO(Acciones acciones)
        {
            AccionesDTO accionesDTO = new AccionesDTO()
            {
                Id = acciones.Id,
                Titulo = acciones.Titulo,
                Descripcion = acciones.Descripcion,
                Porcentaje = acciones.Porcentaje,
                Proridad = acciones.Prioridad.Titulo,
                ProridadColor = PrioridadColor(acciones.Prioridad.Titulo),
                OrganismoId = acciones.OrganismoOrigen.Id,
                OrganismoNombre = acciones.OrganismoOrigen.Titulo
            };
            return accionesDTO;
        }


        public static Acciones MapearAcciones(AccionesDTO accionesDTO, OrganismoOrigen organismoOrigen, Prioridades prioridades)
        {
            Acciones acciones = new Acciones()
            {
                Id = accionesDTO.Id,
                Titulo = accionesDTO.Titulo,
                Descripcion = accionesDTO.Descripcion,
                FechaActualizacion = DateTime.Now,
                Porcentaje = accionesDTO.Porcentaje,
                Activo = true,
                OrganismoOrigen = organismoOrigen,
                Prioridad = prioridades
            };
            return acciones;

        }


        // Mapper de Fuerzas
        public static Fuerzas MapearFuerza(FuerzasDTO fuerzasDTO)
        {
            Fuerzas fuerzas = new Fuerzas()
            {
                Id = fuerzasDTO.Id,
                Nombre = fuerzasDTO.Nombre,
                Codigo = fuerzasDTO.Codigo,
                Logo = fuerzasDTO.Logo,
            };
            return fuerzas;
        }

        public static FuerzasDTO MapearFuerzaDTO(Fuerzas fuerzas)
        {
            FuerzasDTO fuerzasDTO = new FuerzasDTO()
            {
                Id = fuerzas.Id,
                Nombre = fuerzas.Nombre,
                Codigo = fuerzas.Codigo,
                Logo = fuerzas.Logo,
            };
            return fuerzasDTO;
        }

        // Mapper de Tipo Medios
        public static TipoMedios MapearTipoMedios(TipoMediosDTO tipoMediosDTO)
        {
            TipoMedios tipoMedios = new TipoMedios()
            {
                Id = tipoMediosDTO.Id,
                Nombre = tipoMediosDTO.Nombre,
                Descripcion = tipoMediosDTO.Descripcion,
                Codigo = tipoMediosDTO.Codigo,
                Logo = tipoMediosDTO.Logo,
            };
            return tipoMedios;
        }

        public static TipoMediosDTO MapearTipoMediosDTO(TipoMedios tipoMedios)
        {
            TipoMediosDTO tipoMediosDTO = new TipoMediosDTO()
            {
                Id = tipoMedios.Id,
                Nombre = tipoMedios.Nombre,
                Descripcion = tipoMedios.Descripcion,
                Codigo = tipoMedios.Codigo,
                Logo = tipoMedios.Logo,
            };
            return tipoMediosDTO;
        }

        // Mapper de Medios
        public static Medios MapearMedios(MediosDTO mediosDTO, Fuerzas fuerza, TipoMedios tipoMedio, Operaciones operacion)
        {
            Medios medios = new Medios()
            {
                Id = mediosDTO.Id,
                Nombre = mediosDTO.Nombre,
                Finalidad = mediosDTO.Finalidad,
                Cantidad = mediosDTO.Cantidad,
                Fuerza = fuerza,
                TipoMedios = tipoMedio,
                Operacion = operacion,
            };
            return medios;
        }

        public static MediosDTO MapearMediosDTO(Medios medios)
        {
            MediosDTO mediosDTO = new MediosDTO()
            {
                Id = medios.Id,
                Nombre = medios.Nombre,
                Finalidad = medios.Finalidad,
                Cantidad = medios.Cantidad,
                Fuerza = medios.Fuerza,
                TipoMedios = medios.TipoMedios,
                OperacionId = medios.Operacion.Id,
                Activo = medios.Activo,
                FuerzaNombre = medios.Fuerza.Nombre,
                TipoNombre = medios.TipoMedios.Nombre,
            };
            return mediosDTO;
        }

        // Mapper de Operaciones
        public static Operaciones MapearOperaciones(OperacionesDTO operacionDTO)
        {
            Operaciones operacion = new Operaciones()
            {
                Id = operacionDTO.Id,
                Nombre = operacionDTO.Nombre,
                Descripcion = operacionDTO.Descripcion,
                Latitud = operacionDTO.Latitud,
                Longitud = operacionDTO.Longitud
            };
            return operacion;
        }
        public static Operaciones MapearOperacionesyColor(OperacionesDTO operacionDTO, string color)
        {
            Operaciones operacion = new Operaciones()
            {
                Id = operacionDTO.Id,
                Nombre = operacionDTO.Nombre,
                Descripcion = operacionDTO.Descripcion,
                Latitud = operacionDTO.Latitud,
                Longitud = operacionDTO.Longitud,
                Color = color
            };
            return operacion;
        }

        public static OperacionesDTO MapearOperacionesDTO(Operaciones operacion)
        {
            OperacionesDTO operacionDTO = new OperacionesDTO()
            {
                Id = operacion.Id,
                Nombre = operacion.Nombre,
                Descripcion = operacion.Descripcion,
                Latitud = operacion.Latitud,
                Longitud = operacion.Longitud
            };
            return operacionDTO;
        }


        public static OperacionesBaseDTO MapearOperacionesBaseDTO(Operaciones operacion)
        {
            OperacionesBaseDTO operacionDTO = new OperacionesBaseDTO()
            {
                Id = operacion.Id,
                Nombre = operacion.Nombre,
                Descripcion = operacion.Descripcion,
                Latitud = operacion.Latitud,
                Longitud = operacion.Longitud,
                Color = operacion.Color
            };

            //ViewData["Title"] = "Comando Operacional";
            List<Medios> ListMedios = operacion.Medios.OrderBy(x => x.TipoMedios.Codigo).ToList();
            //List<string> tipoMedios = ListMedios.Select(x => x.TipoMedios.Nombre).Distinct().ToList();
            //List<string> tipoFuerzas = ListMedios.Select(x => x.Fuerza.Codigo).Distinct().ToList();
            var iconosTipoMedios = ListMedios.Select(x => new { nombre = x.TipoMedios.Nombre, icono = x.TipoMedios.Logo }).Distinct().ToList();


            operacionDTO.Medios = operacion.Medios.OrderBy(x => x.TipoMedios.Codigo).ToList();
            operacionDTO.tipoMedios = ListMedios.Select(x => x.TipoMedios.Nombre).Distinct().ToList();
            operacionDTO.IconosTipoMedios = ListMedios.Select(x => new IconoTipoMedioDTO { Nombre = x.TipoMedios.Nombre, Icono = x.TipoMedios.Logo }).Distinct().ToList();
            operacionDTO.Personal = operacion.Personal;


            return operacionDTO;
        }






        // Mapper de Personal Operaciones
        public static PersonalOperaciones MapearPersonalOperaciones(PersonalOperacionesDTO personalDTO, Fuerzas fuerza, Operaciones operacion)
        {
            PersonalOperaciones personal = new PersonalOperaciones()
            {
                Id = personalDTO.Id,
                Cantidad = personalDTO.Cantidad,
                Fuerza = fuerza,
                Operacion = operacion,
                Activo = personalDTO.Activo,
            };
            return personal;
        }

        public static PersonalOperacionesDTO MapearPersonalOperacionesDTO(PersonalOperaciones personal)
        {
            PersonalOperacionesDTO mediosDTO = new PersonalOperacionesDTO()
            {
                Id = personal.Id,
                Cantidad = personal.Cantidad,
                Fuerza = personal.Fuerza,
                OperacionId = personal.Operacion.Id,
                Activo = personal.Activo,
                FuerzaNombre = personal.Fuerza.Nombre,
            };
            return mediosDTO;
        }

        // Otros
        public static string PrioridadColor(string texto)
        {
            string color = "";
            switch (texto)
            {
                case "Alta":
                    color = "#dd4b39";
                    break;
                case "Media":
                    color = "#f39c12";
                    break;
                case "Baja":
                    color = "#00a65a ";
                    break;
            }
            return color;
        }

        public static string AgregarEspacioSegundaMayuscula(string texto)
        {
            Regex regex = new Regex(@"(?<!^)(?=[A-Z][a-z])");
            string resultado = regex.Replace(texto, " ");
            return resultado;
        }

        //MAPPER PARA COMUNICACIONES
        //Mapper TipoMediciones
        public static TipoMediciones MapearTipoMediciones(TipoMedicionesDTO tipoMedicionesDTO)
        {
            TipoMediciones tipoMediciones = new TipoMediciones()
            {
                Id = tipoMedicionesDTO.Id,
                Nombre = tipoMedicionesDTO.Nombre,
                FechaActualizacion = tipoMedicionesDTO.FechaActualizacion,
                Activo = tipoMedicionesDTO.Activo,
            };
            return tipoMediciones;
        }

        public static TipoMedicionesDTO MapearTipoMedicionesDTO(TipoMediciones tipomediciones)
        {
            TipoMedicionesDTO tiposmedicionesDTO = new TipoMedicionesDTO()
            {
                Id = tipomediciones.Id,
                Nombre = tipomediciones.Nombre,
                FechaActualizacion = tipomediciones.FechaActualizacion,
                Activo = tipomediciones.Activo,
            };
            return tiposmedicionesDTO;
        }
        //Mapper Redes
        public static Redes MapearRedes(RedesDTO redesDTO)
        {
            Redes redes = new Redes()
            {
                Id = redesDTO.Id,
                Nombre = redesDTO.Nombre,
                Descripcion = redesDTO.Descripcion,
                FechaActualizacion = redesDTO.FechaActualizacion,
                Activo = redesDTO.Activo,
                Logo = redesDTO.Logo,
            };
            return redes;
        }

        public static RedesDTO MapearRedesDTO(Redes redes)
        {
            RedesDTO redesDTO = new RedesDTO()
            {
                Id = redes.Id,
                Nombre = redes.Nombre,
                Descripcion = redes.Descripcion,
                FechaActualizacion = redes.FechaActualizacion,
                Activo = redes.Activo,
                Logo = redes.Logo,
            };
            return redesDTO;
        }
        //Mapper Ministerios
        public static Ministerios MapearMinisterios(MinisteriosDTO ministeriosDTO)
        {
            Ministerios ministerios = new Ministerios()
            {
                Id = ministeriosDTO.Id,
                Nombre = ministeriosDTO.Nombre,
                FechaActualizacion = ministeriosDTO.FechaActualizacion,
                Activo = ministeriosDTO.Activo,
                Logo = ministeriosDTO.Logo,
            };
            return ministerios;
        }

        public static MinisteriosDTO MapearMinisteriosDTO(Ministerios ministerios)
        {
            MinisteriosDTO ministeriosDTO = new MinisteriosDTO()
            {
                Id = ministerios.Id,
                Nombre = ministerios.Nombre,
                FechaActualizacion = ministerios.FechaActualizacion,
                Activo = ministerios.Activo,
                Logo = ministerios.Logo,
            };
            return ministeriosDTO;
        }
        //Mapper Ubicaciones
        public static Ubicaciones MapearUbicaciones(UbicacionesDTO ubicacionesDTO)
        {
            Ubicaciones ubicaciones = new Ubicaciones()
            {
                Id = ubicacionesDTO.Id,
                Nombre = ubicacionesDTO.Nombre,
                FechaActualizacion = ubicacionesDTO.FechaActualizacion,
                Activo = ubicacionesDTO.Activo,
                Latitud = ubicacionesDTO.Latitud,
                Longitud = ubicacionesDTO.Longitud,
            };
            return ubicaciones;
        }

        public static UbicacionesDTO MapearUbicacionesDTO(Ubicaciones ubicaciones)
        {
            UbicacionesDTO ubicacionesDTO = new UbicacionesDTO()
            {
                Id = ubicaciones.Id,
                Nombre = ubicaciones.Nombre,
                FechaActualizacion = ubicaciones.FechaActualizacion,
                Activo = ubicaciones.Activo,
                Latitud = ubicaciones.Latitud,
                Longitud = ubicaciones.Longitud,
            };
            return ubicacionesDTO;
        }
        //Mapper Tendencias

        public static Tendencias MapearTendencias(TendenciasDTO tendenciasDTO, Ministerios ministerio, Redes red)
        {
            Tendencias tendencias = new Tendencias()
            {
                Id = tendenciasDTO.Id,
                Fecha = tendenciasDTO.Fecha,
                FechaActualizacion = tendenciasDTO.FechaActualizacion,
                Red = red,
                Ministerio= ministerio,
                Tendencia=tendenciasDTO.Tendencia,
            };
            return tendencias;
        }

        public static TendenciasDTO MapearTendenciasDTO(Tendencias tendencias)
        {
            TendenciasDTO tendenciasDTO = new TendenciasDTO()
            {
                Id = tendencias.Id,
                Fecha = tendencias.Fecha,
                FechaActualizacion = tendencias.FechaActualizacion,
                Red = tendencias.Red,
                Ministerio = tendencias.Ministerio,
                RedNombre = tendencias.Red.Nombre,
                MinisterioNombre = tendencias.Ministerio.Nombre,
                Tendencia=tendencias.Tendencia,

            };
            return tendenciasDTO;
        }

        //Mapper Tendencias

        public static Interacciones MapearInteracciones(InteraccionesDTO interaccionesDTO, Ubicaciones ubicacion, Redes red, TipoMediciones tipomedicion)
        {
            Interacciones interacciones = new Interacciones()
            {
                Id = interaccionesDTO.Id,
                Fecha = interaccionesDTO.Fecha,
                FechaActualizacion = interaccionesDTO.FechaActualizacion,
                Numero = interaccionesDTO.Numero,
                Red = red,
                Ubicacion = ubicacion,
                TipoMedicion = tipomedicion,

            };
            return interacciones;
        }

        public static InteraccionesDTO MapearInteraccionesDTO(Interacciones interacciones)
        {
            InteraccionesDTO interaccionesDTO = new InteraccionesDTO()
            {
                Id = interacciones.Id,
                Fecha = interacciones.Fecha,
                FechaActualizacion = interacciones.FechaActualizacion,
                Red = interacciones.Red,
                Ubicacion = interacciones.Ubicacion,
                TipoMedicion=interacciones.TipoMedicion,
                Numero=interacciones.Numero,
                TipoMedicionNombre=interacciones.TipoMedicion.Nombre,
                RedNombre=interacciones.Red.Nombre,
                UbicacionNombre=interacciones.Ubicacion.Nombre,

            };
            return interaccionesDTO;
        }

        public static string LimpiarCadena(string input)
        {
            string output = Regex.Replace(input, @"[^\d]", "");
            return output;
        }

        public static string ObtenerDiferencia(string NuevoValor, int AntiguoValor)
        {
            int output = Convert.ToInt32(LimpiarCadena(NuevoValor))-AntiguoValor;
            string outputString = "";
            if (output>0)
            {
                outputString = "+"+output;
            }
            else
            {
                outputString = output.ToString();
            }
            return outputString;
        }
    }
}
