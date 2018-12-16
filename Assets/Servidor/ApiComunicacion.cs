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
			if (userToken)
			{
				string token = PlayerPrefs.GetString("token");
				headers.Add("token", token);
			}
			byte[] pData;
			if (cuerpo != null)
			{
				pData = System.Text.Encoding.ASCII.GetBytes(cuerpo.ToCharArray());
			}
			else
			{
				pData = null;
			}
			return new WWW(uri, pData, headers);
		}

		internal static WWW SolicitudGET(string uri, Dictionary<string, string> headers, bool userToken)
		{
			string token = PlayerPrefs.GetString("token");
			headers.Add("token", token);
			return new WWW(uri, null, headers);
		}
	}
}
