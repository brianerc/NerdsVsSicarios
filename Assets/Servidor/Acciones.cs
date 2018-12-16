using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Servidor
{
	class Acciones
	{
		internal static WWW CrearUsuario(string nombreDeUsuario, string contrasenia)
		{
			string postBodyData = "{\"nombreusuario\":\"" + nombreDeUsuario + "\" , \"contrasenia\": \"" + contrasenia + "\"}";
			return ApiComunicacion.SolicitudPOST(Endpoints.RegistrarUrl, postBodyData, false);
		}

		internal static WWW ObtenerInformacionUsuario()
		{
			Dictionary<string, string> headers = new Dictionary<string, string>();
			headers.Add("Content-Type", "application/json");
			return ApiComunicacion.SolicitudGET(Endpoints.ObtenerUsuarioUrl, headers, true);
		}

		internal static WWW IngresarConUsuario(string nombreDeUsuario, string contrasenia)
		{
			string postCuerpo = "{\"nombreusuario\":\"" + nombreDeUsuario + "\" , \"contrasenia\": \"" + contrasenia + "\"}";
			return ApiComunicacion.SolicitudPOST(Endpoints.IngresarUrl, postCuerpo, false);
		}

		internal static WWW SubirDeNivel()
		{
			string postBodyData = null;
			return ApiComunicacion.SolicitudPOST(Endpoints.SubirDeNivelUrl, postBodyData, true);
		}
		
		internal static WWW CargarCartas()
		{
			Dictionary<string, string> headers = new Dictionary<string, string>();
			headers.Add("Content-Type", "application/json");
			return ApiComunicacion.SolicitudGET(Endpoints.ObtenerCartasUrl, headers, true);
		}

		internal static WWW SubirDeNivelCarta(string cartaId)
		{
			string postCuerpo = null;
			return ApiComunicacion.SolicitudPOST(Endpoints.SubirDeNivelCartaUrl + cartaId, postCuerpo, true);
		}

		internal static WWW CambiarPuntos(int puntos)
		{
			string postCuerpo = "{\"puntos\":\"" + puntos + "\"}";
			return ApiComunicacion.SolicitudPOST(Endpoints.CambiarPuntos, postCuerpo, false);
		}
	}
}
