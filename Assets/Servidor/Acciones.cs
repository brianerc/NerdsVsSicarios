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
			var www = ApiComunicacion.SolicitudPOST(Endpoints.IngresarUrl, postCuerpo, false);
			Debug.Log("Cargando Usuario");
			return www;
		}

		internal static WWW SubirDeNivel()
		{
			string postBodyData = null;
			var www = ApiComunicacion.SolicitudPOST(Endpoints.SubirDeNivelUrl, postBodyData, true);
			ManejadorUsuario.CargarUsuario();
			return www;
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
			var www = ApiComunicacion.SolicitudPOST(Endpoints.SubirDeNivelCartaUrl + cartaId, postCuerpo, true);
            ManejadorUsuario.CargarUsuario();
			return www;
		}

		internal static WWW CambiarPuntos(int puntos)
		{
			string postCuerpo = "{\"puntos\":\"" + puntos + "\"}";
			var www = ApiComunicacion.SolicitudPOST(Endpoints.CambiarPuntos, postCuerpo, true);
            ManejadorUsuario.CargarUsuario();
			return www;
		}

		public static int ObtenerPuntosNecesariosSegunIdCarta(string id)
		{
			List<Assets.Scripts.ServidorDTO.Carta> cartas = ManejadorUsuario.cartasUsuario;
			foreach (var item in cartas)
			{
				if (item._id.Equals(id))
				{
					return item.costo_para_desbloquear;
				}
			}
			return -1;
		}

	
	}
}
