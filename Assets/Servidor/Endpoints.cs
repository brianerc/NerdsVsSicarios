using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Servidor
{
	class Endpoints
	{
		private static string HOST = "http://35.243.154.34:8090/api/v1/";
		public static string RegistrarUrl = HOST + "usuario";
		public static string IngresarUrl = HOST + "usuario/auth";
		public static string ObtenerCartasUrl = HOST + "usuario/5bf59a9e5cd5fc001855bbc3/carta";
		public static string SubirDeNivelUrl = HOST + "/usuario/5c15685ffa79dd5c30f74616/nivel";
		public static string SubirDeNivelCartaUrl = HOST + "usuario/5c1570c36a98361c780b4b34/carta/";
		public static string ObtenerUsuarioUrl = HOST + "usuario/5c1570c36a98361c780b4b34";
		public static string CambiarPuntos = HOST + "usuario/5c1570c36a98361c780b4b34/puntos";
	}
}
