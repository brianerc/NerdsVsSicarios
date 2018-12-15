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

		internal static WWW IngresarConUsuario(string nombreDeUsuario, string contrasenia)
		{
			string postBodyData = "{\"nombreusuario\":\"" + nombreDeUsuario + "\" , \"contrasenia\": \"" + contrasenia + "\"}";
			return ApiComunicacion.SolicitudPOST(Endpoints.IngresarUrl, postBodyData, false);
		}

		internal static WWW CargarCartas()
		{
			
			Dictionary<string, string> headers = new Dictionary<string, string>();
			headers.Add("Content-Type", "application/json");
			return ApiComunicacion.SolicitudGET(Endpoints.ObtenerCartasUrl, headers, true);
		}
	}
}
