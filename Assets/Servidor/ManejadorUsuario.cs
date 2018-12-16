﻿using Assets.Servidor.ServidorDTO;
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

		public static IEnumerator CargarUsuario()
		{
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
		}

		public static Usuario ObtenerUsuario()
		{
			return usuario;
		}
	}
}
