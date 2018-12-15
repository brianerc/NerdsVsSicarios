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
		internal static string IngresarUrl = HOST + "usuario/auth";
	}
}
