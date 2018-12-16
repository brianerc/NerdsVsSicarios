using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Partida
{

	[System.Serializable]
	class Jugador
	{
		public Jugador(string nombreDeUsuariop, string contraseniap)
		{
			nombreusuario = nombreDeUsuariop;
			contrasenia = contraseniap;
		}

		public string nombreusuario { get; set; }
		public string contrasenia { get; set; }
		public string Token { get; set; }
	}
}
