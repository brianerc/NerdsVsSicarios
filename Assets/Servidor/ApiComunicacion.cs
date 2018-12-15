using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Servidor
{
	class ApiComunicacion
	{
		public static WWW SolicitudPOST(string uri, string cuerpo, bool userToken)
		{
			Dictionary<string, string> headers = new Dictionary<string, string>();
			headers.Add("Content-Type", "application/json");

			byte[] pData = System.Text.Encoding.ASCII.GetBytes(cuerpo.ToCharArray());

			return new WWW(uri, pData, headers);
		}

		internal static WWW SolicitudPOST(object ingresarUrl, string postBodyData, bool v)
		{
			throw new NotImplementedException();
		}
	}
}
