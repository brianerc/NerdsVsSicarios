using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.ServidorDTO
{
	[System.Serializable]
	public class Autenticacion
	{
		public bool exito { get; set; }
		public string msg { get; set; }
		public string token { get; set; }
	}
}
