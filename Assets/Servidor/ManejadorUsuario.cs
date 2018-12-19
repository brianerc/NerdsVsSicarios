using Assets.Scripts.ServidorDTO;
using Assets.Servidor.ServidorDTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Servidor
{
	class ManejadorUsuario
	{
		private static Usuario usuario = null;
		public static List<Assets.Scripts.ServidorDTO.Carta> cartasUsuario = null;
        public static bool cargoUsuario = false;
        public static bool cargoCartas = false;
		public static IEnumerator CargarUsuario()
		{
            cargoUsuario = false;
            usuario = null;
			Debug.Log("Cargando usuario");
			if (usuario == null)
			{
				WWW www = Acciones.ObtenerInformacionUsuario();
				yield return www;
				if (www.error == "404 Not Found")
				{
					PlayerPrefs.DeleteKey("token");
				}
				else
				{
					usuario = JsonUtility.FromJson<Usuario>(www.text);
					Debug.Log(usuario._id);
				}
			}
            cargoUsuario = true;
		}

		public static IEnumerator CargarCartas()
		{
            cargoCartas = false;
			Debug.Log("Cargando cartas");
			WWW www = Acciones.CargarCartas();
			yield return www;
			if (www.error != null)
			{
				PlayerPrefs.DeleteKey("token");
			}
			else
			{
				CartaDTO resultObj = JsonUtility.FromJson<CartaDTO>(www.text);
				cartasUsuario = resultObj.cartas;
			}
            cargoCartas = true;
		}

		public static Usuario ObtenerUsuario()
		{
			return usuario;
		}
	}
}
